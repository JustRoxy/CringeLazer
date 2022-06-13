using CringeLazer.Bancho.Entities;
using Mapster;

namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public class Endpoint : EndpointWithoutRequest<SeasonalBackgroundsResponse>
{
    public override void Configure()
    {
        Get("/api/v2/seasonal-backgrounds");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var season = await Data.GetCurrentSeasonalBackgrounds() ?? new Season();

        await SendOkAsync(season.Adapt<SeasonalBackgroundsResponse>());
    }
}
