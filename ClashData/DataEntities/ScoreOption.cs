using ClashEntities;
using Dapper.Contrib.Extensions;

namespace ClashData.DataEntities
{
    [Table("ScoreOptions")]
    public class ScoreOption : IDatabaseEntity
    {
        public int Id { get; set; }
        public string ScoreType { get; set; }
        public string ScoreName { get; set; }
        public string ScoreValue { get; set; }
    }
}
