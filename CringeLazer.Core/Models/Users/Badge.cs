namespace CringeLazer.Core.Models.Users;

public class Badge
{
    public long BadgeId { get; set; }
    public long UserId { get; set; }
    public DateTime AwardedAt { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
