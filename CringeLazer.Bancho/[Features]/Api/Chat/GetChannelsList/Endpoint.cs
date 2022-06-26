using CringeLazer.Bancho.Domain.Chat;
using MongoDB.Entities;
using ChatChannel = CringeLazer.Bancho.Contracts.Chat.ChatChannel;

namespace CringeLazer.Bancho._Features_.Api.Chat.GetChannelsList;

public class Endpoint : Endpoint<RequestClaim, List<ChatChannel>>
{
    public override void Configure()
    {
        Get("/chat/channels");
    }

    public override async Task HandleAsync(RequestClaim req, CancellationToken ct)
    {
        var channels = await DB.Find<Domain.Chat.ChatChannel, ChatChannel>()
            .Match(x => x.Type == ChannelType.PUBLIC)
            .Project(x => new ChatChannel
            {
                ChannelId = x.Id,
                Name = x.Name,
                Description = x.Description,
                Icon = x.Icon,
                Type = x.Type.ToString(),
                Moderated = x.Moderated
            })
            .ExecuteAsync(ct);

        await SendOkAsync(channels);
    }
}
