using CringeLazer.Bancho.Contracts.Chat;

namespace CringeLazer.Bancho._Features_.Api.Chat.GetUpdates;

public class Request : RequestClaim
{
    [BindFrom("channel")]
    public ulong? ChannelId { get; set; }

    [BindFrom("since")]
    public ulong? Since { get; set; }
}

public class Response
{
    public List<ChatMessage> Messages { get; set; }
    public ChatChannel[] Presence { get; set; }
}
