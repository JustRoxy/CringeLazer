using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho.Domain.Chat;

public class ChatChannel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Icon { get; set; }

    public ChannelType Type { get; set; }

    public int LastMessageId => Messages.LastOrDefault()?.ChannelId ?? 0;

    public bool Moderated { get; set; }

    public List<User> Users { get; set; }

    public List<CurrentUserAttributes> CurrentUserAttributes { get; set; }

    public List<ChatMessage> Messages { get; set; }
}

[Owned]
public class CurrentUserAttributes
{
    public User User { get; set; }
    public int UserId { get; set; }
    public bool CanMessage { get; set; }
    public string CanMessageError { get; set; }
    public long LastReadId { get; set; }
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
