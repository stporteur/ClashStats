using ClashBusiness.Rewards;
using ClashEntities;
using ClashEntities.Rewards;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Tests.RewardManagementTests
{
    public class RewardTests
    {
        private RewardManagement _rewardManagement;
        private League _league;
        private List<Warrior> _warriors;
        private List<IScoreRewardManagement> _dummyManagers;

        [SetUp]
        public void Setup()
        {
            _dummyManagers = new List<IScoreRewardManagement>
            {
                Substitute.For<IScoreRewardManagement>(),
                Substitute.For<IScoreRewardManagement>()
            };

            _rewardManagement = new RewardManagement(_dummyManagers);

            _league = new League();
            _league.Id = 1;
            _warriors = new List<Warrior>
            {
                new Warrior { Id = 100, Name = "Warrior 1" },
                new Warrior { Id = 101, Name = "Warrior 2" }
            };
        }

        [Test]
        public void Should_return_same_number_of_rewards_than_players_with_score_set_to_0_when_getting_rank_suggestion()
        {
            _league.Players = _warriors;
            foreach (var dummyManager in _dummyManagers)
            {
                dummyManager.ComputeLeagueScore(_league).Returns(new List<IAbstractReward>());
            }
            var rewards = _rewardManagement.GetRankSuggestion(_league);

            Check.That(rewards).HasSize(_league.Players.Count);
            foreach (var player in _league.Players)
            {
                var reward = rewards.Single(r => r.Warrior.Id == player.Id);
                Check.That(reward.Score).IsEqualTo(0);
            }
        }

        [Test]
        public void Should_call_each_score_manager_with_current_league_when_getting_rank_suggestion()
        {
            _league.Players = _warriors;
            foreach (var dummyManager in _dummyManagers)
            {
                dummyManager.ComputeLeagueScore(_league).Returns(new List<IAbstractReward>());
            }
            var rewards = _rewardManagement.GetRankSuggestion(_league);

            foreach (var dummyManager in _dummyManagers)
            {
                dummyManager.Received(1).ComputeLeagueScore(_league);
            }
        }

        [Test]
        public void Should_score_player_with_one_score_managers_when_getting_rank_suggestion()
        {
            _league.Players = new List<Warrior> { _warriors[0] };

            _dummyManagers[0].ComputeLeagueScore(_league).Returns(new List<IAbstractReward>
            {
                new WarriorReward { Score = 1, Warrior = _league.Players[0] }
            });
            _dummyManagers[1].ComputeLeagueScore(_league).Returns(new List<IAbstractReward>());

            var rewards = _rewardManagement.GetRankSuggestion(_league);

            Check.That(rewards[0].Warrior).IsEqualTo(_warriors[0]);
            Check.That(rewards[0].Score).IsEqualTo(1);
            Check.That(rewards[0].RewardDetails).HasSize(1);
            Check.That(rewards[0].RewardDetails[0]).IsInstanceOf<WarriorReward>();
        }

        [Test]
        public void Should_score_player_with_two_score_managers_when_getting_rank_suggestion()
        {
            _league.Players = new List<Warrior> { _warriors[0] };

            _dummyManagers[0].ComputeLeagueScore(_league).Returns(new List<IAbstractReward>
            {
                new WarriorReward { Score = 1, Warrior = _league.Players[0] }
            });
            _dummyManagers[1].ComputeLeagueScore(_league).Returns(new List<IAbstractReward>
            {
                new LeagueReward { Score = 1, Warrior = _league.Players[0] }
            });

            var rewards = _rewardManagement.GetRankSuggestion(_league);

            Check.That(rewards[0].Warrior).IsEqualTo(_warriors[0]);
            Check.That(rewards[0].Score).IsEqualTo(2);
            Check.That(rewards[0].RewardDetails).HasSize(2);
            Check.That(rewards[0].RewardDetails[0]).IsInstanceOf<WarriorReward>();
            Check.That(rewards[0].RewardDetails[1]).IsInstanceOf<LeagueReward>();
        }

        [Test]
        public void Should_order_score_rewards_when_getting_rank_suggestion()
        {
            _league.Players = _warriors;

            _dummyManagers[0].ComputeLeagueScore(_league).Returns(new List<IAbstractReward>
            {
                new WarriorReward { Score = 1, Warrior = _league.Players[0] },
                new WarriorReward { Score = 4, Warrior = _league.Players[1] },
            });
            _dummyManagers[1].ComputeLeagueScore(_league).Returns(new List<IAbstractReward>
            {
                new LeagueReward { Score = 3, Warrior = _league.Players[0] },
                new LeagueReward { Score = 6, Warrior = _league.Players[1] }
            });

            var rewards = _rewardManagement.GetRankSuggestion(_league);

            Check.That(rewards[0].Warrior).IsEqualTo(_league.Players[1]);
            Check.That(rewards[1].Warrior).IsEqualTo(_league.Players[0]);
            for (int i = 0; i < rewards.Count - 1; i++)
            {
                Check.That(rewards[i].Score).IsStrictlyGreaterThan(rewards[i + 1].Score);
            }
        }
    }
}
