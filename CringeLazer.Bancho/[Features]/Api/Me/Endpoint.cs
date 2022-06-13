using Mapster;

namespace CringeLazer.Bancho._Features_.Api.Me;

public class Endpoint : Endpoint<RequestClaim, Contracts.User>
{
    public override void Configure()
    {
        Get("/api/v2/me");
    }

    public override async Task HandleAsync(RequestClaim req, CancellationToken ct)
    {
        var user = await Data.GetData(req.Id, ct);
        if (user is null)
        {
            await SendUnauthorizedAsync();
            return;
        }

        await SendOkAsync(user.Adapt<Contracts.User>());
    }
}
