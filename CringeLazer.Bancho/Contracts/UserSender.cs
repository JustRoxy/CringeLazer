namespace CringeLazer.Bancho.Contracts;

public class UserSender
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    public string ProfileColour { get; set; }
    public string CountryCode { get; set; }
    public bool IsActive { get; set; }
    public bool IsBot { get; set; }
    public bool IsOnline { get; set; }
    public bool IsSupporter { get; set; }
}
