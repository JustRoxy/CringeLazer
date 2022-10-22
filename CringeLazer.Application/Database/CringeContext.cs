using CringeLazer.Core.Enums;
using CringeLazer.Core.Models;
using CringeLazer.Core.Models.Statistics;
using CringeLazer.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CringeLazer.Application.Database;

public class CringeContext : DbContext
{
    static CringeContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Countries>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Gamemode>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Playstyles>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<ProfilePage>();
    }

    public CringeContext(DbContextOptions<CringeContext> options) : base(options) { }

    public DbSet<StatisticsModel> Statistics { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<SessionModel> Sessions { get; set; }

    private void MapStatistics(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Gamemode>();
        var s = modelBuilder.Entity<StatisticsModel>()
            .ToTable("statistic");

        s.HasOne(x => x.User)
            .WithMany(x => x.Statistics)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        s.OwnsOne(x => x.Level, x =>
        {
            x.Property(z => z.Current).IsRequired().HasColumnName("level_current");
            x.Property(z => z.Progress).IsRequired().HasColumnName("level_progress");
        });

        s.OwnsOne(x => x.Grades, x =>
        {
            x.Property(z => z.A).IsRequired().HasColumnName("grades_a");
            x.Property(z => z.S).IsRequired().HasColumnName("grades_s");
            x.Property(z => z.SPlus).IsRequired().HasColumnName("grades_splus");
            x.Property(z => z.SS).IsRequired().HasColumnName("grades_ss");
            x.Property(z => z.SSPlus).IsRequired().HasColumnName("grades_ssplus");
        });

        s.HasKey(x => new { x.UserId, x.Gamemode });

        s.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
        s.Property(x => x.Gamemode).IsRequired().HasColumnName("gamemode");
        s.Property(x => x.IsRanked).IsRequired().HasColumnName("is_ranked");
        s.Property(x => x.GlobalRank).HasColumnName("global_rank");
        s.Property(x => x.CountryRank).HasColumnName("country_rank");
        s.Property(x => x.PP).HasColumnName("pp");
        s.Property(x => x.RankedScore).IsRequired().HasColumnName("ranked_score");
        s.Property(x => x.Accuracy).IsRequired().HasColumnName("accuracy");
        s.Property(x => x.PlayCount).IsRequired().HasColumnName("playcount");
        s.Property(x => x.PlayTime).HasColumnName("playtime");
        s.Property(x => x.TotalScore).IsRequired().HasColumnName("total_score");
        s.Property(x => x.TotalHits).IsRequired().HasColumnName("total_hits");
        s.Property(x => x.MaxCombo).IsRequired().HasColumnName("max_combo");
        s.Property(x => x.ReplaysWatched).IsRequired().HasColumnName("replays_watched");
        s.Property(x => x.RankHistory).HasColumnName("rank_history");
    }

    private void MapSessions(ModelBuilder modelBuilder)
    {
        var session = modelBuilder.Entity<SessionModel>()
            .ToTable("session");

        session.HasKey(x => x.SessionId);
        session.HasIndex(x => x.RefreshToken)
            .IsUnique();

        session.HasOne(x => x.User)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        session.Property(x => x.SessionId).IsRequired().UseIdentityColumn().HasColumnName("session_id");
        session.Property(x => x.RefreshToken).IsRequired().HasColumnName("refresh_token");
        session.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
    }

    private void MapUserModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Countries>();
        modelBuilder.HasPostgresEnum<Playstyles>();
        modelBuilder.HasPostgresEnum<ProfilePage>();

        var user = modelBuilder.Entity<UserModel>();
        user.ToTable("user")
            .HasKey(x => x.UserId);

        user.HasMany(x => x.Sessions)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.Cascade);

        user.OwnsOne(x => x.Kudosu, builder =>
        {
            builder.Property(x => x.Available).HasColumnName("kudosu_available");
            builder.Property(x => x.Total).HasColumnName("kudosu_total");
        });

        user.OwnsMany(x => x.Badges, builder =>
        {
            builder.ToTable("badge");

            builder.HasKey(x => x.BadgeId);
            builder.WithOwner().HasForeignKey(x => x.UserId);

            builder.Property(x => x.BadgeId).IsRequired().UseIdentityColumn().HasColumnName("badge_id");
            builder.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
            builder.Property(x => x.Description).IsRequired().HasColumnName("description");
            builder.Property(x => x.AwardedAt).IsRequired().HasColumnName("awarded_at");
            builder.Property(x => x.ImageUrl).IsRequired().HasColumnName("image_url");
        });

        user.OwnsMany(x => x.Achievements, builder =>
        {
            builder.ToTable("achievement");
            builder.WithOwner().HasForeignKey(x => x.UserId);
            builder.HasKey(x => x.AchievementAwardId);

            builder.Property(x => x.AchievementAwardId).UseIdentityColumn().HasColumnName("achievement_award_id");
            builder.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
            builder.Property(x => x.AchievementId).IsRequired().HasColumnName("achievement_id");
            builder.Property(x => x.AchievedAt).IsRequired().HasColumnName("achieved_at");
        });

        user.Property(x => x.UserId).UseIdentityColumn().IsRequired().HasColumnName("user_id");
        user.Property(x => x.Username).IsRequired().HasColumnName("username");
        user.Property(x => x.Password).IsRequired().HasColumnName("password");
        user.Property(x => x.Email).IsRequired().HasColumnName("email");
        user.Property(x => x.JoinDate).IsRequired().HasColumnName("join_date");
        user.Property(x => x.Country).IsRequired().HasColumnName("country");
        user.Property(x => x.PreviousUsernames).IsRequired().HasColumnName("previous_usernames");

        user.Property(x => x.IsAdmin).IsRequired().HasColumnName("is_admin");
        user.Property(x => x.IsSupporter).IsRequired().HasColumnName("is_supporter");
        user.Property(x => x.SupportLevel).IsRequired().HasColumnName("support_level");
        user.Property(x => x.IsGMT).IsRequired().HasColumnName("is_gmt");
        user.Property(x => x.IsQAT).IsRequired().HasColumnName("is_qat");
        user.Property(x => x.IsBNG).IsRequired().HasColumnName("is_bng");
        user.Property(x => x.IsBot).IsRequired().HasColumnName("is_bot");

        user.Property(x => x.IsActive).IsRequired().HasColumnName("is_active");
        user.Property(x => x.LastVisit).IsRequired().HasColumnName("last_visit");

        user.Property(x => x.AvatarUrl).IsRequired().HasColumnName("avatar_url");
        user.Property(x => x.CoverUrl).HasColumnName("cover_url");
        user.Property(x => x.Playstyle).HasColumnName("playstyle");
        user.Property(x => x.Playmode).IsRequired().HasColumnName("playmode");
        user.Property(x => x.ProfileOrder).HasColumnName("profile_order");
        user.Property(x => x.PMFriendsOnly).IsRequired().HasColumnName("pm_friends_only");
        user.Property(x => x.Interests).HasColumnName("interests");
        user.Property(x => x.Occupation).HasColumnName("occupation");
        user.Property(x => x.Title).HasColumnName("title");
        user.Property(x => x.Location).HasColumnName("location");
        user.Property(x => x.Twitter).HasColumnName("twitter");
        user.Property(x => x.Discord).HasColumnName("discord");
        user.Property(x => x.Website).HasColumnName("website");

        user.Property(x => x.Colour).IsRequired().HasColumnName("colour");
        user.Property(x => x.MonthlyPlayCounts).IsRequired().HasColumnType("jsonb").HasColumnName("monthly_playcounts");
        user.Property(x => x.ReplaysWatchedCounts).IsRequired().HasColumnType("jsonb").HasColumnName("replays_watched");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MapUserModel(modelBuilder);
        MapSessions(modelBuilder);
        MapStatistics(modelBuilder);
    }
}
