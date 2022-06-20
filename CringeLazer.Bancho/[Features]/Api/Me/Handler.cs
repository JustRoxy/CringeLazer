using CringeLazer.Bancho.Data;
using CringeLazer.Bancho.Helpers;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using User = CringeLazer.Bancho.Contracts.User;

namespace CringeLazer.Bancho._Features_.Api.Me;

public class Handler : IRequestHandler<Request, Result<User>>
{
    private readonly CringeContext _context;

    public Handler(CringeContext context)
    {
        _context = context;
    }

    public async Task<User> GetData(int id, CancellationToken token)
    {
        return await _context.Users
            .ProjectToType<User>()
            .FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<Result<User>> Handle(Request request, CancellationToken cancellationToken)
    {
        var data = await GetData(request.Id, cancellationToken);
        if (data is null)
        {
            return Result<User>.Error($"User {request.Id} is not found", ErrorType.NotFound);
        }

        return Result<User>.Some(data);
    }
}
