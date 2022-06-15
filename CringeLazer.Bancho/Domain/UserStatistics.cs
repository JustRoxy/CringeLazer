using System.ComponentModel.DataAnnotations.Schema;

namespace CringeLazer.Bancho.Domain;

public class UserStatistics
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public LevelInfo Level { get; set; }

    public bool IsRanked { get; set; }

    public int? GlobalRank { get; set; }

    public int? CountryRank { get; set; }

    public decimal? Pp { get; set; }

    public long RankedScore { get; set; }

    public double Accuracy { get; set; }

    public int PlayCount { get; set; }

    public int? PlayTime { get; set; }

    public long TotalScore { get; set; }

    public int TotalHits { get; set; }

    public int MaxCombo { get; set; }

    public int ReplaysWatched { get; set; }

    public Grades GradesCount { get; set; }

    public class LevelInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Current { get; set; }

        public int Progress { get; set; }
    }

    public class Grades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SSPlus { get; set; }

        public int SS { get; set; }

        public int? SPlus { get; set; }

        public int S { get; set; }

        public int A { get; set; }
    }
}
