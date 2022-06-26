using CringeLazer.Bancho.Domain.Chat;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.MarkChannelAsRead;

public static class Data
{
    public static Task MarkChannelAsRead(Request req, CancellationToken token)
    {
        return DB.Update<ChatChannel>()
            .Match(x => x.Id == req.Channel)
            .Modify(x => x.Set(v => v.LastReadIds[req.Id.ToString()], req.Message))
            .ExecuteAsync(token);
    }
}
