namespace CringeLazer.Bancho._Features_.Api.Rankings.Performance;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("rankings/osu/performance");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        await SendOkAsync(await Data.GetUsers(req.Page, ct));
    }
}
