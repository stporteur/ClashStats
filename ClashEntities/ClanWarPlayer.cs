using System;

namespace ClashEntities
{
    public class ClanWarPlayer
    {
        public int Id { get; set; }
        public int ClanWarId { get; set; }
        public int WarriorId { get; set; }
        public Warrior Warrior { get; set; }
        public int Position { get; set; }
        public int FirstAttackId { get; set; }
        public ClanWarAttack FirstAttack { get; set; }
        public int SecondAttackId { get; set; }
        public ClanWarAttack SecondAttack { get; set; }

    }
}
