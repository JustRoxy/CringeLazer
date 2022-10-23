using CringeLazer.Application.Database;
using CringeLazer.Bancho.Contracts.Responses;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho.Controllers.API;

[ApiController]
[Route("/api/v2/friends")]
[Authorize]
public class FriendsController : ControllerBase
{
    private readonly CringeContext _context;

    public FriendsController(CringeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<UserResponse>> GetFriends()
    {
        var userId = long.Parse(HttpContext.User.Identity!.Name!);
        return await _context.Friends.Where(x => x.IssuerId == userId)
            .Select(x => x.Receiver)
            .ProjectToType<UserResponse>()
            .ToListAsync();
    }
}
