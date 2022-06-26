using CringeLazer.Bancho.Data;
using CringeLazer.Bancho.Domain.Chat;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateChannel;

public static class Data
{
    public static async Task<ChatChannel> GetChannel(ulong userId, ulong targetId, CancellationToken token)
    {
        return await DB.Find<ChatChannel>()
            .Match(x => x.UserIds.Contains(userId) && x.UserIds.Contains(targetId))
            .Match(x => x.Type == ChannelType.PM)
            .ExecuteFirstAsync(token);
    }

    public static async Task<List<ChatMessage>> GetRecent(ChatChannel channel, CancellationToken token)
    {
        return await DB.Find<ChatMessage>()
            .Match(x => x.ChannelId == channel.Id)
            .Sort(x => x.Descending(v => v.Id))
            .Limit(50)
            .ExecuteAsync(token);
    }

    public static async Task AddPublicChannel(Request.Channel request, ulong claim, CancellationToken token)
    {
        var channelId = await DB.NextSequentialNumberAsync<ChatChannel>(token);
        var message = new ChatMessage
        {
            ChannelId = channelId,
            Content = request.Message,
            Id = await DB.NextSequentialNumberAsync<ChatMessage>(token),
            IsAction = false,
            Sender = await UserData.GetSender(claim),
            SenderId = claim,
            Timestamp = DateTime.UtcNow
        };

        var channel = new ChatChannel
        {
            Description = request.Description,
            Icon = null,
            Id = channelId,
            LastMessageId = message.Id,
            LastReadIds = new Dictionary<string, ulong>(),
            Moderated = false,
            Name = request.Name,
            Type = ChannelType.PUBLIC,
            UserIds = new List<ulong>()
        };

        await message.SaveAsync(cancellation: token);
        await channel.SaveAsync(cancellation: token);
    }
}
