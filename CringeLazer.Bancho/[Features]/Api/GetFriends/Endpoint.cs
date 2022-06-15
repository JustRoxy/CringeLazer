using CringeLazer.Bancho.Contracts;
using Mapster;
using MediatR;

namespace CringeLazer.Bancho._Features_.Api.Friends;

public class Endpoint : Endpoint<Request, List<User>>
{
    public IMediator Mediator { get; set; }
    public override void Configure()
    {
        Get("/api/v2/friends");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var result = await Mediator.Send(req, ct);

        await SendOkAsync(result.Adapt<List<User>>());
    }
}
