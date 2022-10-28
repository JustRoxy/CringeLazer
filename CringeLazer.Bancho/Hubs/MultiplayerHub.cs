using Microsoft.AspNetCore.SignalR;

namespace CringeLazer.Bancho.Hubs;

public class MultiplayerHub : Hub
{
    private readonly ILogger<MultiplayerHub> _logger;

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
