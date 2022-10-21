using CringeLazer.Core.Enums;
using CringeLazer.Core.Models.Statistics;

namespace CringeLazer.Core.Models.Users;

public class UserModel
{
    public long UserId { get; set; }
    public ICollection<SessionModel> Sessions { get; set; }
    public ICollection<StatisticsModel> Statistics { get; set; }
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
    #endregion

    #region Settings
    public bool PMFriendsOnly {get;set;}
    public string Interests { get; set; }
    public string Occupation { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Twitter { get; set; }
    public string Discord { get; set; }
    public string Website { get; set; }
    #endregion

    public Kudosu Kudosu { get; set; }
    public ICollection<Badge> Badges { get; set; }

    public ICollection<Achievement> Achievements { get; set; }

}
