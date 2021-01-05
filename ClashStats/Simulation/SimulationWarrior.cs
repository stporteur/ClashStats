﻿using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashStats.Simulation
{
    public class SimulationWarrior : Warrior
    {
        public int TotalNumberOfLeagues { get; set; }
        public int ParticipateToLeagues { get; set; }
        public int TotalNumberOfWars { get; set; }
        public int ParticipateToWars { get; set; }
        public int TotalNumberOfGames { get; set; }
        public int ParticipateToGames { get; set; }
        public int SucceedeedGames { get; set; }
    }
}
