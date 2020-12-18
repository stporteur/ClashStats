using System;
using System.Collections.Generic;

namespace ClashEntities
{
    public class LeagueWar
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public DateTime WarDate { get; set; }
        public int Position { get; set; }
        public Dictionary<int, List<LeagueWarPlayer>> PlayersPerDay { get; set; }
        public List<Warrior> Players { get; set; }
    }
}
