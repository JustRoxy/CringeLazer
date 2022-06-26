namespace CringeLazer.Bancho._Features_.Api.Chat.SendMessage;

public class Request : RequestClaim
{
    [BindFrom("channel")]
    public ulong Channel { get; set; }

    [BindFrom("message")]
    public string Message { get; set; }

    [BindFrom("is_action")]
    public bool IsAction { get; set; }
}
