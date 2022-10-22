using CringeLazer.Bancho.Contracts.Responses;
using CringeLazer.Core.Enums;
using CringeLazer.Core.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho.Controllers;

[ApiController]
[Authorize]
public class MeController : ControllerBase
{
    private readonly IUserService _users;

    public MeController(IUserService users)
    {
        _users = users;
    }

    [HttpGet("{gamemode}")]
    public async Task<UserResponse> GetMe(Gamemode gamemode = Gamemode.Osu)
    {
        var userId = int.Parse(HttpContext.User.Identity!.Name!);
        return await _users.GetOne(x => x
                .AsNoTracking()
                .Include(v => v.Statistics.Where(z => z.Gamemode == gamemode))
                .Where(z => z.UserId == userId)
                .ProjectToType<UserResponse>());
    }
}
