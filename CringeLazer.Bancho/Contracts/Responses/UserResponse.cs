using CringeLazer.Core.Enums;
using CringeLazer.Core.Models.Users;
using Newtonsoft.Json;

namespace CringeLazer.Bancho.Contracts.Responses;

public class UserResponse
{
    [JsonProperty(@"id")]
    public long UserId { get; set; }

    [JsonProperty(@"join_date")]
    public DateTimeOffset JoinDate { get; set; }

    [JsonProperty(@"username")]
    public string Username { get; set; }

    [JsonProperty(@"previous_usernames")]
    public List<string> PreviousUsernames { get; set; }

    [JsonProperty(@"country")]
    public CountryResponse Country { get; set; }

    [JsonProperty(@"profile_colour")]
    public string Colour { get; set; }

    [JsonProperty(@"avatar_url")]
    public string AvatarUrl { get; set; }

    [JsonProperty(@"cover_url")]
    public string CoverUrl { get; set; }

    [JsonProperty(@"cover")]
    public UserCover Cover => new()
    {
        Url = CoverUrl
    };

    public class UserCover
    {
        [JsonProperty(@"custom_url")]
        public string CustomUrl { get; set; }

        [JsonProperty(@"url")]
        public string Url { get; set; }

        [JsonProperty(@"id")]
        public int? Id { get; set; }
    }

    [JsonProperty(@"is_admin")]
    public bool IsAdmin { get; set; }

    [JsonProperty(@"is_supporter")]
    public bool IsSupporter { get; set; }

    [JsonProperty(@"support_level")]
    public int SupportLevel { get; set; }

    [JsonProperty(@"is_gmt")]
    public bool IsGMT { get; set; }

    [JsonProperty(@"is_qat")]
    public bool IsQAT { get; set; }

    [JsonProperty(@"is_bng")]
    public bool IsBNG { get; set; }

    [JsonProperty(@"is_bot")]
    public bool IsBot { get; set; }

    [JsonProperty(@"is_active")]
    public bool IsActive { get; set; }

    [JsonProperty(@"is_online")]
    public bool IsOnline => DateTime.UtcNow - LastVisit < TimeSpan.FromMinutes(5);

    [JsonProperty(@"pm_friends_only")]
    public bool PMFriendsOnly { get; set; }

    [JsonProperty(@"interests")]
    public string Interests { get; set; }

    [JsonProperty(@"occupation")]
    public string Occupation { get; set; }

    [JsonProperty(@"title")]
    public string Title { get; set; }

    [JsonProperty(@"location")]
    public string Location { get; set; }

    [JsonProperty(@"last_visit")]
    public DateTimeOffset LastVisit { get; set; }

    [JsonProperty(@"twitter")]
    public string Twitter { get; set; }

    [JsonProperty(@"discord")]
    public string Discord { get; set; }

    [JsonProperty(@"website")]
    public string Website { get; set; }

    [JsonProperty(@"post_count")]
    public int PostCount { get; set; }

    [JsonProperty(@"comments_count")]
    public int CommentsCount { get; set; }

    [JsonProperty(@"follower_count")]
    public int FollowerCount { get; set; }

    [JsonProperty(@"mapping_follower_count")]
    public int MappingFollowerCount { get; set; }

    [JsonProperty(@"favourite_beatmapset_count")]
    public int FavouriteBeatmapsetCount { get; set; }

    [JsonProperty(@"graveyard_beatmapset_count")]
    public int GraveyardBeatmapsetCount { get; set; }

    [JsonProperty(@"loved_beatmapset_count")]
    public int LovedBeatmapsetCount { get; set; }

    [JsonProperty(@"ranked_beatmapset_count")]
    public int RankedBeatmapsetCount { get; set; }

    [JsonProperty(@"pending_beatmapset_count")]
    public int PendingBeatmapsetCount { get; set; }

    [JsonProperty(@"guest_beatmapset_count")]
    public int GuestBeatmapsetCount { get; set; }

    [JsonProperty(@"scores_best_count")]
    public int ScoresBestCount { get; set; }

    [JsonProperty(@"scores_first_count")]
    public int ScoresFirstCount { get; set; }

    [JsonProperty(@"scores_recent_count")]
    public int ScoresRecentCount { get; set; }

    [JsonProperty(@"scores_pinned_count")]
    public int ScoresPinnedCount { get; set; }

    [JsonProperty(@"beatmap_playcounts_count")]
    public int BeatmapPlayCountsCount { get; set; }

    [JsonProperty(@"playstyle")]
    public List<Playstyles> PlayStyle { get; set; }

    [JsonProperty(@"playmode")]
    public Gamemode PlayMode { get; set; }

    [JsonProperty(@"profile_order")]
    public List<ProfilePage> ProfileOrder { get; set; }

    [JsonProperty(@"kudosu")]
    public KudosuCount Kudosu { get; set; }

    public class KudosuCount
    {
        [JsonProperty(@"total")]
        public int Total { get; set; }

        [JsonProperty(@"available")]
        public int Available { get; set; }
    }

    [JsonProperty(@"statistics")]
    public StatisticsResponse Statistics { get; set; }

    [JsonProperty(@"rank_history")]
    public RankHistoryResponse RankHistory
    {
        get
        {
            if (Statistics is not null)
            {
                return new RankHistoryResponse
                {
                    Data = Statistics.RankHistory,
                    Mode = Statistics.Gamemode
                };
            }

            return null;
        }
    }

    [JsonProperty("badges")]
    public HashSet<BadgeResponse> Badges { get; set; }

    [JsonProperty("user_achievements")]
    public HashSet<AchievementResponse> Achievements { get; set; }

    [JsonProperty("monthly_playcounts")]
    public List<History> MonthlyPlayCounts { get; set; }

    [JsonProperty("replays_watched_counts")]
    public List<History> ReplaysWatchedCounts { get; set; }

    public class AchievementResponse
    {
        [JsonProperty("achievement_id")]
        public int AchievementId { get; set; }

        [JsonProperty("achieved_at")]
        public DateTimeOffset AchievedAt { get; set; }
    }

    public class BadgeResponse
    {
        [JsonProperty("awarded_at")]
        public DateTimeOffset AwardedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }

    public class CountryResponse
    {
        [JsonProperty(@"code")]
        public string Code { get; set; }
    }

    public class RankHistoryResponse
    {
        [JsonProperty("mode")]
        public Gamemode Mode { get; set; }

        [JsonProperty("data")]
        public List<int> Data { get; set; }
    }
}
