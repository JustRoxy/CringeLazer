using CringeLazer.Bancho.Contracts.Chat;
using CringeLazer.Bancho.Data;
using Mapster;

namespace CringeLazer.Bancho._Features_.Api.Chat.GetChannelMessages;

public class Endpoint : Endpoint<Request, List<ChatMessage>>
{
    public override void Configure()
    {
        Get("/chat/channels/{channel}/messages");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await ChatChannelData.UserContains(req.Channel, req.Id))
        {
            ThrowError("You're not in the chat");
            return;
        }

        var messages = await Data.GetMessages(req, ct);
        await SendOkAsync(messages.Adapt<List<ChatMessage>>());
    }
}
