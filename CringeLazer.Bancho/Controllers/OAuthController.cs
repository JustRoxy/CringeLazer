using CringeLazer.Bancho.Contracts;
using CringeLazer.Bancho.Contracts.Requests;
using CringeLazer.Bancho.Extensions;
using CringeLazer.Core;
using CringeLazer.Core.Models;
using CringeLazer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CringeLazer.Bancho.Controllers;

[ApiController]
[Route("oauth")]
public class OAuthController : ControllerBase
{
    private readonly IAuthorizationService _authorization;

    public OAuthController(IAuthorizationService authorization)
    {
        _authorization = authorization;
    }

    [HttpPost]
    public async Task<IActionResult> Login(OAuthLoginRequest request)
    {
        var result = request.GrantType switch
        {
            "password" => await _authorization.Access(request.Username, request.Password),
            "refresh_token" => await _authorization.Refresh(request.RefreshToken),
            _ => new Result<OAuthToken>("Unsupported grant_type", 415)
        };

        return result.ToResult();
    }
}
