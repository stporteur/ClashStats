using Dapper.Contrib.Extensions;

namespace ClashEntities
{
    [Table("WarPlayers")]
    public class WarPlayer : IDatabaseEntity
    {
        public int Id { get; set; }
        public int WarId { get; set; }
        public int WarriorId { get; set; }
        [Write(false)] public Warrior Warrior { get; set; }
        public int Position { get; set; }
        public int FirstAttackId { get; set; }
        [Write(false)] public WarAttack FirstAttack { get; set; }
        public int SecondAttackId { get; set; }
        [Write(false)] public WarAttack SecondAttack { get; set; }
        public bool FailedWarFault { get; set; }

    }
}
