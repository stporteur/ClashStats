using System;

namespace ClashEntities
{
    public class ClansWarPlayer
    {
        public int Id { get; set; }
        public int ClansWarId { get; set; }
        public int WarriorId { get; set; }
        public Warrior Warrior { get; set; }
        public int Position { get; set; }
        public int FirstAttackId { get; set; }
        public ClansWarAttack FirstAttack { get; set; }
        public int SecondAttackId { get; set; }
        public ClansWarAttack SecondAttack { get; set; }

    }
}
