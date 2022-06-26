using CringeLazer.Bancho.Domain.Chat;
using MongoDB.Driver;
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
}
