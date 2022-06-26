using CringeLazer.Bancho.Contracts.Chat;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateNewPm;

public class Request : RequestClaim
{
    [BindFrom("target_id")]
    public ulong TargetId { get; set; }

    [BindFrom("message")]
    public string Message { get; set; }

    [BindFrom("is_action")]
    public bool IsAction { get; set; }
}

public class Response
{
    public ulong NewChannelId { get; set; }
    public ChatMessage Message { get; set; }
}
