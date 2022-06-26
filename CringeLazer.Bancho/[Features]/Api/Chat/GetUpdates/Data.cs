using CringeLazer.Bancho.Contracts.Chat;
using CringeLazer.Bancho.Data;
using CringeLazer.Bancho.Domain;
using Mapster;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.GetUpdates;

public static class Data
{
    public static Task<List<ulong>> GetUsersChannels(ulong user, CancellationToken token)
    {
        return DB.Find<User, List<ulong>>()
            .Match(x => x.Id == user)
            .Project(x => x.JoinedChannels)
            .ExecuteSingleAsync(token);
    }

    public static async Task<List<ChatMessage>> GetMessages(List<ulong> channels, ulong since)
    {
        var messages = await DB.Find<Domain.Chat.ChatMessage>()
            .Match(x => channels.Contains(x.ChannelId))
            .Match(x => x.Id > since)
            .Sort(x => x.Descending(v => v.Id))
            .Limit(50)
            .ExecuteAsync();

        return messages.Adapt<List<ChatMessage>>();
    }

    public static async Task<ChatChannel[]> Presence(IEnumerable<ulong> channels, ulong claim)
    {
        return await Task.WhenAll(channels.Select(x => ChatChannelData.GetChannel(x, claim)));
    }
}
