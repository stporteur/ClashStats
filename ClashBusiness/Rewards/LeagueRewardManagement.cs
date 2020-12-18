using ClashEntities;
using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Rewards
{
    public class LeagueRewardManagement : ILeagueRewardManagement
    {
        public List<Reward> ComputeLeagueScore(LeagueWar league, LeagueScoreOptions options)
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

        private List<Reward> InitializeRewards(LeagueWar league)
        {
            var rewards = new List<Reward>();

            foreach (var player in league.Players)
            {
                rewards.Add(new Reward { Warrior = player, Score = 0 });
            }

            return rewards;
        }

        private void SetIndividualScores(Action<LeagueWar, Reward, LeagueScoreOptions> individualScoreAction, bool isOptionActivated, LeagueWar league, List<Reward> rewards, LeagueScoreOptions options)
        {
            if (isOptionActivated)
            {
                foreach (var reward in rewards)
                {
                    individualScoreAction(league, reward, options);
                }
            }
        }

        private void SetIndividualScoreWithStars(LeagueWar league, Reward reward, LeagueScoreOptions options)
        {
            int starScore = league.PlayersPerDay.SelectMany(x => x.Value).Where(x => x.PlayerId == reward.Warrior.Id).Sum(x => x.Stars);
            reward.Score += starScore;
        }

        private void SetIndividualScoreWithOpeningAttacks(LeagueWar league, Reward reward, LeagueScoreOptions options)
        {
            int higherAttacks = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.AttackedThLevel > x.CurrentThLevel
                && x.Stars >= options.HigherTownHallAttackMinimumStars).Count();

            reward.Score += (higherAttacks * options.HigherTownHallAttackPoints);
        }

        private void SetIndividualScoreWithAttacksNotDone(LeagueWar league, Reward reward, LeagueScoreOptions options)
        {
            int attacksNotDone = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.AttackDone == false).Count();

            reward.Score -= (attacksNotDone * options.NoAttackDonePoints);
        }

        private void SetIndividualScoreWithIncoherentAttacks(LeagueWar league, Reward reward, LeagueScoreOptions options)
        {
            int attacksNotDone = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.IsCoherentAttack == false).Count();

            reward.Score -= (attacksNotDone * options.IncoherentAttackPoints);
        }

        private void SetIndividualScoreWithStrategyNotFollowed(LeagueWar league, Reward reward, LeagueScoreOptions options)
        {
            int attacksNotDone = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.HasFollowedStrategy == false).Count();

            reward.Score -= (attacksNotDone * options.NotFollowedStrategyPoints);
        }

        private void SetIndividualScoreWithFailedWarFault(LeagueWar league, Reward reward, LeagueScoreOptions options)
        {
            int attacksNotDone = league.PlayersPerDay.SelectMany(x => x.Value).Where(x =>
                x.PlayerId == reward.Warrior.Id
                && x.FailedWarFault == true).Count();

            reward.Score -= (attacksNotDone * options.FailedWarFaultPoints);
        }
    }
}
