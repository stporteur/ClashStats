using Dapper.Contrib.Extensions;

namespace ClashEntities
{
    [Table("LeagueAttacks")]
    public class LeagueAttack : AbstractAttack, IDatabaseEntity
    {
        public int LeagueId { get; set; }
        public int Day { get; set; }
        public int WarriorId { get; set; }
        [Write(false)] public string WarriorName { get { return Warrior.Name; } }
        [Write(false)] public Warrior Warrior { get; set; }
        public int Position { get; set; }
        public bool FailedWarFault { get; set; }
    }
}
 