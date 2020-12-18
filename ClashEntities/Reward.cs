using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashEntities
{
    public class Reward
    {
        public string WarrioName { get { return Warrior.Name; } }
        public Warrior Warrior { get; set; }
        public int Score { get; set; }
    }
}
