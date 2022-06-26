namespace CringeLazer.Bancho._Features_.Api.Chat.GetChannelMessages;

public class Request : RequestClaim
{
    [BindFrom("channel")]
    public ulong Channel { get; set; }

    [BindFrom("limit")]
    public int? Limit { get; set; }

    [BindFrom("since")]
    public ulong? Since { get; set; }

    [BindFrom("until")]
    public ulong? Until { get; set; }
}
