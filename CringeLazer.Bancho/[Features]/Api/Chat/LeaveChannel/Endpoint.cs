using CringeLazer.Bancho.Data;

namespace CringeLazer.Bancho._Features_.Api.Chat.LeaveChannel;

public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Delete("/chat/channels/{channel}/users/{user}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await ChatChannelData.UserContains(req.ChannelId, req.Id))
        {
            ThrowError("You're not in the chat");
            return;
        }

        await Data.Leave(req.ChannelId, req.Id);
        await SendNoContentAsync();
    }
}
