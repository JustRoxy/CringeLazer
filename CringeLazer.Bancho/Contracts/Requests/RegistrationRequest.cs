using Microsoft.AspNetCore.Mvc;

namespace CringeLazer.Bancho.Contracts.Requests;

public class RegistrationRequest
{
    [FromForm(Name = "user[username]")]
    public string Username { get; set; }

    [FromForm(Name = "user[user_email]")]
    public string Email { get; set; }

    [FromForm(Name = "user[password]")]
    public string Password { get; set; }
}
