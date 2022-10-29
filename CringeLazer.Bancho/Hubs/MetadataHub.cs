using CringeLazer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CringeLazer.Bancho.Hubs;

[Authorize]
public class MetadataHub : Hub
{
    private readonly IOnlineUsers _online;
    private string _name => Context.UserIdentifier;

    public MetadataHub(IOnlineUsers online)
    {
        _online = online;
    }

    public override async Task OnConnectedAsync()
    {
        await _online.Online(_name);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await _online.Offline(_name);
    }
}
