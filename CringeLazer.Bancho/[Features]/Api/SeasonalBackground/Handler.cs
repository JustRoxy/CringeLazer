using CringeLazer.Bancho.Data;
using CringeLazer.Bancho.Helpers;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public class Handler : IRequestHandler<Request, Result<SeasonalBackgroundsResponse>>
{
    private readonly CringeContext _context;

    public Handler(CringeContext context)
    {
        _context = context;
    }

    public async Task<SeasonalBackgroundsResponse> GetCurrentSeasonalBackgrounds()
    {
        return await _context
            .Seasons
            .Where(x => x.EndsAt > DateTime.UtcNow)
            .ProjectToType<SeasonalBackgroundsResponse>()
            .FirstOrDefaultAsync();
    }

    public async Task<Result<SeasonalBackgroundsResponse>> Handle(Request _, CancellationToken cancellationToken)
    {
        var season = await GetCurrentSeasonalBackgrounds();
        if (season is null)
        {
            return Result<SeasonalBackgroundsResponse>.Error("No more coomer anime girls for you", ErrorType.NotFound);
        }

        return Result<SeasonalBackgroundsResponse>.Some(season);
    }
}
