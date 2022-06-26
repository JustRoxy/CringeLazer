using CringeLazer.Bancho.Domain;
using Mapster;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public static class Data
{
    public static async Task<SeasonalBackgroundsResponse> GetCurrentSeasonalBackgrounds(CancellationToken token)
    {
        return (await DB.Find<Season>()
            .Match(x => x.EndsAt > DateTime.UtcNow)
            .ExecuteFirstAsync(token))
            .Adapt<SeasonalBackgroundsResponse>();
    }
}
