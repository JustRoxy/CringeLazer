namespace CringeLazer.Bancho._Features_.Api.Chat.GetChannel;

public class Request : RequestClaim
{
    [BindFrom("channel")]
    public ulong ChannelId { get; set; }
}
