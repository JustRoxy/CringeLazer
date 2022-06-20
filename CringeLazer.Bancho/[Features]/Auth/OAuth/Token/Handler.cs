using CringeLazer.Bancho.Data;
using CringeLazer.Bancho.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CringeLazer.Bancho._Features_.Auth.OAuth.Token;

public class Handler : IRequestHandler<Request, Result<Response>>
{
    private readonly CringeContext _context;
    private readonly Settings _settings;

    public Handler(CringeContext context, IOptions<Settings> settings)
    {
        _context = context;
        _settings = settings.Value;
    }

    private Task<Domain.User> GetUser(string username, CancellationToken token)
    {
        return _context.Users.Select(x =>
            new Domain.User
            {
                Id = x.Id,
                Password = x.Password,
                Username = x.Username
            })
            .FirstOrDefaultAsync(x => x.Username == username, token);
    }

    public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = await GetUser(request.Username, cancellationToken);
        if (user is null)
        {
            return Result<Response>.Error($"User {request.Username} is not found", ErrorType.NotFound);
        }

        var result = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password);
        if (!result)
        {
            return Result<Response>.Error("Incorrect username or password", ErrorType.BadRequest);
        }

        var token = JWTBearer.CreateToken(
            signingKey: _settings.Token.SigningKey,
            expireAt: DateTime.UtcNow.AddDays(1),
            claims: new[] { ("Id", user.Id.ToString()) },
            permissions: new[] { "OsuClient" });

        return Result<Response>.Some(new Response
        {
            AccessToken = token,
            RefreshToken = "reftoken",
            ExpiresIn = 86400,
            TokenType = "bearer"
        });
    }
}
