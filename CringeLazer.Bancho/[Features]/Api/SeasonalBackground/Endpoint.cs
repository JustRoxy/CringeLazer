namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public class Endpoint : EndpointWithoutRequest<SeasonalBackgroundsResponse>
{
    public override void Configure()
    {
        Get("seasonal-backgrounds");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var season = await Data.GetCurrentSeasonalBackgrounds(ct);
        if (season is null)
        {
            await SendOkAsync(new SeasonalBackgroundsResponse());
            return;
        }

        await SendOkAsync(season);
    }
}
