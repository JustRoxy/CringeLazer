using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Domain;

[Collection("users")]
public class User : IEntity
{
    static User()
    {
        DB.Index<User>()
            .Key(x => x.Username, KeyType.Ascending)
            .Option(x => x.Unique = true)
            .CreateAsync();
    }
    public User()
    {
        this.InitOneToMany(() => Friends);
    }

    [BsonId]
    public ulong Id { get; set; }

    [Field("username")]
    public string Username { get; set; }

    [Field("password")]
    public string Password { get; set; }

    [Field("email")]
    public string Email { get; set; }

    [Field("joined_channels")]
    public List<ulong> JoinedChannels { get; set; }

    public Many<User> Friends { get; set; }

    #region Osu Data
    [Field("JoinDate")]
    public DateTime JoinDate { get; set; }

    [Field("PreviousUsernames")]
    public string[] PreviousUsernames { get; set; }

    [Ignore]
    public string CountryCode => Country.FlagName;

    [Field("Country")]
    public CountryClass Country { get; set; }

    [Field("ProfileColour")]
    public string ProfileColour { get; set; }

    [Field("AvatarUrl")]
    public string AvatarUrl { get; set; }

    [Ignore]
    public string CoverUrl
    {
        get => Cover?.Url;
        set => Cover = new UserCover { Url = value };
    }

    [Field("Cover")]
    public UserCover Cover { get; set; }

    [Field("IsAdmin")]
    public bool IsAdmin { get; set; }

    [Field("IsSupporter")]
    public bool IsSupporter { get; set; }

    [Field("SupportLevel")]
    public int SupportLevel { get; set; }

    [Field("IsGMT")]
    public bool IsGMT { get; set; }

    [Field("IsQAT")]
    public bool IsQAT { get; set; }

    [Field("IsBNG")]
    public bool IsBNG { get; set; }

    [Field("IsBot")]
    public bool IsBot { get; set; }

    [Field("IsActive")]
    public bool IsActive { get; set; }

    [Field("IsOnline")]
    public bool IsOnline { get; set; }

    [Field("PMFriendsOnly")]
    public bool PMFriendsOnly { get; set; }

    [Field("Interests")]
    public string Interests { get; set; }

    [Field("Occupation")]
    public string Occupation { get; set; }

    [Field("Title")]
    public string Title { get; set; }

    [Field("Location")]
    public string Location { get; set; }

    [Field("LastVisit")]
    public DateTime? LastVisit { get; set; }

    [Field("Twitter")]
    public string Twitter { get; set; }

    [Field("Discord")]
    public string Discord { get; set; }

    [Field("Website")]
    public string Website { get; set; }

    [Field("PostCount")]
    public int PostCount { get; set; }

    [Field("CommentsCount")]
    public int CommentsCount { get; set; }

    [Field("FollowerCount")]
    public int FollowerCount { get; set; }

    [Field("MappingFollowerCount")]
    public int MappingFollowerCount { get; set; }

    [Field("FavouriteBeatmapsetCount")]
    public int FavouriteBeatmapsetCount { get; set; }

    [Field("GraveyardBeatmapsetCount")]
    public int GraveyardBeatmapsetCount { get; set; }

    [Field("LovedBeatmapsetCount")]
    public int LovedBeatmapsetCount { get; set; }

    [Field("RankedBeatmapsetCount")]
    public int RankedBeatmapsetCount { get; set; }

    [Field("PendingBeatmapsetCount")]
    public int PendingBeatmapsetCount { get; set; }

    [Field("GuestBeatmapsetCount")]
    public int GuestBeatmapsetCount { get; set; }

    [Field("ScoresBestCount")]
    public int ScoresBestCount { get; set; }

    [Field("ScoresFirstCount")]
    public int ScoresFirstCount { get; set; }

    [Field("ScoresRecentCount")]
    public int ScoresRecentCount { get; set; }

    [Field("ScoresPinnedCount")]
    public int ScoresPinnedCount { get; set; }

    [Field("BeatmapPlayCountsCount")]
    public int BeatmapPlayCountsCount { get; set; }

    [Field("Playstyle")]
    public string[] Playstyle { get; set; }

    [Field("PlayMode")]
    public string PlayMode { get; set; }

    [Field("ProfileOrder")]
    public string[] ProfileOrder { get; set; }

    [Field("Kudosu")]
    public KudosuCount Kudosu { get; set; }

    [Field("Statistics")]
    public UserStatistics Statistics { get; set; }

    [Field("TaikoStatistics")]
    public UserStatistics TaikoStatistics { get; set; }

    [Field("FruitsStatistics")]
    public UserStatistics FruitsStatistics { get; set; }

    [Field("ManiaStatistics")]
    public UserStatistics ManiaStatistics { get; set; }

    [Field("RankHistory")]
    public StatisticsRankHistory RankHistory { get; set; }

    [Field("List")]
    public List<Badge> Badges { get; set; }

    [Field("UserAchievements")]
    public List<UserAchievement> UserAchievements { get; set; }

    [Field("MonthlyPlayCounts")]
    public List<UserHistoryCount> MonthlyPlayCounts { get; set; }

    [Field("UserHistoryCount")]
    public List<UserHistoryCount> ReplaysWatchedCounts { get; set; }

    public class CountryClass
    {
        /// <summary>
        ///     The name of this country.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        ///     Two-letter flag acronym (ISO 3166 standard)
        /// </summary>
        public string FlagName { get; set; }
    }

    public class UserCover
    {
        public int Id { get; set; }
        public string CustomUrl { get; set; }
        public string Url { get; set; }
    }

    public class KudosuCount
    {
        public int Total { get; set; }
        public int Available { get; set; }
    }

    public class StatisticsRankHistory
    {
        public string Mode { get; set; }
        public int[] Data { get; set; }
    }

    public class Badge
    {
        public DateTime AwardedAt { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class UserAchievement
    {
        public int AchievementId { get; set; }
        public DateTime AchievedAt { get; set; }
    }

    public class UserHistoryCount
    {
        public DateTime Date { get; set; }
        public long Count { get; set; }
    }
    #endregion

    public string GenerateNewID()
    {
        throw new NotImplementedException();
    }

    public string ID { get => Id.ToString(); set => Id = ulong.Parse(value); }
}
