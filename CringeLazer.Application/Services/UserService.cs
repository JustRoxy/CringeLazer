using CringeLazer.Application.Database;
using CringeLazer.Core.Enums;
using CringeLazer.Core.Models;
using CringeLazer.Core.Models.Statistics;
using CringeLazer.Core.Models.Users;
using CringeLazer.Core.Services;
using LanguageExt.Common;

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
            Kudosu = new Kudosu()
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
}
