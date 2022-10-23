using CringeLazer.Core.Models.Users;

namespace CringeLazer.Core.Models;

public class FriendsModel
{
    public long IssuerId { get; set; }
    public UserModel Issuer { get; set; }
    public long ReceiverId { get; set; }
    public UserModel Receiver { get; set; }
}
