using System.Text.Json.Serialization;

namespace CringeLazer.Bancho._Features_.Api.SeasonalBackground;

public class SeasonalBackgroundsResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? EndsAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SeasonalBackground> Backgrounds { get; set; }

    public class SeasonalBackground
    {
        public string Url { get; set; }
    }
}

