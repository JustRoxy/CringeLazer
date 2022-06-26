using CringeLazer.Bancho.Domain;
using CringeLazer.Bancho.Domain.Chat;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Chat.LeaveChannel;

public static class Data
{
    public static async Task Leave(ulong channel, ulong user)
    {
        await DB.Update<ChatChannel>()
            .Match(x => x.Id == channel)
            .Modify(x => x.Pull(v => v.UserIds, user))
            .Modify(x => x.Unset(v => v.LastReadIds[user.ToString()]))
            .ExecuteAsync();

        await DB.Update<User>()
            .Match(x => x.Id == user)
            .Modify(x => x.Pull(v => v.JoinedChannels, channel))
            .ExecuteAsync();
    }
}
