using MediatR;

namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public class Endpoint : EndpointWithoutRequest<SeasonalBackgroundsResponse>
{
    public IMediator Mediator { get; set; }
    public override void Configure()
    {
        Get("/api/v2/seasonal-backgrounds");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await Mediator.Send(new Request());
        if (result.IsError)
        {
            await SendNoContentAsync();
            return;
        }

        await SendOkAsync(result.Value);
    }
}
