using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Domain.Chat;

[Collection("channels")]
public class ChatChannel : IEntity
{
    [BsonId]
    public ulong Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Icon { get; set; }

    public ChannelType Type { get; set; }

    public Dictionary<string, ulong> LastReadIds { get; set; }
    public ulong LastMessageId { get; set; }
    public bool Moderated { get; set; }

    public List<ulong> UserIds { get; set; }

    public string GenerateNewID()
    {
        throw new NotImplementedException();
    }

    public string ID
    {
        get => Id.ToString();
        set => Id = ulong.Parse(value);
    }
}

public class CurrentUserAttributes
{
    public User User { get; set; }
    public int UserId { get; set; }
    public bool CanMessage { get; set; }
    public string CanMessageError { get; set; }
    public long LastReadId { get; set; }
}

public enum ChannelType
{
    PUBLIC,
    PRIVATE,
    MULTIPLAYER,
    SPECTATOR,
    PM,
    GROUP
}
