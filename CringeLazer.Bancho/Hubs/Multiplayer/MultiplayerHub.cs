using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CringeLazer.Bancho.Hubs.Multiplayer;

[Authorize]
public class MultiplayerHub : Hub
{
    private readonly ILogger<MultiplayerHub> _logger;
    private long _name => long.Parse(Context.UserIdentifier!);

    public MultiplayerHub(ILogger<MultiplayerHub> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation(Context.ConnectionId);

        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogInformation(Context.ConnectionId);

        return Task.CompletedTask;
    }
}
