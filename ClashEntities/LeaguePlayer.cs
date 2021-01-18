using Dapper.Contrib.Extensions;

namespace ClashEntities
{
    [Table("LeaguePlayers")]
    public class LeaguePlayer : IDatabaseEntity
    {
        public int Id { get; set; }
        public int WarriorId { get; set; }
        [Write(false)] public string WarriorName { get { return Warrior.Name; } }
        [Write(false)] public Warrior Warrior { get; set; }

        public int LeagueId { get; set; }
    }
}
