using System.Text.Json.Serialization;
using CringeLazer.Bancho.Contracts.Chat;
using CringeLazer.Bancho.Helpers;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateNewPm;

public class Request : RequestClaim, IResultRequest<Response>
{
    [BindFrom("target_id")]
    public int TargetId { get; set; }

    [BindFrom("message")]
    public string Message { get; set; }

    [BindFrom("is_action")]
    public bool IsAction { get; set; }
}

public class Response
{
    public int NewChannelId { get; set; }
    public ChatChannel Channel { get; set; }
    public ChatMessage Message { get; set; }

    public class ChatChannel
    {
        [JsonPropertyName("channel_id")]
        public int Id { get; set; }

        public CurrentUserAttributes CurrentUserAttributes { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } = "PM";
        public int LastReadId { get; set; }
        public int LastMessageId { get; set; }
    }
}
