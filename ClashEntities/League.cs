using System;
using System.Collections.Generic;

namespace ClashEntities
{
    public class League : IDatabaseEntity
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public DateTime LeagueDate { get; set; }
        public int Position { get; set; }
        public Dictionary<int, List<LeaguePlayer>> PlayersPerDay { get; set; }
        public List<Warrior> Players { get; set; }
    }
}
