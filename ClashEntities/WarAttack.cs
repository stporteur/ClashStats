using Dapper.Contrib.Extensions;

namespace ClashEntities
{
    [Table("WarAttacks")]
    public class WarAttack : AbstractAttack, IDatabaseEntity
    {
        public int WarPlayerId { get; set; }
        public int WarId { get; set; }
        public int AttackNumber { get; set; }
        public bool IsOpeningAttack { get; set; }
    }
}
