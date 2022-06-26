using CringeLazer.Bancho.Data;

namespace CringeLazer.Bancho._Features_.Api.Chat.GetUpdates;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/chat/updates");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (req.ChannelId is null)
        {
            var channels = await Data.GetUsersChannels(req.Id, ct);
            if (channels is null || channels.Count == 0)
            {
                await SendNoContentAsync();

                return;
            }
            var messages = await Data.GetMessages(channels, req.Since ?? 0);
            if (messages.Count == 0)
            {
                await SendNoContentAsync();

                return;
            }

            await SendOkAsync(new Response
            {
                Messages = messages,
                Presence = await Data.Presence(channels, req.Id)
            });

            return;
        }

        if (!await ChatChannelData.UserContains(req.ChannelId.Value, req.Id))
        {
            ThrowError("You're not in the channel");

            return;
        }

        await SendOkAsync(new Response
        {
            Presence = new[] { await ChatChannelData.GetChannel(req.ChannelId.Value, req.Id) },
            Messages = await ChatChannelData.GetMessages(req.ChannelId.Value)
        });
    }
}
