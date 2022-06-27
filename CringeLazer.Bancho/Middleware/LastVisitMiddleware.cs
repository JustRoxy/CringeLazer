using CringeLazer.Bancho.Domain;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Middleware;

public class LastVisitMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var claim = context.User.Claims.FirstOrDefault(x => x.Type == "Id");
        if (claim is null)
        {
            await next(context);
            return;
        }

        await next(context);

        var name = ulong.Parse(claim.Value);
        _ = DB.Update<User>() //Fire-and-forget update
            .Match(x => x.Id == name)
            .Modify(x => x.Set(v => v.LastVisit, DateTime.UtcNow))
            .ExecuteAsync();
    }
}
