namespace CringeLazer.Bancho._Features_.Api;

public class RequestClaim
{
    [FromClaim]
    public string Id { get; set; } = null!;
}

