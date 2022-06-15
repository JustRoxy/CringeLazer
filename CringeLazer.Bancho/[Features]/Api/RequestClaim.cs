namespace CringeLazer.Bancho._Features_.Api;

public class RequestClaim
{
    [FromClaim]
    public int Id { get; set; }
}

