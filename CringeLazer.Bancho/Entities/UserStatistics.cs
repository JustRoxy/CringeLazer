using MongoDB.Entities;

namespace CringeLazer.Bancho.Entities;

public class UserStatistics
{
    [Field(@"level")]
    public LevelInfo Level { get; set; }

    [Field(@"is_ranked")]
    public bool IsRanked { get; set; }

    [Field(@"global_rank")]
    public int? GlobalRank { get; set; }

    [Field(@"country_rank")]
    public int? CountryRank { get; set; }

    [Field(@"pp")]
    public decimal? Pp { get; set; }

    [Field(@"ranked_score")]
    public long RankedScore { get; set; }

    [Field(@"hit_accuracy")]
    public double Accuracy { get; set; }

    [Field(@"play_count")]
    public int PlayCount { get; set; }

    [Field(@"play_time")]
    public int? PlayTime { get; set; }

    [Field(@"total_score")]
    public long TotalScore { get; set; }

    [Field(@"total_hits")]
    public int TotalHits { get; set; }

    [Field(@"maximum_combo")]
    public int MaxCombo { get; set; }

    [Field(@"replays_watched_by_others")]
    public int ReplaysWatched { get; set; }

    [Field(@"grade_counts")]
    public Grades GradesCount { get; set; }

    public class LevelInfo
    {
        [Field(@"current")]
        public int Current { get; set; }

        [Field(@"progress")]
        public int Progress { get; set; }
    }

    public class Grades
    {
        [Field(@"ssh")]
        public int? SSPlus { get; set; }

        [Field(@"ss")]
        public int SS { get; set; }

        [Field(@"sh")]
        public int? SPlus { get; set; }

        [Field(@"s")]
        public int S { get; set; }

        [Field(@"a")]
        public int A { get; set; }
    }
}
