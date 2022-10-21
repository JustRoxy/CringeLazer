using CringeLazer.Core.Enums;
using CringeLazer.Core.Models.Users;

namespace CringeLazer.Core.Models.Statistics;

public class StatisticsModel
{
    public long UserId { get; set; }
    public UserModel User { get; set; }
    public Gamemode Gamemode { get; set; }

    public List<int> RankHistory { get; set; }
    public LevelInfo Level { get; set; }
    public bool IsRanked { get; set; }
    public int? GlobalRank { get; set; }
    public int? CountryRank { get; set; }
    public decimal? PP { get; set; }
    public long RankedScore { get; set; }
    public double Accuracy { get; set; }
    public int PlayCount { get; set; }
    public int? PlayTime { get; set; }
    public long TotalScore { get; set; }
    public int TotalHits { get; set; }
    public int MaxCombo { get; set; }
    public int ReplaysWatched { get; set; }
    public Grades Grades { get; set; }
}
