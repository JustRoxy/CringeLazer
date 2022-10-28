using CringeLazer.Core.Services;

namespace CringeLazer.Bancho.Middlewares;

public class OnlineMiddleware : IMiddleware
{
    private readonly IOnlineUsers _online;

    public OnlineMiddleware(IOnlineUsers online)
    {
        _online = online;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var name = context.User.Identity?.Name;
        if (name is null)
        {
            await next(context);

            return;
        }

        await _online.Online(name, TimeSpan.FromMinutes(5));
        await _online.Ping(name);

        await next(context);
    }
}
