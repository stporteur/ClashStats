using ClashEntities;
using ClashEntities.Rewards;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Rewards
{
    public class RewardManagement : IRewardManagement
    {
        private readonly List<IScoreRewardManagement> _scoreRewardManagers;

        public RewardManagement(List<IScoreRewardManagement> scoreRewardManagers)
        {
            _scoreRewardManagers = scoreRewardManagers;
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

            foreach (var player in league.Players)
            {
                rewards.Add(new Reward { Warrior = player, Score = 0, RewardDetails = new List<IAbstractReward>() });
            }

            return rewards;
        }
    }
}
