using ClashData;
using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.ScoreOptions
{
    public class ScoreOptionsManagement : IScoreOptionsManagement
    {
        private readonly IScoreOptionsDal _scoreOptionsDal;
        private readonly ISeniorityScoreOptionsDal _seniorityScoreOptionsDal;
        private readonly ITownHallLevelScoreOptionsDal _townHallLevelScoreOptionsDal;

        public ScoreOptionsManagement(
            IScoreOptionsDal scoreOptionsDal,
            ISeniorityScoreOptionsDal seniorityScoreOptionsDal,
            ITownHallLevelScoreOptionsDal townHallLevelScoreOptionsDal)
        {
            _scoreOptionsDal = scoreOptionsDal;
            _seniorityScoreOptionsDal = seniorityScoreOptionsDal;
            _townHallLevelScoreOptionsDal = townHallLevelScoreOptionsDal;
        }

        public LeagueScoreOptions LoadLeagueScoreOptions()
        {
            var options = _scoreOptionsDal.GetAll().Where(x => x.ScoreType == "LEAGUE");
            return new LeagueScoreOptions
            {
                ScoreStarResults = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreStarResults").ScoreValue),

                ScoreHigherTownHallVillageAttack = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreHigherTownHallVillageAttack").ScoreValue),
                HigherTownHallAttackMinimumStars = Convert.ToInt32(options.Single(x => x.ScoreName == "HigherTownHallAttackMinimumStars").ScoreValue),
                HigherTownHallAttackPoints = Convert.ToInt32(options.Single(x => x.ScoreName == "HigherTownHallAttackPoints").ScoreValue),

                ScoreNoAttackDone = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreNoAttackDone").ScoreValue),
                NoAttackDonePoints = Convert.ToInt32(options.Single(x => x.ScoreName == "NoAttackDonePoints").ScoreValue),

                ScoreIncoherentAttack = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreIncoherentAttack").ScoreValue),
                IncoherentAttackPoints = Convert.ToInt32(options.Single(x => x.ScoreName == "IncoherentAttackPoints").ScoreValue),

                ScoreNotFollowedStrategy = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreNotFollowedStrategy").ScoreValue),
                NotFollowedStrategyPoints = Convert.ToInt32(options.Single(x => x.ScoreName == "NotFollowedStrategyPoints").ScoreValue),

                ScoreFailedWarFault = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreFailedWarFault").ScoreValue),
                FailedWarFaultPoints = Convert.ToInt32(options.Single(x => x.ScoreName == "FailedWarFaultPoints").ScoreValue)
            };
        }

        public bool SaveLeagueScoreOptions(LeagueScoreOptions leagueScoreOptions)
        {
            var options = _scoreOptionsDal.GetAll().Where(x => x.ScoreType == "LEAGUE").ToList();

            options.Single(x => x.ScoreName == "ScoreStarResults").ScoreValue = leagueScoreOptions.ScoreStarResults ? "true" : "false";

            options.Single(x => x.ScoreName == "ScoreHigherTownHallVillageAttack").ScoreValue = leagueScoreOptions.ScoreHigherTownHallVillageAttack ? "true" : "false";
            options.Single(x => x.ScoreName == "HigherTownHallAttackMinimumStars").ScoreValue = leagueScoreOptions.HigherTownHallAttackMinimumStars.ToString();
            options.Single(x => x.ScoreName == "HigherTownHallAttackPoints").ScoreValue = leagueScoreOptions.HigherTownHallAttackPoints.ToString();

            options.Single(x => x.ScoreName == "ScoreNoAttackDone").ScoreValue = leagueScoreOptions.ScoreNoAttackDone ? "true" : "false";
            options.Single(x => x.ScoreName == "NoAttackDonePoints").ScoreValue = leagueScoreOptions.NoAttackDonePoints.ToString();

            options.Single(x => x.ScoreName == "ScoreIncoherentAttack").ScoreValue = leagueScoreOptions.ScoreIncoherentAttack ? "true" : "false";
            options.Single(x => x.ScoreName == "IncoherentAttackPoints").ScoreValue = leagueScoreOptions.IncoherentAttackPoints.ToString();

            options.Single(x => x.ScoreName == "ScoreNotFollowedStrategy").ScoreValue = leagueScoreOptions.ScoreNotFollowedStrategy ? "true" : "false";
            options.Single(x => x.ScoreName == "NotFollowedStrategyPoints").ScoreValue = leagueScoreOptions.NotFollowedStrategyPoints.ToString();

            options.Single(x => x.ScoreName == "ScoreFailedWarFault").ScoreValue = leagueScoreOptions.ScoreFailedWarFault ? "true" : "false";
            options.Single(x => x.ScoreName == "FailedWarFaultPoints").ScoreValue = leagueScoreOptions.FailedWarFaultPoints.ToString();

            bool succeed = true;
            options.ForEach(x => succeed &= _scoreOptionsDal.Update(x));

            return succeed;
        }

        public WarriorScoreOptions LoadWarriorScoreOptions()
        {
            var options = _scoreOptionsDal.GetAll().Where(x => x.ScoreType == "WARRIOR");
            return new WarriorScoreOptions
            {
                ScoreGameParticipation = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreGameParticipation").ScoreValue),
                GameParticipationPoints = Convert.ToInt32(options.Single(x => x.ScoreName == "GameParticipationPoints").ScoreValue),

                ScoreMinimumGamePoints = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreMinimumGamePoints").ScoreValue),
                MinimumGamePoints = Convert.ToInt32(options.Single(x => x.ScoreName == "MinimumGamePoints").ScoreValue),
                MinimumGamePointsThreshold = Convert.ToInt32(options.Single(x => x.ScoreName == "MinimumGamePointsThreshold").ScoreValue),

                ScoreLeagueParticipation = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreLeagueParticipation").ScoreValue),
                LeagueParticipationPoints = Convert.ToInt32(options.Single(x => x.ScoreName == "LeagueParticipationPoints").ScoreValue),

                ScoreWarParticipation = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreWarParticipation").ScoreValue),
                WarParticipationPoints = Convert.ToInt32(options.Single(x => x.ScoreName == "WarParticipationPoints").ScoreValue),

                ScoreSeniority = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreSeniority").ScoreValue),
                SeniorityPoints = _seniorityScoreOptionsDal.GetAll().OrderBy(x => x.MinimumMonth).ToList(),

                ScoreTownHallLevel = Convert.ToBoolean(options.Single(x => x.ScoreName == "ScoreTownHallLevel").ScoreValue),
                TownHallLevelPoints = _townHallLevelScoreOptionsDal.GetAll().OrderByDescending(x => x.TownHallLevel).ThenBy(x => (int)x.Maturity).ToList()
            };
        }

        public bool SaveWarriorScoreOptions(WarriorScoreOptions warriorScoreOptions)
        {
            var options = _scoreOptionsDal.GetAll().Where(x => x.ScoreType == "WARRIOR").ToList();

            options.Single(x => x.ScoreName == "ScoreMinimumGamePoints").ScoreValue = warriorScoreOptions.ScoreMinimumGamePoints ? "true" : "false";
            options.Single(x => x.ScoreName == "MinimumGamePoints").ScoreValue = warriorScoreOptions.MinimumGamePoints.ToString();
            options.Single(x => x.ScoreName == "MinimumGamePointsThreshold").ScoreValue = warriorScoreOptions.MinimumGamePointsThreshold.ToString();

            options.Single(x => x.ScoreName == "ScoreGameParticipation").ScoreValue = warriorScoreOptions.ScoreGameParticipation ? "true" : "false";
            options.Single(x => x.ScoreName == "GameParticipationPoints").ScoreValue = warriorScoreOptions.GameParticipationPoints.ToString();

            options.Single(x => x.ScoreName == "ScoreLeagueParticipation").ScoreValue = warriorScoreOptions.ScoreLeagueParticipation ? "true" : "false";
            options.Single(x => x.ScoreName == "LeagueParticipationPoints").ScoreValue = warriorScoreOptions.LeagueParticipationPoints.ToString();

            options.Single(x => x.ScoreName == "ScoreWarParticipation").ScoreValue = warriorScoreOptions.ScoreWarParticipation ? "true" : "false";
            options.Single(x => x.ScoreName == "WarParticipationPoints").ScoreValue = warriorScoreOptions.WarParticipationPoints.ToString();

            options.Single(x => x.ScoreName == "ScoreSeniority").ScoreValue = warriorScoreOptions.ScoreSeniority ? "true" : "false";
            options.Single(x => x.ScoreName == "ScoreTownHallLevel").ScoreValue = warriorScoreOptions.ScoreTownHallLevel ? "true" : "false";

            bool succeed = true;
            options.ForEach(x => succeed &= _scoreOptionsDal.Update(x));

            foreach(var seniority in warriorScoreOptions.SeniorityPoints)
            {
                if(seniority.Id == 0)
                {
                    _seniorityScoreOptionsDal.Insert(seniority);
                }
                else
                {
                    succeed &= _seniorityScoreOptionsDal.Update(seniority);
                }
            }

            foreach(var maturity in warriorScoreOptions.TownHallLevelPoints)
            {
                if(maturity.Id == 0)
                {
                    _townHallLevelScoreOptionsDal.Insert(maturity);
                }
                else
                {
                    succeed &= _townHallLevelScoreOptionsDal.Update(maturity);
                }
            }

            return succeed;
        }

        public bool DeleteTownHallLevelScoreOptions(List<TownHallMaturityBonus> maturities)
        {
            var result = true;
            foreach(var maturity in maturities)
            {
                result &= _townHallLevelScoreOptionsDal.Delete(maturity);
            }

            return result;
        }

        public bool DeleteSeniorityScoreOptions(List<SeniorityBonus> seniorities)
        {
            var result = true;
            foreach (var seniority in seniorities)
            {
                result &= _seniorityScoreOptionsDal.Delete(seniority);
            }

            return result;
        }
    }
}
