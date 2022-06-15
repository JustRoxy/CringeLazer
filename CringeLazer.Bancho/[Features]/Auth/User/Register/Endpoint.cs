using MediatR;

namespace CringeLazer.Bancho._Features_.Auth.User.Register;

public class Endpoint : Endpoint<Request>
{
    public IMediator Mediator { get; set; }
    public override void Configure()
    {
        Post("/users");
        AllowFormData();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var result = await Mediator.Send(req, ct);
        if (result.IsError)
        {
            ThrowError(result.Errors[0].Message);
        }
        else
        {
            await SendOkAsync();
        }
    }
}
