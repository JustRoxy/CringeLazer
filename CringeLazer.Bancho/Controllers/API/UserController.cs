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
    private readonly IUserService _users;

    public UserController(IUserService users)
    {
        _users = users;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id, [FromQuery] string key)
    {
        long.TryParse(id, out var lId);
        Expression<Func<UserModel, bool>> selector = key switch
        {
            "id" => model => model.UserId == lId,
            _ => model => model.Username == id
        };

        var result = await _users.GetOne(user => user.AsNoTracking()
            .Include(x => x.Statistics.Where(z => z.Gamemode == Gamemode.Osu))
            .Where(selector)
            .ProjectToType<UserResponse>());

        return result.ToResult();
    }

}
