using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Domain.Chat;

[Collection("messages")]
public class ChatMessage : IEntity
{
    static ChatMessage()
    {
        DB.Index<ChatMessage>()
            .Key(x => x.ChannelId, KeyType.Ascending)
            .CreateAsync();
    }
    [BsonId]
    public ulong Id { get; set; }

    public ulong SenderId { get; set; }
    public ulong ChannelId { get; set; }
    public DateTime Timestamp { get; set; }
    public string Content { get; set; }
    public MessageUser Sender { get; set; }
    public bool IsAction { get; set; }

    public class MessageUser
    {
        public ulong Id { get; set; }
        public string Username { get; set; }
        public string ProfileColour { get; set; }
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsBot { get; set; }
        public bool IsOnline { get; set; }
        public bool IsSupporter { get; set; }
    }

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
