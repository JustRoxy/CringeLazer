namespace CringeLazer.Bancho.Contracts;

public class UserCompact
{
    public string AvatarUrl { get; set; }
    public User.CountryClass Country { get; set; }
    public User.UserCover Cover { get; set; }
    public string CountryCode { get; set; }
    public string DefaultGroup { get; set; }
    public ulong Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsBot { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsOnline { get; set; }
    public bool IsSupporter { get; set; }
    public DateTime? LastVisit { get; set; }
    public bool PmFriendsOnly { get; set; }
    public string ProfileColour { get; set; }
    public string Username { get; set; }
}
