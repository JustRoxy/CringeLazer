using CringeLazer.Application.Database;
using CringeLazer.Core.Enums;
using CringeLazer.Core.Models.Statistics;
using CringeLazer.Core.Models.Users;
using CringeLazer.Core.Services;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Application.Services;

public class UserService : IUserService
{
    private readonly CringeContext _context;

    public UserService(CringeContext context)
    {
        _context = context;
    }

    public async Task<Result<UserModel>> Create(string username, string email, string password)
    {
        var now = DateTime.UtcNow;
        var user = new UserModel
        {
            Username = username,
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password),
            Email = email,
            Country = Countries.BR,
            PreviousUsernames = new List<string>(),
            JoinDate = now,
            LastVisit = now,
            IsActive = true,
            Kudosu = new Kudosu(),
            Badges = new List<Badge>(),
            Achievements = new List<Achievement>(),
            MonthlyPlayCounts = new List<History>(),
            ReplaysWatchedCounts = new List<History>(),
            AvatarUrl = "https://www.hdwallpaper.nu/wp-content/uploads/2015/02/funny_cat_face_pictures.jpg",
            Playmode = Gamemode.Osu,
            ProfileOrder = new List<ProfilePage>
            {
                ProfilePage.Me,
                ProfilePage.RecentActivity,
                ProfilePage.Beatmaps,
                ProfilePage.Historical,
                ProfilePage.Kudosu,
                ProfilePage.TopRanks,
                ProfilePage.Medals
            },
            Colour = "#ffff"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        foreach (var gamemode in Enum.GetValues<Gamemode>())
        {
            _context.Statistics.Add(new StatisticsModel
            {
                UserId = user.UserId,
                Gamemode = gamemode,
                Level = new LevelInfo(),
                Grades = new Grades()
            });
        }

        await _context.SaveChangesAsync();

        return user;
    }

    public Task<T> GetOne<T>(Func<IQueryable<UserModel>, IQueryable<T>> map)
    {
        return map(_context.Users).FirstOrDefaultAsync();
    }

    public Task<List<T>> GetMany<T>(Func<IQueryable<UserModel>, IQueryable<T>> map)
    {
        return map(_context.Users).ToListAsync();
    }
}
