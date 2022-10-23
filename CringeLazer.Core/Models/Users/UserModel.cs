using CringeLazer.Core.Enums;
using CringeLazer.Core.Models.Statistics;

namespace CringeLazer.Core.Models.Users;

public class UserModel
{
    public long UserId { get; set; }
    public IList<SessionModel> Sessions { get; set; }
    public IList<StatisticsModel> Statistics { get; set; }
    public IList<FriendsModel> Friends { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime JoinDate { get; set; }
    public List<string> PreviousUsernames { get; set; }
    public Countries Country { get; set; }

    #region Roles
    public bool IsAdmin { get; set; }
    public bool IsSupporter { get; set; }
    public int SupportLevel { get; set; }
    public bool IsGMT { get; set; }
    public bool IsQAT { get; set; }
    public bool IsBNG { get; set; }
    public bool IsBot { get; set; }
    #endregion

    #region Status
    public bool IsActive { get; set; }
    public DateTime LastVisit { get; set; }
    public List<History> MonthlyPlayCounts { get; set; }
    public List<History> ReplaysWatchedCounts { get; set; }
    #endregion

    #region Settings
    public string AvatarUrl { get; set; }
    public string CoverUrl { get; set; }
    public List<Playstyles> Playstyle  { get; set; }
    public Gamemode Playmode { get; set; }
    public List<ProfilePage> ProfileOrder { get; set; }
    public bool PMFriendsOnly {get;set;}
    public string Interests { get; set; }
    public string Occupation { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Twitter { get; set; }
    public string Discord { get; set; }
    public string Website { get; set; }
    #endregion

    #region Internal
    public string Colour { get; set; }
    public Kudosu Kudosu { get; set; }
    public ICollection<Badge> Badges { get; set; }

    public ICollection<Achievement> Achievements { get; set; }
    #endregion
}
