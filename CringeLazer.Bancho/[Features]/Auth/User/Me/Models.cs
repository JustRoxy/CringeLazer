namespace CringeLazer.Bancho._Features_.Auth.User.Me;

public class Request
{
    [FromClaim]
    public string Id { get; set; } = null!;
}

public class Response
{

}
