using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Auth.User.Me;

public static class Data
{
    public static async Task<Entities.User> GetData(string id, CancellationToken token)
    {
        return await DB.Find<Entities.User>()
            .MatchID(id)
            .ExecuteSingleAsync(token);
    }
}
