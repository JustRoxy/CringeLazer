namespace CringeLazer.Bancho._Features_.Auth.User.Register;

public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users");
        AllowFormData();
        AllowAnonymous();
        RoutePrefixOverride("");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (await Data.UserExists(req, ct))
        {
            ThrowError("You're already registered");
            return;
        }

        await Data.AddUser(req, ct);
    }
}
