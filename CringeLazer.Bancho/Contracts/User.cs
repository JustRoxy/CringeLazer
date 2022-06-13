using System.Text.Json.Serialization;

namespace CringeLazer.Bancho.Contracts;

public class User
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName(@"join_date")]
    public DateTimeOffset JoinDate { get; set; }

    [JsonPropertyName(@"username")]
    public string Username { get; set; }

    [JsonPropertyName(@"previous_usernames")]
    public string[] PreviousUsernames { get; set; }

    [JsonPropertyName(@"country")]
    public CountryClass Country { get; set; }

    [JsonPropertyName(@"profile_colour")]
    public string Colour { get; set; }

    [JsonPropertyName(@"avatar_url")]
    public string AvatarUrl { get; set; }

    [JsonPropertyName(@"cover_url")]
    public string CoverUrl
    {
        get => Cover?.Url;
        set => Cover = new UserCover { Url = value };
    }

    [JsonPropertyName(@"cover")]
    public UserCover Cover { get; set; }

    [JsonPropertyName(@"is_admin")]
    public bool IsAdmin { get; set; }

    [JsonPropertyName(@"is_supporter")]
    public bool IsSupporter { get; set; }

    [JsonPropertyName(@"support_level")]
    public int SupportLevel { get; set; }

    [JsonPropertyName(@"is_gmt")]
    public bool IsGMT { get; set; }

    [JsonPropertyName(@"is_qat")]
    public bool IsQAT { get; set; }

    [JsonPropertyName(@"is_bng")]
    public bool IsBNG { get; set; }

    [JsonPropertyName(@"is_bot")]
    public bool IsBot { get; set; }

    [JsonPropertyName(@"is_active")]
    public bool Active { get; set; }

    [JsonPropertyName(@"is_online")]
    public bool IsOnline { get; set; }

    [JsonPropertyName(@"pm_friends_only")]
    public bool PMFriendsOnly { get; set; }

    [JsonPropertyName(@"interests")]
    public string Interests { get; set; }

    [JsonPropertyName(@"occupation")]
    public string Occupation { get; set; }

    [JsonPropertyName(@"title")]
    public string Title { get; set; }

    [JsonPropertyName(@"location")]
    public string Location { get; set; }

    [JsonPropertyName(@"last_visit")]
    public DateTimeOffset? LastVisit { get; set; }

    [JsonPropertyName(@"twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName(@"discord")]
    public string Discord { get; set; }

    [JsonPropertyName(@"website")]
    public string Website { get; set; }

    [JsonPropertyName(@"post_count")]
    public int PostCount { get; set; }

    [JsonPropertyName(@"comments_count")]
    public int CommentsCount { get; set; }

    [JsonPropertyName(@"follower_count")]
    public int FollowerCount { get; set; }

    [JsonPropertyName(@"mapping_follower_count")]
    public int MappingFollowerCount { get; set; }

    [JsonPropertyName(@"favourite_beatmapset_count")]
    public int FavouriteBeatmapsetCount { get; set; }

    [JsonPropertyName(@"graveyard_beatmapset_count")]
    public int GraveyardBeatmapsetCount { get; set; }

    [JsonPropertyName(@"loved_beatmapset_count")]
    public int LovedBeatmapsetCount { get; set; }

    [JsonPropertyName(@"ranked_beatmapset_count")]
    public int RankedBeatmapsetCount { get; set; }

    [JsonPropertyName(@"pending_beatmapset_count")]
    public int PendingBeatmapsetCount { get; set; }

    [JsonPropertyName(@"guest_beatmapset_count")]
    public int GuestBeatmapsetCount { get; set; }

    [JsonPropertyName(@"scores_best_count")]
    public int ScoresBestCount { get; set; }

    [JsonPropertyName(@"scores_first_count")]
    public int ScoresFirstCount { get; set; }

    [JsonPropertyName(@"scores_recent_count")]
    public int ScoresRecentCount { get; set; }

    [JsonPropertyName(@"scores_pinned_count")]
    public int ScoresPinnedCount { get; set; }

    [JsonPropertyName(@"beatmap_playcounts_count")]
    public int BeatmapPlayCountsCount { get; set; }

    [JsonPropertyName(@"playstyle")]
    public string[] Playstyle { get; set; }

    [JsonPropertyName(@"playmode")]
    public string PlayMode { get; set; }

    [JsonPropertyName(@"profile_order")]
    public string[] ProfileOrder { get; set; }

    [JsonPropertyName(@"kudosu")]
    public KudosuCount Kudosu { get; set; }

    [JsonPropertyName(@"statistics")]
    public UserStatistics Statistics { get; set; }

    [JsonPropertyName(@"rank_history")]
    public StatisticsRankHistory RankHistory { get; set; }

    [JsonPropertyName("badges")]
    public Badge[] Badges { get; set; }

    [JsonPropertyName("user_achievements")]
    public UserAchievement[] Achievements { get; set; }

    [JsonPropertyName("monthly_playcounts")]
    public UserHistoryCount[] MonthlyPlayCounts { get; set; }

    [JsonPropertyName("replays_watched_counts")]
    public UserHistoryCount[] ReplaysWatchedCounts { get; set; }

    [JsonPropertyName("statistics_rulesets")]
    public Dictionary<string, UserStatistics> RulesetsStatistics { get; set; }

    public class CountryClass
    {
        /// <summary>
        ///     The name of this country.
        /// </summary>
        [JsonPropertyName(@"name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Two-letter flag acronym (ISO 3166 standard)
        /// </summary>
        [JsonPropertyName(@"code")]
        public string FlagName { get; set; }
    }

    public class UserCover
    {
        [JsonPropertyName(@"custom_url")]
        public string CustomUrl { get; set; }

        [JsonPropertyName(@"url")]
        public string Url { get; set; }

        [JsonPropertyName(@"id")]
        public int? Id { get; set; }
    }

    public class KudosuCount
    {
        [JsonPropertyName(@"total")]
        public int Total { get; set; }

        [JsonPropertyName(@"available")]
        public int Available { get; set; }
    }

    public class StatisticsRankHistory
    {
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("data")]
        public int[] Data { get; set; }
    }

    public class Badge
    {
        [JsonPropertyName("awarded_at")]
        public DateTimeOffset AwardedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
    }

    public class UserAchievement
    {
        [JsonPropertyName("achievement_id")]
        public int Id { get; set; }

        [JsonPropertyName("achieved_at")]
        public DateTimeOffset AchievedAt { get; set; }
    }

    public class UserHistoryCount
    {
        [JsonPropertyName("start_date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("count")]
        public long Count { get; set; }
    }
}
