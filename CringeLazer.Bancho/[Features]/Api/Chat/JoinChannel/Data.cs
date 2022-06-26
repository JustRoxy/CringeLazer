using CringeLazer.Bancho.Domain;
using CringeLazer.Bancho.Domain.Chat;
using Mapster;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.JoinChannel;

public static class Data
{
    public static async Task<Contracts.Chat.ChatChannel> Join(ulong channel, ulong user)
    {
        var updatedChannel = await DB.UpdateAndGet<ChatChannel>()
            .Match(x => x.Id == channel)
            .Modify(x => x.AddToSet(v => v.UserIds, user))
            .Modify(x => x.Set(v => v.LastReadIds[user.ToString()], user))
            .ExecuteAsync();

        await DB.Update<User>()
            .Match(x => x.Id == user)
            .Modify(x => x.AddToSet(v => v.JoinedChannels, channel))
            .ExecuteAsync();

        var response = updatedChannel.Adapt<Contracts.Chat.ChatChannel>();
        response.LastReadId = 0;

        return response;
    }
}
