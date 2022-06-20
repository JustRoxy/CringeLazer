namespace CringeLazer.Bancho.Contracts.Chat;

public class ChatChannel
{
    public CurrentUserAttributes CurrentUserAttributes { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public ChannelType Type { get; set; }
    public long LastMessageId { get; set; }
    public List<ChatMessage> RecentMessages { get; set; }
    public bool Moderated { get; set; }
    public List<int> Users { get; set; }
}

public enum ChannelType
{
    PUBLIC,
    PRIVATE,
    MULTIPLAYER,
    SPECTATOR,
    PM,
    GROUP
}

public class CurrentUserAttributes
{
    public bool CanMessage { get; set; }
    public string CanMessageError { get; set; }
    public long LastReadId { get; set; }
}
