using System.Linq.Expressions;
using CringeLazer.Bancho.Contracts.Responses;
using CringeLazer.Bancho.Extensions;
using CringeLazer.Core.Enums;
using CringeLazer.Core.Models.Users;
using CringeLazer.Core.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho.Controllers.API;

[ApiController]
[Route("api/v2/users")]
public class UserController
{
    private readonly IOnlineUsers _online;
    private readonly IUserService _users;

    public UserController(IOnlineUsers online, IUserService users)
    {
        _online = online;
        _users = users;
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetUser(string id, [FromQuery] string key)
    {
        return GetUserGamemode(id, Gamemode.Osu, key);
    }

    [HttpGet("{id}/{gamemode}")]
    public async Task<IActionResult> GetUserGamemode(string id, Gamemode gamemode, [FromQuery] string key)
    {
        long.TryParse(id, out var lId);
        Expression<Func<UserModel, bool>> selector = key switch
        {
            "id" => model => model.UserId == lId,
            _ => model => model.Username == id
        };

        var result = await _users.GetOne(user => user.AsNoTracking()
            .Include(x => x.Statistics.Where(z => z.Gamemode == gamemode))
            .Where(selector)
            .ProjectToType<UserResponse>());

        result = await result.MapAsync(async x =>
        {
            x.IsOnline = await _online.IsOnline(id);
            return x;
        });

        return result.ToResult();
    }

}
