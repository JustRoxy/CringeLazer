using CringeLazer.Bancho.Helpers;

namespace CringeLazer.Bancho._Features_.Auth.OAuth.Token;

public class Request : IResultRequest<Response>
{
    [BindFrom("username")]
    public string Username { get; set; } = null!;

    [BindFrom("password")]
    public string Password { get; set; } = null!;

    [BindFrom("grant_type")]
    public string GrantType { get; set; } = null!;

    [BindFrom("client_id")]
    public string? ClientId { get; set; }

    [BindFrom("client_secret")]
    public string? ClientSecret { get; set; }

    [BindFrom("scope")]
    public string? Scope { get; set; }
}

public class Response
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public int ExpiresIn { get; set; }
    public string TokenType { get; set; } = null!;
}
