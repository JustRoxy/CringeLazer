using System.ComponentModel.DataAnnotations.Schema;

namespace CringeLazer.Bancho.Domain.Chat;

public class UserSilence
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public User User { get; set; }
}
