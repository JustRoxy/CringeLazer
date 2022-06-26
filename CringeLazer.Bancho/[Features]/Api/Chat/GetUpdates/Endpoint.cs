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
            var messagesTask = Data.GetMessages(channels, req.Since ?? 0);
            var channelTask = Data.Presence(channels, req.Id);

            await SendOkAsync(new Response
            {
                Messages = await messagesTask,
                Presence = await channelTask
            });
        }
        else
        {
            if (!await ChatChannelData.UserContains(req.ChannelId.Value, req.Id))
            {
                ThrowError("You're not in the channel");
                return;
            }

            await SendOkAsync(new Response
            {
                Presence = new []{await ChatChannelData.GetChannel(req.ChannelId.Value, req.Id)},
                Messages = await ChatChannelData.GetMessages(req.ChannelId.Value)
            });
        }
    }
}
