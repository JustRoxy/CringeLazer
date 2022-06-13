using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Entities;

[Collection("users")]
public class User : IEntity
{
    public User()
    {
        this.InitOneToMany(() => Friends);
    }

    [Field(@"username")]
    public string Username { get; set; }

    [Field(@"password")]
    public string Password { get; set; }

    [Field("Email")]
    public string Email { get; set; }

    public Many<User> Friends { get; set; }

    #region Osu Data
    [Field(@"join_date")]
    public DateTime JoinDate { get; set; }

    [Field(@"previous_usernames")]
    public string[] PreviousUsernames { get; set; }

    [Field(@"country")]
    public CountryClass Country { get; set; }

    [Field(@"profile_colour")]
    public string Colour { get; set; }

    [Field(@"avatar_url")]
    public string AvatarUrl { get; set; }

    [Field(@"cover_url")]
    [Ignore]
    public string CoverUrl
    {
        get => Cover?.Url;
        set => Cover = new UserCover { Url = value };
    }

    [Field(@"cover")]
    public UserCover Cover { get; set; }

    [Field(@"is_admin")]
    public bool IsAdmin { get; set; }

    [Field(@"is_supporter")]
    public bool IsSupporter { get; set; }

    [Field(@"support_level")]
    public int SupportLevel { get; set; }

    [Field(@"is_gmt")]
    public bool IsGMT { get; set; }

    [Field(@"is_qat")]
    public bool IsQAT { get; set; }

    [Field(@"is_bng")]
    public bool IsBNG { get; set; }

    [Field(@"is_bot")]
    public bool IsBot { get; set; }

    [Field(@"is_active")]
    public bool Active { get; set; }

    [Field(@"is_online")]
    public bool IsOnline { get; set; }

    [Field(@"pm_friends_only")]
    public bool PMFriendsOnly { get; set; }

    [Field(@"interests")]
    public string Interests { get; set; }

    [Field(@"occupation")]
    public string Occupation { get; set; }

    [Field(@"title")]
    public string Title { get; set; }

    [Field(@"location")]
    public string Location { get; set; }

    [Field(@"last_visit")]
    public DateTime? LastVisit { get; set; }

    [Field(@"twitter")]
    public string Twitter { get; set; }

    [Field(@"discord")]
    public string Discord { get; set; }

    [Field(@"website")]
    public string Website { get; set; }

    [Field(@"post_count")]
    public int PostCount { get; set; }

    [Field(@"comments_count")]
    public int CommentsCount { get; set; }

    [Field(@"follower_count")]
    public int FollowerCount { get; set; }

    [Field(@"mapping_follower_count")]
    public int MappingFollowerCount { get; set; }

    [Field(@"favourite_beatmapset_count")]
    public int FavouriteBeatmapsetCount { get; set; }

    [Field(@"graveyard_beatmapset_count")]
    public int GraveyardBeatmapsetCount { get; set; }

    [Field(@"loved_beatmapset_count")]
    public int LovedBeatmapsetCount { get; set; }

    [Field(@"ranked_beatmapset_count")]
    public int RankedBeatmapsetCount { get; set; }

    [Field(@"pending_beatmapset_count")]
    public int PendingBeatmapsetCount { get; set; }

    [Field(@"guest_beatmapset_count")]
    public int GuestBeatmapsetCount { get; set; }

    [Field(@"scores_best_count")]
    public int ScoresBestCount { get; set; }

    [Field(@"scores_first_count")]
    public int ScoresFirstCount { get; set; }

    [Field(@"scores_recent_count")]
    public int ScoresRecentCount { get; set; }

    [Field(@"scores_pinned_count")]
    public int ScoresPinnedCount { get; set; }

    [Field(@"beatmap_playcounts_count")]
    public int BeatmapPlayCountsCount { get; set; }

    [Field(@"playstyle")]
    public string[] Playstyle { get; set; }

    [Field(@"playmode")]
    public string PlayMode { get; set; }

    [Field(@"profile_order")]
    public string[] ProfileOrder { get; set; }

    [Field(@"kudosu")]
    public KudosuCount Kudosu { get; set; }

    [Field(@"statistics")]
    public UserStatistics Statistics { get; set; }


    [Field(@"rank_history")]
    public StatisticsRankHistory RankHistory { get; set; }

    [Field("badges")]
    public Badge[] Badges { get; set; }

    [Field("user_achievements")]
    public UserAchievement[] Achievements { get; set; }

    [Field("monthly_playcounts")]
    public UserHistoryCount[] MonthlyPlayCounts { get; set; }

    [Field("replays_watched_counts")]
    public UserHistoryCount[] ReplaysWatchedCounts { get; set; }

    [Field("statistics_rulesets")]
    public Dictionary<string, UserStatistics> RulesetsStatistics { get; set; }

    public class CountryClass
    {
        /// <summary>
        ///     The name of this country.
        /// </summary>
        [Field(@"name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Two-letter flag acronym (ISO 3166 standard)
        /// </summary>
        [Field(@"code")]
        public string FlagName { get; set; }
    }

    public class UserCover
    {
        [Field(@"custom_url")]
        public string CustomUrl { get; set; }

        [Field(@"url")]
        public string Url { get; set; }

        [Field(@"id")]
        public int? Id { get; set; }
    }

    public class KudosuCount
    {
        [Field(@"total")]
        public int Total { get; set; }

        [Field(@"available")]
        public int Available { get; set; }
    }

    public class StatisticsRankHistory
    {
        [Field("mode")]
        public string Mode { get; set; }

        [Field("data")]
        public int[] Data { get; set; }
    }

    public class Badge
    {
        [Field("awarded_at")]
        public DateTimeOffset AwardedAt { get; set; }

        [Field("description")]
        public string Description { get; set; }

        [Field("image_url")]
        public string ImageUrl { get; set; }
    }

    public class UserAchievement
    {
        [Field("achievement_id")]
        public int Id { get; set; }

        [Field("achieved_at")]
        public DateTimeOffset AchievedAt { get; set; }
    }

    public class UserHistoryCount
    {
        [Field("start_date")]
        public DateTime Date { get; set; }

        [Field("count")]
        public long Count { get; set; }
    }

    #endregion

    public string GenerateNewID()
    {
        return DB.NextSequentialNumberAsync<User>().Result.ToString();
    }

    [BsonId]
    public string ID
    {
        get;
        set;
    }
}
