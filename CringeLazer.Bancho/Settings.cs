namespace CringeLazer.Bancho;

public class Settings
{
    public class SecurityTokenSettings
    {
        public string SigningKey { get; set; } = null!;
    }

    public SecurityTokenSettings Token { get; set; } = null!;
}
