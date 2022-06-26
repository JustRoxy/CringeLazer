namespace CringeLazer.Bancho._Features_.Api.Chat.CreateNewPm;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/chat/new");
        AllowFormData();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (await Data.UserExists(req.TargetId, ct))
        {
            await SendOkAsync(await Data.CreateChat(req, ct));
            return;
        }

        await SendNotFoundAsync();
    }
}
