using System.Collections.Concurrent;
using CringeLazer.Bancho.Domain;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Middleware;

public class LastVisitMiddleware : IMiddleware
{
    private static readonly ConcurrentDictionary<ulong, DateTime> _updateCache = new();
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var claim = context.User.Claims.FirstOrDefault(x => x.Type == "Id");
        if (claim is null)
        {
            await next(context);
            return;
        }

        await next(context);

        var id = ulong.Parse(claim.Value);
        var now = DateTime.UtcNow;
        var updated = _updateCache.GetOrAdd(id, now);
        if (updated.AddMinutes(5) > now)
        {
            return;
        }

        _ = DB.Update<User>() //Fire-and-forget update
            .Match(x => x.Id == id)
            .Modify(x => x.Set(v => v.LastVisit, DateTime.UtcNow))
            .ExecuteAsync();
    }
}
