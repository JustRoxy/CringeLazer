using MongoDB.Entities;

namespace CringeLazer.Bancho.Entities;

[Collection("seasonal_backgrounds")]
public class Season : Entity
{
    [Field("ends_in")]
    public DateTime EndsIn { get; set; }

    [Field("backgrounds")]
    public List<SeasonalBackgrounds> Backgrounds { get; set; }

    public class SeasonalBackgrounds
    {
        [Field("url")]
        public string Url { get; set; }
    }
}
