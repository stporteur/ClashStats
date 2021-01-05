﻿
using ClashBusiness.ScoreOptions;
using ClashData;
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
        private readonly IScoreOptionsLoader _scoreOptionsLoader;

        public LeagueRewardManagement(IScoreOptionsLoader scoreOptionsLoader)
        {
            _scoreOptionsLoader = scoreOptionsLoader;
        }

        public List<IAbstractReward> ComputeLeagueScore(LeagueWar leagueWar)
        {
            var rewards = ComputeLeagueScore(leagueWar, _scoreOptionsLoader.LoadLeagueScoreOptions());

            return rewards.Cast<IAbstractReward>().ToList();
        }

        private List<LeagueReward> ComputeLeagueScore(LeagueWar league, LeagueScoreOptions options)
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

        private List<LeagueReward> InitializeRewards(LeagueWar league)
        {
            var rewards = new List<LeagueReward>();

            foreach (var player in league.Players)
            {
                rewards.Add(new LeagueReward { Warrior = player, Score = 0 });
            }

            return rewards;
        }

        private void SetIndividualScores(Action<LeagueWar, LeagueReward, LeagueScoreOptions> individualScoreAction, bool isOptionActivated, LeagueWar league, List<LeagueReward> rewards, LeagueScoreOptions options)
        {
            if (isOptionActivated)
            {
                foreach (var reward in rewards)
                {
                    individualScoreAction(league, reward, options);
                }
            }
        }

        private void SetIndividualScoreWithStars(LeagueWar league, LeagueReward reward, LeagueScoreOptions options)
        {
            int starScore = league.PlayersPerDay.SelectMany(x => x.Value).Where(x => x.PlayerId == reward.Warrior.Id).Sum(x => x.Stars);
            reward.TotalStars = starScore;
            reward.Score += starScore;
        }

        private void SetIndividualScoreWithOpeningAttacks(LeagueWar league, LeagueReward reward, LeagueScoreOptions options)
        {
            int higherAttacks = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.AttackedThLevel > x.CurrentThLevel
                && x.Stars >= options.HigherTownHallAttackMinimumStars).Count();

            reward.TotalHigherAttacks = higherAttacks;
            reward.Score += (higherAttacks * options.HigherTownHallAttackPoints);
        }

        private void SetIndividualScoreWithAttacksNotDone(LeagueWar league, LeagueReward reward, LeagueScoreOptions options)
        {
            int attacksNotDone = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.AttackDone == false).Count();

            reward.TotalAttacksNotDone = attacksNotDone;
            reward.Score -= (attacksNotDone * options.NoAttackDonePoints);
        }

        private void SetIndividualScoreWithIncoherentAttacks(LeagueWar league, LeagueReward reward, LeagueScoreOptions options)
        {
            int incoherentAttacks = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.IsCoherentAttack == false).Count();

            reward.TotalIncoherentAttacks = incoherentAttacks;
            reward.Score -= (incoherentAttacks * options.IncoherentAttackPoints);
        }

        private void SetIndividualScoreWithStrategyNotFollowed(LeagueWar league, LeagueReward reward, LeagueScoreOptions options)
        {
            int notFollowedStrategy = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.HasFollowedStrategy == false).Count();

            reward.TotalNotFollowedStrategy = notFollowedStrategy;
            reward.Score -= (notFollowedStrategy * options.NotFollowedStrategyPoints);
        }

        private void SetIndividualScoreWithFailedWarFault(LeagueWar league, LeagueReward reward, LeagueScoreOptions options)
        {
            int failedWarFault = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.FailedWarFault == true).Count();

            reward.TotalFailedWarFault = failedWarFault;
            reward.Score -= (failedWarFault * options.FailedWarFaultPoints);
        }
    }
}
