using System;
using System.Collections.Generic;

namespace ClashEntities
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public bool GamesEnded { get; set; }
        public List<GameWarrior> Players { get; set; }

    }
}
