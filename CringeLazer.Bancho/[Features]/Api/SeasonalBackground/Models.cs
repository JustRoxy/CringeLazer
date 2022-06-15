using CringeLazer.Bancho.Helpers;

namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public class Request : IResultRequest<SeasonalBackgroundsResponse>
{

}

public class SeasonalBackgroundsResponse
{
    public DateTime EndsAt { get; set; }

    public List<SeasonalBackground> Backgrounds { get; set; }

    public class SeasonalBackground
    {
        public string Url { get; set; }
    }
}

