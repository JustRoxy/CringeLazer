using CringeLazer.Bancho.Contracts.Responses;
using CringeLazer.Bancho.Extensions;
using CringeLazer.Core.Enums;
using CringeLazer.Core.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho.Controllers.API;

[ApiController]
[Authorize]
[Route("api/v2/me")]
public class MeController : ControllerBase
{
    private readonly IUserService _users;

    public MeController(IUserService users)
    {
        _users = users;
    }

    [HttpGet]
    [ProducesResponseType(typeof(UserResponse), 200)]
    public Task<IActionResult> GetMe()
    {
        return GetMeGamemode(Gamemode.Osu);
    }

    [HttpGet("{gamemode}")]
    [ProducesResponseType(typeof(UserResponse), 200)]
    public async Task<IActionResult> GetMeGamemode(Gamemode gamemode)
    {
        var userId = long.Parse(HttpContext.User.Identity!.Name!);

        var result = await _users.GetOne(x => x
            .AsNoTracking()
            .Include(v => v.Statistics.Where(z => z.Gamemode == gamemode))
            .Where(z => z.UserId == userId)
            .ProjectToType<UserResponse>());

        return result.ToResult();
    }
}
