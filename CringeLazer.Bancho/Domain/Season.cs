using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho.Domain;

public class Season
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime EndsAt { get; set; }

    public List<SeasonalBackgrounds> Backgrounds { get; set; }

    [Owned]
    public class SeasonalBackgrounds
    {
        public string Url { get; set; }
    }
}
