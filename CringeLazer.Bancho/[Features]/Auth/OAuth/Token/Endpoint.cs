using MediatR;
using Microsoft.Extensions.Options;

namespace CringeLazer.Bancho._Features_.Auth.OAuth.Token;

public class Endpoint : Endpoint<Request, Response>
{
    public IMediator Mediator { get; set; }

    public override void Configure()
    {
        Post("/oauth/token");
        AllowFormData();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var result = await Mediator.Send(req, ct);
        if (result.IsError)
        {
            ThrowError(string.Join(" | ", result.Errors.Select(x => x.Message)));
            return;
        }

        await SendOkAsync(result.Value);
    }
}
