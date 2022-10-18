namespace CringeLazer.Core.Models;

public class UserModel
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string RefreshToken { get; set; }
}
