using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace ClashEntities
{
    [Table("Leagues")]
    public class League : IDatabaseEntity
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        [Write(false)] public Clan Clan { get; set; }
        public DateTime LeagueDate { get; set; }
        public int LeagueSize { get; set; }
        public int Position { get; set; }
        [Write(false)] public Dictionary<int, List<LeagueAttack>> PlayersPerDay { get; set; }
        [Write(false)] public List<Warrior> Players { get; set; }
    }
}
