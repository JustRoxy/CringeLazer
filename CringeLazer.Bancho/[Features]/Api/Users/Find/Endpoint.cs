using CringeLazer.Bancho.Contracts;
using Mapster;
using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Api.Users.Find;

public class Endpoint : Endpoint<Request, User>
{
    public override void Configure()
    {
        Get("users/{user}/");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        switch (req.Key)
        {
            case "id":
            {
                var user = await DB.Find<Domain.User>()
                    .Match(x => x.Id == ulong.Parse(req.User))
                    .ExecuteSingleAsync(ct);
                if (user is null)
                {
                    await SendNotFoundAsync();

                    return;
                }

                await SendOkAsync(user.Adapt<User>());
                return;
            }
            case "username":
            {
                var userByName = await DB.Find<Domain.User>()
                    .Match(x => x.Username == req.User)
                    .ExecuteSingleAsync(ct);

                if (userByName is null)
                {
                    await SendNotFoundAsync();

                    return;
                }

                await SendOkAsync(userByName.Adapt<User>());

                break;
            }
            default:
                ThrowError("Unknown key");

                break;
        }
    }
}
