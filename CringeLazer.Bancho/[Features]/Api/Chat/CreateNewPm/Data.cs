using CringeLazer.Bancho.Domain;
using CringeLazer.Bancho.Domain.Chat;
using Mapster;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateNewPm;

public static class Data
{
    public static async Task<bool> UserExists(ulong id, CancellationToken token)
    {
        return await DB.Find<User>()
            .Match(x => x.Id == id)
            .ExecuteAnyAsync(token);
    }

    public static async Task<Response> CreateChat(Request request, CancellationToken token)
    {
        var sender = await DB.Find<User>()
            .Match(x => x.Id == request.Id)
            .ExecuteSingleAsync(token);

        var channelId = await DB.NextSequentialNumberAsync<ChatChannel>(token);
        var messageId = await DB.NextSequentialNumberAsync<ChatMessage>(token);

        var channel = new ChatChannel
        {
            Id = channelId,
            Description = "YOUR PM WITH VSEVOLOD VOLKOV",
            Icon = "https://a.stanr.info/sadhjfbsjdfh",
            Moderated = false,
            Name = "PM WITH CHUVIK",
            Type = ChannelType.PM,
            LastMessageId = messageId,
            LastReadIds = new Dictionary<string, ulong>
            {
                {request.Id.ToString(), messageId},
                {request.TargetId.ToString(), 0}
            },

            UserIds = new List<ulong>
            {
                request.Id,
                request.TargetId
            }
        };

        var message = new ChatMessage
        {
            Id = messageId,
            ChannelId = channelId,
            Content = request.Message,
            IsAction = request.IsAction,
            SenderId = request.Id,
            Sender = sender.Adapt<ChatMessage.MessageUser>(),
            Timestamp = DateTime.UtcNow
        };

        Task AddToUser(ulong userId)
        {
            return DB.Update<User>()
                .Match(x => x.Id == userId)
                .Modify(x => x.AddToSet(v => v.JoinedChannels, channelId))
                .ExecuteAsync(token);
        }

        await Task.WhenAll(
            channel.SaveAsync(cancellation: token),
            message.SaveAsync(cancellation: token),
            AddToUser(request.TargetId),
            AddToUser(request.Id));

        var responseChannel = channel.Adapt<Contracts.Chat.ChatChannel>();
        responseChannel.LastReadId = messageId;

        return new Response
        {
            Message = message.Adapt<Contracts.Chat.ChatMessage>(),
            NewChannelId = channelId
        };
    }
}
