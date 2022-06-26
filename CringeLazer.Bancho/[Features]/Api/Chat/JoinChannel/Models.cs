namespace CringeLazer.Bancho._Features_.Api.Chat.JoinChannel;

public class Request : RequestClaim
{
    [BindFrom("channel")]
    public ulong ChannelId { get; set; }
}
