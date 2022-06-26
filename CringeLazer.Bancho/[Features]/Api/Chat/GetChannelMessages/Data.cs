using CringeLazer.Bancho.Domain.Chat;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.GetChannelMessages;

public static class Data
{
    public static async Task<List<ChatMessage>> GetMessages(Request req, CancellationToken ct)
    {

        var builder = DB.Find<ChatMessage>()
            .Match(x => x.ChannelId == req.Channel);

        if (req.Since != null)
        {
            builder = builder.Match(x => x.Id > req.Since);
        }

        if (req.Until != null)
        {
            builder = builder.Match(x => x.Id < req.Until);
        }

        if (req.Limit > 50) req.Limit = 50;

        builder = builder.Limit(req.Limit ?? 50);

        return await builder.ExecuteAsync(ct);
    }
}
