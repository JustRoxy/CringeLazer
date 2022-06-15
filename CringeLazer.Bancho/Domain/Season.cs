using System.ComponentModel.DataAnnotations.Schema;

namespace CringeLazer.Bancho.Domain;

public class Season
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }
    public DateTime EndsAt { get; set; }

    public List<SeasonalBackgrounds> Backgrounds { get; set; }

    public class SeasonalBackgrounds
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string Url { get; set; }
    }
}
