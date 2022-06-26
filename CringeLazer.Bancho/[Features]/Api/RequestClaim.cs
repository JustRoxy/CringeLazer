namespace CringeLazer.Bancho._Features_.Api;

public class RequestClaim
{
    [FromClaim]
    public ulong Id { get; set; }
}

