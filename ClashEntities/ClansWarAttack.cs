using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashEntities
{
    public class ClansWarAttack : WarAttack
    {
        public int ClansWarPlayerId { get; set; }
        public int ClansWarId { get; set; }
        public int AttackNumber { get; set; }
        public bool IsOpeningAttack { get; set; }
    }
}
