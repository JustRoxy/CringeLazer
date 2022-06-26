using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace CringeLazer.Bancho.Domain;

[Collection("seasons")]
public class Season : IEntity
{
    public ulong Id { get; set; }
    public DateTime EndsAt { get; set; }

    public List<SeasonalBackgrounds> Backgrounds { get; set; }

    public class SeasonalBackgrounds
    {
        public string Url { get; set; }
    }

    public string GenerateNewID()
    {
        throw new NotImplementedException();
    }

    [BsonId]
    public string ID
    {
        get => Id.ToString();
        set => Id = ulong.Parse(value);
    }
}
