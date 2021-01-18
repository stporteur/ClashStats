using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace ClashEntities
{
    [Table("Wars")]
    public class War : IDatabaseEntity
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
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

        public List<WarPlayer> Players { get; set; }

    }
}
