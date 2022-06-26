using CringeLazer.Bancho.Contracts.Chat;
using CringeLazer.Bancho.Data;
using Mapster;

namespace CringeLazer.Bancho._Features_.Api.Chat.SendMessage;

public class Endpoint : Endpoint<Request, ChatMessage>
{
    public override void Configure()
    {
        Post("/chat/channels/{channel}/messages");
        AllowFormData();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await ChatChannelData.UserContains(req.Channel, req.Id))
        {
            ThrowError("You're not in the channel");
            return;
        }

        var message = await Data.SendMessage(req, ct);
        await SendOkAsync(message.Adapt<ChatMessage>());
    }
}
