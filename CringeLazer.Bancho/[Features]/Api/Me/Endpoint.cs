using MediatR;

namespace CringeLazer.Bancho._Features_.Api.Me;

public class Endpoint : Endpoint<Request, Contracts.User>
{
    public IMediator Mediator { get; set; }
    public override void Configure()
    {
        Get("/api/v2/me");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var result = await Mediator.Send(req, ct);

        if (!result.IsError)
        {
            await SendOkAsync(result.Value);
            return;
        }

        await SendUnauthorizedAsync();
    }
}
