using Dapper.Contrib.Extensions;

namespace ClashEntities.ScoreOptions
{
    [Table("SeniorityScoreOptions")]
    public class SeniorityBonus : IDatabaseEntity
    {
        public int Id { get; set; }
        public int MinimumMonth { get; set; }
        public int MaximumMonth { get; set; }
        public int Bonus { get; set; }
    }
}
