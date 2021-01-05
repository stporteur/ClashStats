using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashEntities
{
    public class ClanWarAttack : WarAttack
    {
        public int ClanWarPlayerId { get; set; }
        public int ClanWarId { get; set; }
        public int AttackNumber { get; set; }
        public bool IsOpeningAttack { get; set; }
    }
}
