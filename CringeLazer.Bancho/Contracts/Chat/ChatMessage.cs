using System.Text.Json.Serialization;

namespace CringeLazer.Bancho.Contracts.Chat;

public class ChatMessage
{
    [JsonPropertyName(@"message_id")]
    public ulong Id { get; set; }

    [JsonPropertyName(@"channel_id")]
    public ulong ChannelId { get; set; }

    [JsonPropertyName(@"is_action")]
    public bool IsAction { get; set; }

    [JsonPropertyName(@"timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonPropertyName(@"content")]
    public string Content { get; set; }

    [JsonPropertyName(@"sender")]
    public UserSender Sender { get; set; }
}
