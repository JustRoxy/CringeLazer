using CringeLazer.Bancho.Contracts;
using CringeLazer.Bancho.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho._Features_.Api.GetFriends;

public class Handler : IRequestHandler<Request, List<User>>
{
    private readonly CringeContext _context;

    public Handler(CringeContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetFriends(int id, CancellationToken token)
    {
        return await _context.Users
            .Where(x => x.UserId == id)
            .Select(x => x.Friends)
            .ProjectToType<List<User>>()
            .SelectMany(x => x)
            .ToListAsync(token);
    }

    public async Task<List<User>> Handle(Request request, CancellationToken cancellationToken)
    {
        return await GetFriends(request.Id, cancellationToken);
    }
}
