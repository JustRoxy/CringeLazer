namespace CringeLazer.Core.Services;

public interface IOnlineUsers
{
    public Task Online(string userId, TimeSpan? expiration = null);
    public Task Offline(string userId);
    public Task<bool> IsOnline(string userId);
    public Task Ping(string userId);
}
