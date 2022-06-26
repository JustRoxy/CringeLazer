using CringeLazer.Bancho.Contracts.Chat;
using CringeLazer.Bancho.Data;

namespace CringeLazer.Bancho._Features_.Api.Chat.JoinChannel;

public class Endpoint : Endpoint<Request, ChatChannel>
{
    public override void Configure()
    {
        Put("/chat/channels/{channel}/users/{user}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await ChatChannelData.ChatExists(req.ChannelId))
        {
            await SendNotFoundAsync();
            return;
        }

        var channel = await Data.Join(req.ChannelId, req.Id);
        await SendOkAsync(channel);
    }
}
