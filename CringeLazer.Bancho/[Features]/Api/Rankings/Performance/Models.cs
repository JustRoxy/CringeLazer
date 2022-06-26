using CringeLazer.Bancho.Contracts;

namespace CringeLazer.Bancho._Features_.Api.Rankings.Performance;

public class Request : RequestClaim
{
    [BindFrom("page")]
    public int Page { get; set; }
}

public class Response
{
    public Cursor Cursor { get; set; }
    public List<UserStatistics> Ranking { get; set; }
    public long Total { get; set; }
}

public class Cursor
{
    public int? Page { get; set; }
}
