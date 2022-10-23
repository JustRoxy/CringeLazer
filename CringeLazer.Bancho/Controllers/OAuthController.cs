using CringeLazer.Bancho.Contracts.Requests;
using CringeLazer.Bancho.Extensions;
using CringeLazer.Core.Exceptions;
using CringeLazer.Core.Models;
using CringeLazer.Core.Services;
using LanguageExt.Common;
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

    [HttpPost("token")]
    public async Task<IActionResult> Login([FromForm] OAuthLoginRequest request)
    {
        var result = request.GrantType switch
        {
            "password" => await _authorization.Access(request.Username, request.Password),
            "refresh_token" => await _authorization.Refresh(request.RefreshToken),
            _ => new Result<OAuthToken>(new StatusCodeException("Unsupported grant_type",
                StatusCodes.Status415UnsupportedMediaType))
        };

        return result.ToResult();
    }
}
