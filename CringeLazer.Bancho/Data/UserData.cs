using CringeLazer.Bancho.Domain.Chat;
using MongoDB.Entities;
using User = CringeLazer.Bancho.Domain.User;

namespace CringeLazer.Bancho.Data;

public static class UserData
{
    public static Task<ChatMessage.MessageUser> GetSender(ulong id)
    {
        return DB.Find<User, ChatMessage.MessageUser>()
            .Match(x => x.Id == id)
            .Project(x => new ChatMessage.MessageUser
            {
                Id = x.Id,
                Username = x.Username,
                ProfileColour = x.ProfileColour,
                CountryCode = x.CountryCode,
                IsActive = x.IsActive,
                IsBot = x.IsBot,
                IsOnline = x.IsOnline,
                IsSupporter = x.IsSupporter,
            })
            .ExecuteSingleAsync();
    }
}
