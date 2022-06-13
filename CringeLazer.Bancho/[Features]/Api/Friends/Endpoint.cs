using CringeLazer.Bancho.Contracts;
using Mapster;

namespace CringeLazer.Bancho._Features_.Api.Friends;

public class Endpoint : Endpoint<RequestClaim, List<User>>
{
    public override void Configure()
    {
        Get("/api/v2/friends");
    }

    public override async Task HandleAsync(RequestClaim req, CancellationToken ct)
    {
        var friends = await Data.GetFriends(req.Id, ct);
        await SendOkAsync(friends.Adapt<List<User>>());
    }
}
