using CringeLazer.Bancho.Domain;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Auth.User.Register;

public static class Data
{
    public static async Task<bool> UserExists(Request req, CancellationToken ct)
    {
        return await DB.Find<Domain.User>()
            .Match(x => x.Username == req.Username || x.Email == req.Email)
            .ExecuteAnyAsync(ct);
    }

    public static async Task AddUser(Request req, CancellationToken ct)
    {
        var user = new Domain.User
        {
            Id = await DB.NextSequentialNumberAsync<Domain.User>(ct),
            Email = req.Email,
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password),
            Username = req.Username,

            JoinDate = DateTime.UtcNow,
            PreviousUsernames = new[]
            {
                "Vacman"
            },
            Country = new Domain.User.CountryClass
            {
                FlagName = "BR",
                FullName = "Fuckyou"
            },
            ProfileColour = "#FFD800",
            AvatarUrl = "https://a.stanr.info/sadhjfbsjdfh",
            Cover = new Domain.User.UserCover
            {
                CustomUrl = "https://a.stanr.info/sadhjfbsjdfh",
                Id = 4,
                Url = "https://a.stanr.info/sadhjfbsjdfh"
            },
            IsAdmin = true,
            IsSupporter = false,
            SupportLevel = 0,
            IsGMT = false,
            IsQAT = false,
            IsBNG = false,
            Active = true,
            IsOnline = true,
            PMFriendsOnly = false,
            Interests = null,
            Occupation = null,
            Title = null,
            Location = null,
            LastVisit = DateTime.UtcNow,
            Twitter = null,
            Discord = null,
            Website = null,
            PostCount = 0,
            CommentsCount = 0,
            FollowerCount = 0,
            MappingFollowerCount = 0,
            FavouriteBeatmapsetCount = 0,
            GraveyardBeatmapsetCount = 0,
            LovedBeatmapsetCount = 0,
            RankedBeatmapsetCount = 0,
            PendingBeatmapsetCount = 0,
            GuestBeatmapsetCount = 0,
            ScoresBestCount = 0,
            ScoresFirstCount = 0,
            ScoresRecentCount = 0,
            ScoresPinnedCount = 0,
            BeatmapPlayCountsCount = 0,
            PlayMode = "osu",
            ProfileOrder = new[]
            {
                "me",
                "recent_activity",
                "beatmaps",
                "historical",
                "kudosu",
                "top_ranks",
                "medals"
            },
            Kudosu = new Domain.User.KudosuCount
            {
                Available = 0,
                Total = 0,
            },
            Statistics = new UserStatistics
            {
                Level = new UserStatistics.LevelInfo
                {
                    Current = 0,
                    Progress = 0
                },
                IsRanked = true,
                GlobalRank = 1000,
                CountryRank = 2000,
                Pp = 727.27m,
                RankedScore = 0,
                Accuracy = 0,
                PlayCount = 0,
                PlayTime = null,
                TotalScore = 0,
                TotalHits = 0,
                MaxCombo = 0,
                ReplaysWatched = 0,
                GradesCount = new UserStatistics.Grades
                {
                    SS = 0,
                    A = 0,
                    S = 0,
                    SPlus = 0,
                    SSPlus = 0
                }
            },
            IsBot = false
        };

        await user.SaveAsync(cancellation: ct);
    }
}
