using CringeLazer.Bancho.Entities;
using MongoDB.Driver;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Friends;

public static class Data
{
    public static async Task<List<User>> GetFriends(string id, CancellationToken token)
    {
        return await DB.Entity<User>(id)
            .Friends
            .ChildrenFluent()
            .ToListAsync(token);
    }
}
