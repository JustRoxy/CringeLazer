using CringeLazer.Bancho.Domain;
using MongoDB.Driver;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.GetFriends;

public static class Data
{
    public static async Task<List<User>> GetFriends(ulong id, CancellationToken token)
    {
        return await DB.Entity<User>(id.ToString())
            .Friends
            .ChildrenFluent()
            .ToListAsync(cancellationToken: token);
    }
}
