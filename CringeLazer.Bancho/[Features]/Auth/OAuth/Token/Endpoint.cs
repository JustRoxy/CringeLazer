using Microsoft.Extensions.Options;

namespace CringeLazer.Bancho._Features_.Auth.OAuth.Token;

public class Endpoint : Endpoint<Request, Response>
{
    private readonly Settings _settings;

    public Endpoint(IOptions<Settings> settings)
    {
        _settings = settings.Value;
    }

    public override void Configure()
    {
        Post("/oauth/token");
        AllowFormData();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = await Data.GetUser(req.Username);
        if (user is null)
        {
            await SendNotFoundAsync();
            return;
        }

        var result = BCrypt.Net.BCrypt.EnhancedVerify(req.Password, user.Password);
        if (!result)
        {
            ThrowError("Incorrect username or password");
            return;
        }

        var token = JWTBearer.CreateToken(
            signingKey: _settings.Token.SigningKey,
            expireAt: DateTime.UtcNow.AddDays(1),
            claims: new[] { ("Id", user.ID) },
            permissions: new[] { "OsuClient" });

        await SendOkAsync(new Response
        {
            AccessToken = token,
            RefreshToken = "reftoken",
            ExpiresIn = 86400,
            TokenType = "bearer"
        });
    }
}
