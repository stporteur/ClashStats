using System;
using System.Collections.Generic;

namespace ClashEntities
{
    public class Game : IDatabaseEntity
    {
        public int Id { get; set; }
        public Clan Clan { get; set; }
        public DateTime GamesDate { get; set; }
        public bool GamesEnded { get; set; }
        public List<GameWarrior> Players { get; set; }

    }
}
