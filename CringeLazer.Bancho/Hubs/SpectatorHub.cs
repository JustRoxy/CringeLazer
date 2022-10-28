using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Hub = Microsoft.AspNetCore.SignalR.Hub;

namespace CringeLazer.Bancho.Hubs;

[Authorize]
public class SpectatorHub : Hub
{
    private readonly ILogger<SpectatorHub> _logger;
    private string _name => Context.User!.Identity!.Name;

    public SpectatorHub(ILogger<SpectatorHub> logger)
    {
        _logger = logger;
    }

    public async Task StartWatchingUser(int userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, userId.ToString());
    }

    public async Task EndWatchingUser(int userId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId.ToString());
    }

    public async Task BeginPlaySession(object x)
    {
        await Clients.Group(_name).SendAsync("UserBeganPlaying", x);
    }

    public async Task EndPlaySession(object x)
    {
        await Clients.Group(_name).SendAsync("UserFinishedPlaying", x);
    }

    public async Task SendFrameData(object x)
    {
        await Clients.Group(_name).SendAsync("UserSentFrames", x);
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("New spectator connection. Name: {Name}, ConnectionId: {ConnectionId}", _name, Context.ConnectionId);

        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogInformation("Connection is closed. Name: {Name}, ConnectionId: {ConnectionId}", _name, Context.ConnectionId);

        return Task.CompletedTask;
    }
}
