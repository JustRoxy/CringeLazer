using CringeLazer.Bancho.Contracts;
using Mapster;
using MongoDB.Entities;
using User = CringeLazer.Bancho.Domain.User;

namespace CringeLazer.Bancho._Features_.Api.Rankings.Performance;

public static class Data
{
    public static async Task<Response> GetUsers(int page, CancellationToken token)
    {
        var result = await DB.PagedSearch<User>()
            .Sort(x => x.Descending(v => v.Statistics.Pp))
            .PageSize(50)
            .PageNumber(page)
            .ExecuteAsync(token);

        var statistics = result.Results.Select(x =>
        {
            var stat = x.Statistics.Adapt<UserStatistics>();
            stat.User = x.Adapt<UserCompact>();

            return stat;
        });

        var cursorPage = result.PageCount < page ? page + 1 : (int?)null;

        return new Response
        {
            Ranking = statistics.ToList(),
            Total = result.TotalCount,
            Cursor = new Cursor
            {
                Page = cursorPage
            }
        };
    }
}
