using CringeLazer.Bancho.Domain;
using CringeLazer.Bancho.Domain.Chat;
using Mapster;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.SendMessage;

public static class Data
{
    public static async Task<ChatMessage> SendMessage(Request req, CancellationToken token)
    {
        var user = await DB.Find<User>()
            .Match(x => x.Id == req.Id)
            .ExecuteSingleAsync(token);

        var message = new ChatMessage
        {
            Id = await DB.NextSequentialNumberAsync<ChatMessage>(token),
            Timestamp = DateTime.UtcNow,
            ChannelId = req.Channel,
            Content = req.Message,
            IsAction = req.IsAction,
            SenderId = req.Id,
            Sender = user.Adapt<ChatMessage.MessageUser>()
        };

        await message.SaveAsync(cancellation: token);

        await DB.Update<ChatChannel>()
            .Match(x => x.Id == req.Channel)
            .Modify(x => x.Set(v => v.LastMessageId, message.Id))
            .Modify(x => x.Set(v => v.LastReadIds[req.Id.ToString()], message.Id))
            .ExecuteAsync(token);

        return message;
    }
}
