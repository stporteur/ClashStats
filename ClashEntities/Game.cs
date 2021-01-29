using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace ClashEntities
{
    [Table("Games")]
    public class Game : IDatabaseEntity
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        [Write(false)] public Clan Clan { get; set; }
        public DateTime GamesDate { get; set; }
        public bool GamesEnded { get; set; }
        [Write(false)] public List<GameWarrior> Players { get; set; }

    }
}
