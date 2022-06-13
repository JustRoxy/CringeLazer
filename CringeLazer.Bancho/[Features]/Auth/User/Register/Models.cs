using System.Text.Json.Serialization;

namespace CringeLazer.Bancho._Features_.Auth.User.Register;

public class Request
{
    [JsonPropertyName("user[username]")]
    [BindFrom("user[username]")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("user[password]")]
    [BindFrom("user[password]")]
    public string Password { get; set; } = null!;

    [JsonPropertyName("user[user_email]")]
    [BindFrom("user[user_email]")]
    public string Email { get; set; } = null!;
}
