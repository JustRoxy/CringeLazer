using Mapster;

namespace CringeLazer.Bancho._Features_.Api.Me;

public class Endpoint : Endpoint<RequestClaim, Contracts.User>
{
    public override void Configure()
    {
        Get("me");
    }

    public override async Task HandleAsync(RequestClaim req, CancellationToken ct)
    {
        var data = await Data.GetData(req.Id, ct);
        if (data is null)
        {
            await SendUnauthorizedAsync();
            return;
        }

        await SendOkAsync(data.Adapt<Contracts.User>());
    }
}
