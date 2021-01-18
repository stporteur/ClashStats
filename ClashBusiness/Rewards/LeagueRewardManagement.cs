
using ClashBusiness.ScoreOptions;
using ClashEntities;
using ClashEntities.Rewards;
using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Rewards
{
    public class LeagueRewardManagement : IScoreRewardManagement
    {
        private readonly IScoreOptionsManagement _scoreOptionsLoader;

        public LeagueRewardManagement(IScoreOptionsManagement scoreOptionsLoader)
        {
            _scoreOptionsLoader = scoreOptionsLoader;
        }

        public List<IAbstractReward> ComputeLeagueScore(League leagueWar)
        {
            var rewards = ComputeLeagueScore(leagueWar, _scoreOptionsLoader.LoadLeagueScoreOptions());

            return rewards.Cast<IAbstractReward>().ToList();
        }

        private List<LeagueReward> ComputeLeagueScore(League league, LeagueScoreOptions options)
        {
            var rewards = InitializeRewards(league);

            SetIndividualScores(SetIndividualScoreWithStars, options.ScoreStarResults, league, rewards, options);
            SetIndividualScores(SetIndividualScoreWithOpeningAttacks, options.ScoreHigherTownHallVillageAttack, league, rewards, options);
            SetIndividualScores(SetIndividualScoreWithAttacksNotDone, options.ScoreNoAttackDone, league, rewards, options);
            SetIndividualScores(SetIndividualScoreWithIncoherentAttacks, options.ScoreIncoherentAttack, league, rewards, options);
            SetIndividualScores(SetIndividualScoreWithStrategyNotFollowed, options.ScoreNotFollowedStrategy, league, rewards, options);
            SetIndividualScores(SetIndividualScoreWithFailedWarFault, options.ScoreFailedWarFault, league, rewards, options);

            return rewards.OrderByDescending(x=>x.Score).ToList();
        }

        private List<LeagueReward> InitializeRewards(League league)
        {
            var rewards = new List<LeagueReward>();

            foreach (var player in league.Players)
            {
                rewards.Add(new LeagueReward { Warrior = player, Score = 0 });
            }

            return rewards;
        }

        private void SetIndividualScores(Action<League, LeagueReward, LeagueScoreOptions> individualScoreAction, bool isOptionActivated, League league, List<LeagueReward> rewards, LeagueScoreOptions options)
        {
            if (isOptionActivated)
            {
                foreach (var reward in rewards)
                {
                    individualScoreAction(league, reward, options);
                }
            }
        }

        private void SetIndividualScoreWithStars(League league, LeagueReward reward, LeagueScoreOptions options)
        {
            int starScore = league.PlayersPerDay.SelectMany(x => x.Value).Where(x => x.WarriorId == reward.Warrior.Id).Sum(x => x.Stars);
            reward.TotalStars = starScore;
            reward.Score += starScore;
        }

        private void SetIndividualScoreWithOpeningAttacks(League league, LeagueReward reward, LeagueScoreOptions options)
        {
            int higherAttacks = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.WarriorId == reward.Warrior.Id
                && x.AttackedThLevel > x.CurrentThLevel
                && x.Stars >= options.HigherTownHallAttackMinimumStars).Count();

            reward.TotalHigherAttacks = higherAttacks;
            reward.Score += (higherAttacks * options.HigherTownHallAttackPoints);
        }

        private void SetIndividualScoreWithAttacksNotDone(League league, LeagueReward reward, LeagueScoreOptions options)
        {
            int attacksNotDone = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.WarriorId == reward.Warrior.Id
                && x.AttackDone == false).Count();

            reward.TotalAttacksNotDone = attacksNotDone;
            reward.Score -= (attacksNotDone * options.NoAttackDonePoints);
        }

        private void SetIndividualScoreWithIncoherentAttacks(League league, LeagueReward reward, LeagueScoreOptions options)
        {
            int incoherentAttacks = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.WarriorId == reward.Warrior.Id
                && x.IsCoherentAttack == false).Count();

            reward.TotalIncoherentAttacks = incoherentAttacks;
            reward.Score -= (incoherentAttacks * options.IncoherentAttackPoints);
        }

        private void SetIndividualScoreWithStrategyNotFollowed(League league, LeagueReward reward, LeagueScoreOptions options)
        {
            int notFollowedStrategy = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.WarriorId == reward.Warrior.Id
                && x.HasFollowedStrategy == false).Count();

            reward.TotalNotFollowedStrategy = notFollowedStrategy;
            reward.Score -= (notFollowedStrategy * options.NotFollowedStrategyPoints);
        }

        private void SetIndividualScoreWithFailedWarFault(League league, LeagueReward reward, LeagueScoreOptions options)
        {
            int failedWarFault = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.WarriorId == reward.Warrior.Id
                && x.FailedWarFault == true).Count();

            reward.TotalFailedWarFault = failedWarFault;
            reward.Score -= (failedWarFault * options.FailedWarFaultPoints);
        }
    }
}
