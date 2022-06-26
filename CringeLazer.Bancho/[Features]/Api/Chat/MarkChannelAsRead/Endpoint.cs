using CringeLazer.Bancho.Data;

namespace CringeLazer.Bancho._Features_.Api.Chat.MarkChannelAsRead;

public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Put("/chat/channels/{channel}/mark-as-read/{message}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await ChatChannelData.UserContains(req.Channel, req.Id))
        {
            ThrowError("You're not in the channel");
            return;
        }

        await Data.MarkChannelAsRead(req, ct);
        await SendNoContentAsync();
    }
}
