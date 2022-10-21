using CringeLazer.Core.Enums;
using CringeLazer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CringeLazer.Application.Database;

public class CringeContext : DbContext
{
    static CringeContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Countries>();
    }
    public CringeContext(DbContextOptions<CringeContext> options) : base(options) { }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<SessionModel> Sessions { get; set; }

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

        var user = modelBuilder.Entity<UserModel>();
        user.ToTable("user")
            .HasKey(x => x.UserId);

        user.HasMany(x => x.Sessions)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.Cascade);

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

        user.Property(x => x.PMFriendsOnly).IsRequired().HasColumnName("pm_friends_only");
        user.Property(x => x.Interests).HasColumnName("interests");
        user.Property(x => x.Occupation).HasColumnName("occupation");
        user.Property(x => x.Title).HasColumnName("title");
        user.Property(x => x.Location).HasColumnName("location");
        user.Property(x => x.Twitter).HasColumnName("twitter");
        user.Property(x => x.Discord).HasColumnName("discord");
        user.Property(x => x.Website).HasColumnName("website");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MapUserModel(modelBuilder);
        MapSessions(modelBuilder);
    }
}
