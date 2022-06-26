using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Me;

public static class Data
{
    public static async Task<Domain.User> GetData(ulong id, CancellationToken token)
    {
        return await DB.Find<Domain.User>()
            .Match(x => x.Id == id)
            .ExecuteFirstAsync(token);
    }
}
