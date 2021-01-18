using Dapper.Contrib.Extensions;

namespace ClashEntities.ScoreOptions
{
    [Table("TownHallLevelScoreOptions")]
    public class TownHallMaturityBonus : IDatabaseEntity
    {
        public int Id { get; set; }
        public int TownHallLevel { get; set; }
        public TownHallLevelMaturities Maturity { get; set; }
        public int Bonus { get; set; }
    }
}
