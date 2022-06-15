using Newtonsoft.Json;

namespace CringeLazer.Bancho.Contracts.Chat;

public class ChatMessage
{
    [JsonProperty(@"message_id")]
    public long? Id { get; set; }

    [JsonProperty(@"channel_id")]
    public long ChannelId { get; set; }

    [JsonProperty(@"is_action")]
    public bool IsAction { get; set; }

    [JsonProperty(@"timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonProperty(@"content")]
    public string Content { get; set; }

    [JsonProperty(@"sender")]
    public User Sender { get; set; }
}
