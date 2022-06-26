using CringeLazer.Bancho.Contracts;
using Mapster;

namespace CringeLazer.Bancho._Features_.Api.GetFriends;

public class Endpoint : Endpoint<RequestClaim, List<User>>
{
    public override void Configure()
    {
        Get("friends");
    }

    public override async Task HandleAsync(RequestClaim req, CancellationToken ct)
    {
        var result = await Data.GetFriends(req.Id, ct);
        await SendOkAsync(result.Adapt<List<User>>());
    }
}
