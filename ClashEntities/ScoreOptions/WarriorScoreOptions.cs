using System.Collections.Generic;

namespace ClashEntities.ScoreOptions
{
    public class WarriorScoreOptions
    {
        public bool ScoreLeagueParticipation { get; set; }
        public int LeagueParticipationPoints { get; set; }

        public bool ScoreWarParticipation { get; set; }
        public int WarParticipationPoints { get; set; }

        public bool ScoreGameParticipation { get; set; }
        public int GameParticipationPoints { get; set; }

        public bool ScoreMinimumGamePoints { get; set; }
        public int MinimumGamePointsThreshold { get; set; }
        public int MinimumGamePoints { get; set; }

        public bool ScoreTownHallLevel { get; set; }
        public List<TownHallMaturityBonus> TownHallLevelPoints { get; set; }

        public bool ScoreSeniority { get; set; }
        public List<SeniorityBonus> SeniorityPoints { get; set; }
    }
}
