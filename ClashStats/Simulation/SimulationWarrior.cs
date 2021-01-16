using ClashEntities;

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
