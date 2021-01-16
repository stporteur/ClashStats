using System;

namespace ClashEntities
{
    public class Warrior : IDatabaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public int TownHallLevel { get; set; }
        public TownHallLevelMaturities TownHallLevelMaturity { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
