using Dapper.Contrib.Extensions;
using System;

namespace ClashEntities
{
    [Table("Warriors")]
    public class Warrior : IDatabaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public int TownHallLevel { get; set; }
        public TownHallLevelMaturities TownHallLevelMaturity { get; set; }
        public int ClanId { get; set; }
        [Write(false)] public Clan Clan { get; set; }
        [Write(false)] public string ClanName { get { return Clan.Name; } }
        public DateTime ArrivalDate { get; set; } = DateTime.Today;

        public override string ToString()
        {
            if(Clan != null)
            {
                return $"{Name} ({Clan.Name})";
            }

            return Name;
        }
    }
}
