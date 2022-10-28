using CringeLazer.Application.Database;
using CringeLazer.Core.Services;
using Microsoft.Extensions.Caching.Memory;

namespace CringeLazer.Application.Services;

public class OnlineUsers : IOnlineUsers
{
    private readonly IMemoryCache _memoryCache;
    private readonly CringeContext _context;

    public OnlineUsers(IMemoryCache memoryCache, CringeContext context)
    {
        _memoryCache = memoryCache;
        _context = context;
    }

    public Task Online(string userId, TimeSpan? expiration = null)
    {
        _memoryCache.Set(userId, DateTime.UtcNow, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration
        });

        return Task.CompletedTask;
    }

    public Task Offline(string userId)
    {
        _memoryCache.Remove(userId);

        return Task.CompletedTask;
    }

    public Task<bool> IsOnline(string userId)
    {
        var exist = _memoryCache.TryGetValue(userId, out _);

        return Task.FromResult(exist);
    }

    public async Task Ping(string userId)
    {
        if (!long.TryParse(userId, out var id))
        {
            return;
        }

        var now = DateTime.UtcNow;

        var user = _context.Users.Single(x => x.UserId == id);
        user.LastVisit = now;

        await _context.SaveChangesAsync();
    }
}
