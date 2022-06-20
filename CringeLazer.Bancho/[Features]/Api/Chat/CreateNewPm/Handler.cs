using CringeLazer.Bancho.Data;
using CringeLazer.Bancho.Domain;
using CringeLazer.Bancho.Domain.Chat;
using CringeLazer.Bancho.Helpers;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho._Features_.Api.Chat.CreateNewPm;

public class Handler : IRequestHandler<Request, Result<Response>>
{
    private readonly CringeContext _context;

    public Handler(CringeContext context)
    {
        _context = context;
    }

    public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var sender = await _context.Users
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        var target = await _context.Users
            .Where(x => x.Id == request.TargetId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (target is null)
        {
            return Result<Response>.Error($"User {request.TargetId} is not found", ErrorType.NotFound);
        }

        var channel = new ChatChannel
        {
            Description = "YOUR PM WITH VSEVOLOD VOLKOV",
            Icon = "https://a.stanr.info/sadhjfbsjdfh",
            Moderated = false,
            Name = "PM WITH CHUVIK",
            Type = ChannelType.PM,
            Users = new List<User>
            {
                sender,
                target
            },
            Messages = new List<ChatMessage>()
        };

        var message = new ChatMessage
        {
            Channel = channel,
            Content = request.Message,
            IsAction = request.IsAction,
            Sender = sender,
            Timestamp = DateTime.UtcNow
        };

        await _context.Messages.AddAsync(message, cancellationToken);
        channel.CurrentUserAttributes = new List<CurrentUserAttributes>
        {
            new()
            {
                CanMessage = true,
                CanMessageError = null,
                LastReadId = message.Id,
                UserId = request.Id
            },
            new()
            {
                CanMessage = true,
                CanMessageError = null,
                LastReadId = 0,
                UserId = request.TargetId
            }
        };

        channel.Messages.Add(message);
        await _context.Channels.AddAsync(channel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var response = new Response
        {
            Message = message.Adapt<Contracts.Chat.ChatMessage>(),
            NewChannelId = channel.Id
        };

        var responseChannel = channel.Adapt<Response.ChatChannel>();
        responseChannel.CurrentUserAttributes = channel
            .CurrentUserAttributes
            .First(x => x.UserId == request.Id)
            .Adapt<Contracts.Chat.CurrentUserAttributes>();
        response.Channel = responseChannel;

        return Result<Response>.Some(response);
    }
}
