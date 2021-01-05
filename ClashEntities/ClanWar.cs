using System;
using System.Collections.Generic;

namespace ClashEntities
{
    public class ClanWar
    {
        public int Id { get; set; }
        public string Clan { get; set; }
        public DateTime WarDate { get; set; }
        public int OurStars { get; set; }
        public double OurPercent { get; set; }
        public int TheirStars { get; set; }
        public double TheirPercent { get; set; }
        public bool IsWin
        { 
            get
            {
                return (OurStars > TheirStars) || (OurStars == TheirStars && OurPercent > TheirPercent);
            } 
        }

        public List<ClanWarPlayer> Players { get; set; }

    }
}
