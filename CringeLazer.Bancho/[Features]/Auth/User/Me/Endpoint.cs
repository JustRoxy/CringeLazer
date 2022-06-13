using Mapster;

namespace CringeLazer.Bancho._Features_.Auth.User.Me;

public class Endpoint : Endpoint<Request, Contracts.User>
{
    public override void Configure()
    {
        Get("/api/v2/me");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = await Data.GetData(req.Id, ct);

        await SendOkAsync(user.Adapt<Contracts.User>());
    }
}
