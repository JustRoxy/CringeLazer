using CringeLazer.Bancho.Domain.Chat;
using Mapster;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Data;

public static class ChatChannelData
{
    public static async Task<bool> UserContains(ulong channelId, ulong userId)
    {
        return await DB.Find<ChatChannel>()
            .Match(x => x.Id == channelId)
            .Match(x => x.UserIds.Contains(userId))
            .ExecuteAnyAsync();
    }

    public static async Task<bool> ChatExists(ulong channelId)
    {
        return await DB.Find<ChatChannel>()
            .Match(x => x.Id == channelId)
            .ExecuteAnyAsync();
    }

    public static async Task<List<Contracts.Chat.ChatMessage>> GetMessages(ulong channelId)
    {
        var messages = await DB.Find<ChatMessage>()
            .Match(x => x.ChannelId == channelId)
            .Sort(x => x.Descending(v => v.Id))
            .Limit(50)
            .ExecuteAsync();

        return messages.Adapt<List<Contracts.Chat.ChatMessage>>();
    }
    public static async Task<Contracts.Chat.ChatChannel> GetChannel(ulong id, ulong claim)
    {
        return await DB.Find<ChatChannel, Contracts.Chat.ChatChannel>()
            .Match(x => x.Id == id)
            .Project(x => new Contracts.Chat.ChatChannel
            {
                ChannelId = x.Id,
                Name = x.Name,
                Description = x.Description,
                Icon = x.Icon,
                Type = x.Type.ToString(),
                LastReadId = x.LastReadIds[claim.ToString()],
                LastMessageId = x.LastMessageId,
                Moderated = x.Moderated,
                Users = x.UserIds
            })
            .ExecuteSingleAsync();
    }

    public static async Task<Contracts.Chat.ChatChannel> GetChannelMinimal(ulong id)
    {
        return await DB.Find<ChatChannel, Contracts.Chat.ChatChannel>()
            .Match(x => x.Id == id)
            .Project(x => new Contracts.Chat.ChatChannel
            {
                ChannelId = x.Id,
                Name = x.Name,
                Description = x.Description,
                Icon = x.Icon,
                Type = x.Type.ToString(),
                Moderated = x.Moderated
            })
            .ExecuteSingleAsync();
    }
}
