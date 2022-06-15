using System.ComponentModel.DataAnnotations.Schema;

namespace CringeLazer.Bancho.Domain.Chat;

public class ChatMessage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public ulong Id { get; set; }

    public ChatChannel Channel { get; set; }

    public long ChannelId { get; set; }

    public bool IsAction { get; set; }

    public DateTime Timestamp { get; set; }

    public string Content { get; set; }

    public User Sender { get; set; }
    public int SenderId { get; set; }
}
