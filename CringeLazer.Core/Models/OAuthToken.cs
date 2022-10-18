namespace CringeLazer.Core.Models;

public class OAuthToken
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public double ExpiresIn { get; set; }
}
