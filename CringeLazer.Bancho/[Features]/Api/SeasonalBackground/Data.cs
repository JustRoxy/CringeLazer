using CringeLazer.Bancho.Entities;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public static class Data
{
    public static async Task<Season> GetCurrentSeasonalBackgrounds()
    {
        return await DB.Find<Season>()
            .Match(x => x.EndsIn > DateTime.UtcNow)
            .ExecuteFirstAsync();
    }
}
