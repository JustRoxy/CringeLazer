namespace CringeLazer.Bancho;

public class Settings
{
    public class SecurityTokenSettings
    {
        public string SigningKey { get; set; } = null!;
    }

    public class DatabaseConfiguration
    {
        public string MongoDbConnectionString { get; set; } = null!;
    }

    public SecurityTokenSettings Token { get; set; } = null!;
    public DatabaseConfiguration Database { get; set; } = null!;
}
