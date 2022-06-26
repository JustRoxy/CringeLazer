using Mapster;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateChannel;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/chat/channels");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var channel = await Data.GetChannel(req.Id, req.TargetId, ct);
        if (channel is null)
        {
            await SendOkAsync(new Response());
        }
        else
        {
            var map = channel.Adapt<Response>();
            var recent = await Data.GetRecent(channel, ct);
            map.RecentMessages = recent.Adapt<List<Response.Message>>();
            await SendOkAsync(map);
        }
    }
}
