using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Domain;

[Collection("users")]
public class User : IEntity
{
    public User()
    {
        this.InitOneToMany(() => Friends);
    }

    [BsonId]
    public ulong Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public List<ulong> JoinedChannels { get; set; }
    public Many<User> Friends { get; set; }

    #region Osu Data
    public DateTime JoinDate { get; set; }
    public string[] PreviousUsernames { get; set; }

    [Ignore]
    public string CountryCode => Country.FlagName;

    public CountryClass Country { get; set; }
    public string ProfileColour { get; set; }
    public string AvatarUrl { get; set; }

    public string CoverUrl
    {
        get => Cover?.Url;
        set => Cover = new UserCover { Url = value };
    }

    public UserCover Cover { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsSupporter { get; set; }
    public int SupportLevel { get; set; }
    public bool IsGMT { get; set; }
    public bool IsQAT { get; set; }
    public bool IsBNG { get; set; }
    public bool IsBot { get; set; }
    public bool Active { get; set; }
    public bool IsOnline { get; set; }
    public bool PMFriendsOnly { get; set; }
    public string Interests { get; set; }
    public string Occupation { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime? LastVisit { get; set; }
    public string Twitter { get; set; }
    public string Discord { get; set; }
    public string Website { get; set; }
    public int PostCount { get; set; }
    public int CommentsCount { get; set; }
    public int FollowerCount { get; set; }
    public int MappingFollowerCount { get; set; }
    public int FavouriteBeatmapsetCount { get; set; }
    public int GraveyardBeatmapsetCount { get; set; }
    public int LovedBeatmapsetCount { get; set; }
    public int RankedBeatmapsetCount { get; set; }
    public int PendingBeatmapsetCount { get; set; }
    public int GuestBeatmapsetCount { get; set; }
    public int ScoresBestCount { get; set; }
    public int ScoresFirstCount { get; set; }
    public int ScoresRecentCount { get; set; }
    public int ScoresPinnedCount { get; set; }
    public int BeatmapPlayCountsCount { get; set; }
    public string[] Playstyle { get; set; }
    public string PlayMode { get; set; }
    public string[] ProfileOrder { get; set; }
    public KudosuCount Kudosu { get; set; }
    public UserStatistics Statistics { get; set; }

    public UserStatistics TaikoStatistics { get; set; }
    public UserStatistics FruitsStatistics { get; set; }
    public UserStatistics ManiaStatistics { get; set; }

    public StatisticsRankHistory RankHistory { get; set; }
    public List<Badge> Badges { get; set; }
    public List<UserAchievement> UserAchievements { get; set; }
    public List<UserHistoryCount> MonthlyPlayCounts { get; set; }
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
