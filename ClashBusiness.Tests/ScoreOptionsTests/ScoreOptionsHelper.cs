using ClashData.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness.Tests.ScoreOptionsTests
{
    public class ScoreOptionsHelper
    {
        public static List<ScoreOption> GetLeagueOptions()
        {
            return new List<ScoreOption>
            {
                new ScoreOption { Id = 1, ScoreType = "LEAGUE", ScoreName = "ScoreStarResults", ScoreValue = "true"},
                new ScoreOption { Id = 2, ScoreType = "LEAGUE", ScoreName = "ScoreHigherTownHallVillageAttack", ScoreValue = "true"},
                new ScoreOption { Id = 3, ScoreType = "LEAGUE", ScoreName = "HigherTownHallAttackMinimumStars", ScoreValue = "2"},
                new ScoreOption { Id = 4, ScoreType = "LEAGUE", ScoreName = "HigherTownHallAttackPoints", ScoreValue = "10"},
                new ScoreOption { Id = 5, ScoreType = "LEAGUE", ScoreName = "ScoreNoAttackDone", ScoreValue = "true"},
                new ScoreOption { Id = 6, ScoreType = "LEAGUE", ScoreName = "NoAttackDonePoints", ScoreValue = "20"},
                new ScoreOption { Id = 7, ScoreType = "LEAGUE", ScoreName = "ScoreIncoherentAttack", ScoreValue = "true"},
                new ScoreOption { Id = 8, ScoreType = "LEAGUE", ScoreName = "IncoherentAttackPoints", ScoreValue = "30"},
                new ScoreOption { Id = 9, ScoreType = "LEAGUE", ScoreName = "ScoreNotFollowedStrategy", ScoreValue = "true"},
                new ScoreOption { Id = 10, ScoreType = "LEAGUE", ScoreName = "NotFollowedStrategyPoints", ScoreValue = "40"},
                new ScoreOption { Id = 11, ScoreType = "LEAGUE", ScoreName = "ScoreFailedWarFault", ScoreValue = "true"},
                new ScoreOption { Id = 12, ScoreType = "LEAGUE", ScoreName = "FailedWarFaultPoints", ScoreValue = "50"},
                new ScoreOption { Id = 13, ScoreType = "WARRIOR", ScoreName = "ScoreStarResults", ScoreValue = "false"}
            };
        }

        public static List<ScoreOption> GetWarriorOptions()
        {
            return new List<ScoreOption>
            {
                new ScoreOption { Id = 1, ScoreType = "WARRIOR", ScoreName = "ScoreGameParticipation", ScoreValue = "true"},
                new ScoreOption { Id = 4, ScoreType = "WARRIOR", ScoreName = "GameParticipationPoints", ScoreValue = "10"},
                new ScoreOption { Id = 2, ScoreType = "WARRIOR", ScoreName = "ScoreMinimumGamePoints", ScoreValue = "true"},
                new ScoreOption { Id = 3, ScoreType = "WARRIOR", ScoreName = "MinimumGamePointsThreshold", ScoreValue = "1000"},
                new ScoreOption { Id = 4, ScoreType = "WARRIOR", ScoreName = "MinimumGamePoints", ScoreValue = "20"},
                new ScoreOption { Id = 5, ScoreType = "WARRIOR", ScoreName = "ScoreSnippedGame", ScoreValue = "true"},
                new ScoreOption { Id = 6, ScoreType = "WARRIOR", ScoreName = "SnippedGamePoints", ScoreValue = "30"},
                new ScoreOption { Id = 5, ScoreType = "WARRIOR", ScoreName = "ScoreLeagueParticipation", ScoreValue = "true"},
                new ScoreOption { Id = 6, ScoreType = "WARRIOR", ScoreName = "LeagueParticipationPoints", ScoreValue = "40"},
                new ScoreOption { Id = 7, ScoreType = "WARRIOR", ScoreName = "ScoreWarParticipation", ScoreValue = "true"},
                new ScoreOption { Id = 8, ScoreType = "WARRIOR", ScoreName = "WarParticipationPoints", ScoreValue = "50"},
                new ScoreOption { Id = 9, ScoreType = "WARRIOR", ScoreName = "ScoreSeniority", ScoreValue = "true"},
                new ScoreOption { Id = 11, ScoreType = "WARRIOR", ScoreName = "ScoreTownHallLevel", ScoreValue = "true"},
                new ScoreOption { Id = 13, ScoreType = "WARRIOR", ScoreName = "ScoreLastLeagueBonus", ScoreValue = "true"},
                new ScoreOption { Id = 14, ScoreType = "WARRIOR", ScoreName = "LastLeagueBonusPoints", ScoreValue = "60"},
                new ScoreOption { Id = 15, ScoreType = "LEAGUE", ScoreName = "ScoreStarResults", ScoreValue = "false"}
            };
        }
    }
}
