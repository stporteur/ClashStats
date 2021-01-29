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
        [Write(false)] public Clan Clan { get; set; }
        public int WarSize { get; set; }
        public DateTime WarDate { get; set; }
        public int OurStars { get; set; }
        public double OurPercent { get; set; }
        public int TheirStars { get; set; }
        public double TheirPercent { get; set; }
        [Write(false)] public bool IsWin
        { 
            get
            {
                return (OurStars > TheirStars) || (OurStars == TheirStars && OurPercent > TheirPercent);
            } 
        }

        [Write(false)] public List<WarPlayer> Players { get; set; }

    }
}
