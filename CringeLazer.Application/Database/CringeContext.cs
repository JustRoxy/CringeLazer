using CringeLazer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Application.Database;

public class CringeContext : DbContext
{
    public CringeContext(DbContextOptions<CringeContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }

    private void MapUserModel(ModelBuilder modelBuilder)
    {

        modelBuilder.UseSerialColumns();

        var user = modelBuilder.Entity<UserModel>();
        user.ToTable("user")
            .HasKey(x => x.UserId);
        user.HasIndex(x => x.RefreshToken)
            .IsUnique();

        user.Property(x => x.UserId).IsRequired().HasColumnName("user_id");
        user.Property(x => x.Username).IsRequired().HasColumnName("username");
        user.Property(x => x.Password).HasColumnName("password");
        user.Property(x => x.RefreshToken).HasColumnName("refresh_token");
        user.Property(x => x.Email).IsRequired().HasColumnName("email");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MapUserModel(modelBuilder);
    }
}
