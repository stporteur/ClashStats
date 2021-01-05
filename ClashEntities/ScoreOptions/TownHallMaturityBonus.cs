using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashEntities.ScoreOptions
{
    public class TownHallMaturityBonus
    {
        public int TownHallLevel { get; set; }
        public TownHallLevelMaturities Maturity { get; set; }
        public int Bonus { get; set; }
    }
}
