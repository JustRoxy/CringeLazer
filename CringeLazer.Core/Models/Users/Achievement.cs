namespace CringeLazer.Core.Models.Users;

public class Achievement
{
    public long UserId { get; set; }
    public long AchievementAwardId { get; set; }
    public int AchievementId { get; set; }
    public DateTime AchievedAt { get; set; }
}
