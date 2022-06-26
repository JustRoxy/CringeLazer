using CringeLazer.Bancho.Contracts.Chat;
using CringeLazer.Bancho.Data;

namespace CringeLazer.Bancho._Features_.Api.Chat.GetChannel;

public class Endpoint : Endpoint<Request, ChatChannel>
{
    public override void Configure()
    {
        Get("/chat/channels/{channel}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await ChatChannelData.UserContains(req.ChannelId, req.Id))
        {
            ThrowError("You're not in the channel");
            return;
        }

        await SendOkAsync(await ChatChannelData.GetChannel(req.ChannelId, req.Id));
    }
}
