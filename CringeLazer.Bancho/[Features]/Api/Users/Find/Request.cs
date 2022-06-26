namespace CringeLazer.Bancho._Features_.Api.Users.Find;

public class Request
{
    [BindFrom("user")]
    public string User { get; set; }

    [BindFrom("key")]
    public string Key { get; set; }
}
