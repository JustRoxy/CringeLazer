using System.Text.Json.Serialization;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateChannel;

public class Request : RequestClaim
{
    [BindFrom("channel")]
    public Channel NewChannel { get; set; }

    public class Channel
    {
        [BindFrom("name")]
        public string Name { get; set; }

        [BindFrom("description")]
        public string Description { get; set; }

        [BindFrom("message")]
        public string Message { get; set; }
    }

    [BindFrom("target_id")]
    public ulong TargetId { get; set; }

    [BindFrom("target_ids")]
    public List<ulong> TargetIds { get; set; }

    [BindFrom("type")]
    public string Type { get; set; }
}

public class Response
{
    [JsonPropertyName("channel_id")]
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public List<Message> RecentMessages { get; set; }

    public class Message
    {
        [JsonPropertyName("message_id")]
        public ulong Id { get; set; }
        public ulong SenderId { get; set; }
        public ulong ChannelId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
        public bool IsAction { get; set; }
    }
}
