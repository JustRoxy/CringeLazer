using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CringeLazer.Bancho.Contracts.Requests;

public class OAuthLoginRequest
{
    [FromForm(Name = "username")]
    [JsonProperty("username")]
    public string Username { get; set; }

    [FromForm(Name = "password")]
    [JsonProperty("password")]
    public string Password { get; set; }

    [FromForm(Name = "grant_type")]
    [JsonProperty("grant_type")]
    public string GrantType { get; set; }

    [FromForm(Name = "refresh_token")]
    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
}
