using ClashData;
using ClashEntities;
using ClashEntities.Rewards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Rewards
{
    public class RewardManagement : IRewardManagement
    {
        private readonly IEnumerable<IScoreRewardManagement> _scoreRewardManagers;
        private readonly ILeagueBonusDal _leagueBonusDal;

        public RewardManagement(IEnumerable<IScoreRewardManagement> scoreRewardManagers, ILeagueBonusDal leagueBonusDal)
        {
            _scoreRewardManagers = scoreRewardManagers;
            _leagueBonusDal = leagueBonusDal;
        }

        public List<Reward> GetRankSuggestion(League leagueWar)
        {
            var rewards = InitializeRewards(leagueWar);

            foreach (var scoreManagers in _scoreRewardManagers)
            {
                var leagueRewards = scoreManagers.ComputeLeagueScore(leagueWar);
                AssignScores(rewards, leagueRewards);
            }

            return rewards.OrderByDescending(x => x.Score).ToList();
        }

        public void GiveRewards(DateTime leagueDate, List<int> warriors)
        {
            foreach(var warriorId in warriors)
            {
                var bonus = new LeagueBonus
                {
                    WarriorId = warriorId,
                    BonusDate = leagueDate
                };

                _leagueBonusDal.Insert(bonus);
            }
        }

        private void AssignScores(List<Reward> rewards, List<IAbstractReward> newRewards)
        {
            foreach (var newReward in newRewards)
            {
                var reward = rewards.SingleOrDefault(r => r.Warrior.Id == newReward.Warrior.Id);
                if (reward != null)
                {
                    reward.RewardDetails.Add(newReward);
                    reward.Score += newReward.Score;
                }
            }
        }

        private List<Reward> InitializeRewards(League league)
        {
            var rewards = new List<Reward>();

            foreach (var player in league.Players.Where(x=> x.WantsBonus == true))
            {
                rewards.Add(new Reward { Warrior = player, Score = 0, RewardDetails = new List<IAbstractReward>() });
            }

            return rewards;
        }
    }
}
