using CringeLazer.Core.Enums;
using Newtonsoft.Json;

namespace CringeLazer.Bancho.Contracts.Responses;

public class StatisticsResponse
{
    public Gamemode Gamemode { get; set; }
    [JsonProperty(@"level")]
    public LevelInfo Level { get; set; }

    public class LevelInfo
    {
        [JsonProperty(@"current")]
        public int Current { get; set; }

        [JsonProperty(@"progress")]
        public int Progress { get; set; }
    }

    [JsonProperty(@"is_ranked")]
    public bool IsRanked { get; set; }

    [JsonProperty(@"global_rank")]
    public int? GlobalRank { get; set; }

    [JsonProperty(@"country_rank")]
    public int? CountryRank { get; set; }

    [JsonProperty("rank_history")]
    public List<int> RankHistory { get; set; }

    [JsonProperty(@"pp")]
    public decimal? PP { get; set; }

    [JsonProperty(@"ranked_score")]
    public long RankedScore { get; set; }

    [JsonProperty(@"hit_accuracy")]
    public double Accuracy { get; set; }

    [JsonProperty(@"play_count")]
    public int PlayCount { get; set; }

    [JsonProperty(@"play_time")]
    public int? PlayTime { get; set; }

    [JsonProperty(@"total_score")]
    public long TotalScore { get; set; }

    [JsonProperty(@"total_hits")]
    public int TotalHits { get; set; }

    [JsonProperty(@"maximum_combo")]
    public int MaxCombo { get; set; }

    [JsonProperty(@"replays_watched_by_others")]
    public int ReplaysWatched { get; set; }

    [JsonProperty(@"grade_counts")]
    public GradesResponse Grades { get; set; }

    public class GradesResponse
    {
        [JsonProperty(@"ssh")]
        public int? SSPlus { get; set; }

        [JsonProperty(@"ss")]
        public int SS { get; set; }

        [JsonProperty(@"sh")]
        public int? SPlus { get; set; }

        [JsonProperty(@"s")]
        public int S { get; set; }

        [JsonProperty(@"a")]
        public int A;
    }
}
