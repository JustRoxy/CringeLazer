using Newtonsoft.Json;

namespace CringeLazer.Bancho.Contracts.Chat;

public class ChatMessage
{
    [JsonProperty(@"message_id")]
    public ulong Id { get; set; }

    [JsonProperty(@"channel_id")]
    public ulong ChannelId { get; set; }

    [JsonProperty(@"is_action")]
    public bool IsAction { get; set; }

    [JsonProperty(@"timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonProperty(@"content")]
    public string Content { get; set; }

    [JsonProperty(@"sender")]
    public UserCompact Sender { get; set; }
}
