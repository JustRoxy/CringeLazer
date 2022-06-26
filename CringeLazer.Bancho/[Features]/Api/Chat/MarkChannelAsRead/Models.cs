namespace CringeLazer.Bancho._Features_.Api.Chat.MarkChannelAsRead;

public class Request : RequestClaim
{
    [BindFrom("channel")]
    public ulong Channel { get; set; }

    [BindFrom("message")]
    public ulong Message { get; set; }
}
