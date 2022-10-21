using CringeLazer.Application.Database;
using CringeLazer.Core.Enums;
using CringeLazer.Core.Models;
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
            IsActive = true
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
}
