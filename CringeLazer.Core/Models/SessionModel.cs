namespace CringeLazer.Core.Models;

public class SessionModel
{
    public long SessionId { get; set; }
    public long UserId { get; set; }
    public string RefreshToken { get; set; }

    public UserModel User { get; set; }
}
