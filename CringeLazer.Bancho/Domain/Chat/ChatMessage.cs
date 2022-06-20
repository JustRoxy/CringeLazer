using System.ComponentModel.DataAnnotations.Schema;

namespace CringeLazer.Bancho.Domain.Chat;

public class ChatMessage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public ChatChannel Channel { get; set; }

    public int ChannelId { get; set; }

    public bool IsAction { get; set; }

    public DateTime Timestamp { get; set; }

    public string Content { get; set; }

    public User Sender { get; set; }
    public int SenderId { get; set; }
}
