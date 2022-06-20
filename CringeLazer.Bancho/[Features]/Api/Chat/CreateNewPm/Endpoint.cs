using MediatR;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateNewPm;

public class Endpoint : Endpoint<Request, Response>
{
    public IMediator Mediator { get; set; }
    public override void Configure()
    {
        Post("/chat/new");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var response = await Mediator.Send(req, ct);
        if (response.IsError)
        {
            ThrowError(response.Errors[0].Message);
        }
        else
        {
            await SendOkAsync(response.Value);
        }
    }
}
