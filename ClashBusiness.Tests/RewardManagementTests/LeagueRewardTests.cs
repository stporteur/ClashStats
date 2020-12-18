using ClashBusiness.Rewards;
using ClashEntities;
using ClashEntities.ScoreOptions;
using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Tests.RewardManagementTests
{
    public class LeagueRewardTests
    {
        private LeagueRewardManagement _rewardManagement;
        private LeagueWar _league;
        private LeagueScoreOptions _options;

        [SetUp]
        public void Setup()
        {
            _rewardManagement = new LeagueRewardManagement();

            _league = new LeagueWar();
            _league.Id = 1;
            _league.ClanId = 99;
            _league.Clan = new Clan { Id = 99, Name = "Test Clan" };
            _league.WarDate = DateTime.Today.AddDays(-7);
            _league.Position = 3;
            _league.Players = new List<Warrior>
            {
                new Warrior { Id = 100, Name = "Warrior 1", Hash = "Warrior1", ArrivalDate = _league.WarDate, Clan = _league.Clan, TownHallLevel = 13, TownHallLevelMaturity = TownHallLevelMaturities.Max },
                new Warrior { Id = 101, Name = "Warrior 2", Hash = "Warrior2", ArrivalDate = _league.WarDate, Clan = _league.Clan, TownHallLevel = 13, TownHallLevelMaturity = TownHallLevelMaturities.Max },
                new Warrior { Id = 102, Name = "Warrior 3", Hash = "Warrior3", ArrivalDate = _league.WarDate, Clan = _league.Clan, TownHallLevel = 13, TownHallLevelMaturity = TownHallLevelMaturities.Max },
                new Warrior { Id = 103, Name = "Warrior 4", Hash = "Warrior4", ArrivalDate = _league.WarDate, Clan = _league.Clan, TownHallLevel = 13, TownHallLevelMaturity = TownHallLevelMaturities.Max }
            };

            _league.PlayersPerDay = new Dictionary<int, List<LeagueWarPlayer>>();
            for (int leagueDay = 1; leagueDay <= 7; leagueDay++)
            {
                _league.PlayersPerDay.Add(leagueDay, new List<LeagueWarPlayer>());

                for (int playerNumber = 0; playerNumber < _league.Players.Count; playerNumber++)
                {
                    AddPlayerToDay(leagueDay, playerNumber);
                }
            }

            _options = new LeagueScoreOptions();

            _options.ScoreStarResults = true;

            _options.ScoreHigherTownHallVillageAttack = true;
            _options.HigherTownHallAttackMinimumStars = 2;
            _options.HigherTownHallAttackPoints = 5;

            _options.ScoreNoAttackDone = true;
            _options.NoAttackDonePoints = 5;

            _options.ScoreIncoherentAttack = true;
            _options.IncoherentAttackPoints = 2;

            _options.ScoreNotFollowedStrategy = true;
            _options.NotFollowedStrategyPoints = 10;

            _options.ScoreFailedWarFault = true;
            _options.FailedWarFaultPoints = 50;
        }

        private void AddPlayerToDay(int leagueDay, int playerNumber)
        {
            _league.PlayersPerDay[leagueDay].Add(new LeagueWarPlayer
            {
                Id = playerNumber + 1,
                LeagueId = _league.Id,
                PlayerId = _league.Players[playerNumber].Id,
                Player = _league.Players[playerNumber],
                Position = playerNumber + 1,
                AttackDone = true,
                IsCoherentAttack = true,
                HasFollowedStrategy = true,
                FailedWarFault = false
            });
        }

        [Test]
        public void Should_return_same_number_of_reward_than_players()
        {
            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            Check.That(rewards).HasSize(_league.Players.Count);
            foreach (var reward in rewards)
            {
                Check.That(_league.Players).Contains(reward.Warrior);
            }
        }

        [Test]
        public void Should_score_reward_with_stars_number_when_first_day_is_over()
        {
            _league.PlayersPerDay[1][0].Stars = 0;
            _league.PlayersPerDay[1][1].Stars = 2;
            _league.PlayersPerDay[1][2].Stars = 3;
            _league.PlayersPerDay[1][3].Stars = 1;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            foreach (var reward in rewards)
            {
                Check.That(reward.Score).IsEqualTo(_league.PlayersPerDay[1].Single(x => x.PlayerId == reward.Warrior.Id).Stars);
            }
        }

        [Test]
        public void Should_score_reward_with_stars_number_when_all_days_are_over()
        {
            for (int i = 1; i <= 7; i++)
            {
                _league.PlayersPerDay[i][0].Stars = 1;
            }

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(7);
        }

        [Test]
        public void Should_not_score_reward_with_stars_number_when_option_is_deactivated()
        {
            _league.PlayersPerDay[1][0].Stars = 3;

            _options.ScoreStarResults = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(0);
        }

        [Test]
        public void Should_score_reward_with_opening_attack_when_first_day_is_over()
        {
            _league.PlayersPerDay[1][0].Stars = 2;
            _league.PlayersPerDay[1][0].CurrentThLevel = 10;
            _league.PlayersPerDay[1][0].AttackedThLevel = 11;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(7);
        }

        [Test]
        public void Should_score_reward_with_opening_attack_when_all_days_are_over()
        {
            for (int i = 1; i <= 7; i++)
            {
                _league.PlayersPerDay[i][0].Stars = 2;
                _league.PlayersPerDay[i][0].CurrentThLevel = 10;
                _league.PlayersPerDay[i][0].AttackedThLevel = 11;
            }

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(49);
        }

        [Test]
        public void Should_not_score_reward_with_opening_attack_when_option_is_deactivated()
        {
            _league.PlayersPerDay[1][0].Stars = 2;
            _league.PlayersPerDay[1][0].CurrentThLevel = 10;
            _league.PlayersPerDay[1][0].AttackedThLevel = 11;

            _options.ScoreHigherTownHallVillageAttack = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(2);
        }

        [Test]
        public void Should_score_reward_on_no_attack_done_when_first_day_is_over()
        {
            _league.PlayersPerDay[1][0].Stars = 0;
            _league.PlayersPerDay[1][0].AttackDone = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-5);
        }

        [Test]
        public void Should_score_reward_on_no_attack_done_when_all_days_are_over()
        {
            for (int i = 1; i <= 7; i++)
            {
                _league.PlayersPerDay[i][0].Stars = 0;
                _league.PlayersPerDay[i][0].AttackDone = false;
            }

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-35);
        }

        [Test]
        public void Should_not_score_reward_on_no_attack_done_when_option_is_deactivated()
        {
            _league.PlayersPerDay[1][0].Stars = 0;
            _league.PlayersPerDay[1][0].AttackDone = false;

            _options.ScoreNoAttackDone = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(0);
        }

        [Test]
        public void Should_score_reward_on_incoherent_attack_when_first_day_is_over()
        {
            _league.PlayersPerDay[1][0].Stars = 1;
            _league.PlayersPerDay[1][0].IsCoherentAttack = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-1);
        }

        [Test]
        public void Should_score_reward_on_incoherent_attack_when_all_days_are_over()
        {
            for (int i = 1; i <= 7; i++)
            {
                _league.PlayersPerDay[i][0].Stars = 1;
                _league.PlayersPerDay[i][0].IsCoherentAttack = false;
            }

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-7);
        }

        [Test]
        public void Should_not_score_reward_on_incoherent_attack_when_option_is_deactivated()
        {
            _league.PlayersPerDay[1][0].Stars = 1;
            _league.PlayersPerDay[1][0].IsCoherentAttack = false;

            _options.ScoreIncoherentAttack = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(1);
        }

        [Test]
        public void Should_score_reward_on_not_followed_strategy_when_first_day_is_over()
        {
            _league.PlayersPerDay[1][0].Stars = 1;
            _league.PlayersPerDay[1][0].HasFollowedStrategy = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-9);
        }

        [Test]
        public void Should_score_reward_on_not_followed_strategy_when_all_days_are_over()
        {
            for (int i = 1; i <= 7; i++)
            {
                _league.PlayersPerDay[i][0].Stars = 1;
                _league.PlayersPerDay[i][0].HasFollowedStrategy = false;
            }

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-63);
        }

        [Test]
        public void Should_not_score_reward_on_not_followed_strategy_when_option_is_deactivated()
        {
            _league.PlayersPerDay[1][0].Stars = 1;
            _league.PlayersPerDay[1][0].HasFollowedStrategy = false;

            _options.ScoreNotFollowedStrategy = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(1);
        }

        [Test]
        public void Should_score_reward_on_failed_war_fault_when_first_day_is_over()
        {
            _league.PlayersPerDay[1][0].Stars = 0;
            _league.PlayersPerDay[1][0].FailedWarFault = true;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-50);
        }

        [Test]
        public void Should_score_reward_on_failed_war_fault_when_all_days_are_over()
        {
            for (int i = 1; i <= 7; i++)
            {
                _league.PlayersPerDay[i][0].Stars = 0;
                _league.PlayersPerDay[i][0].FailedWarFault = true;
            }

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(-350);
        }

        [Test]
        public void Should_not_score_reward_on_failed_war_fault_when_option_is_deactivated()
        {
            _league.PlayersPerDay[1][0].Stars = 0;
            _league.PlayersPerDay[1][0].FailedWarFault = true;

            _options.ScoreFailedWarFault = false;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            var reward = rewards.Single(x => x.Warrior.Id == _league.PlayersPerDay[1][0].PlayerId);
            Check.That(reward.Score).IsEqualTo(0);
        }

        [Test]
        public void Should_order_score_rewards_with_stars_number_when_first_day_is_over()
        {
            _league.PlayersPerDay[1][2].Stars = 3;
            _league.PlayersPerDay[1][1].Stars = 2;
            _league.PlayersPerDay[1][3].Stars = 1;
            _league.PlayersPerDay[1][0].Stars = 0;

            var rewards = _rewardManagement.ComputeLeagueScore(_league, _options);

            for (int i = 0; i < rewards.Count - 1; i++)
            {
                Check.That(rewards[i].Score).IsStrictlyGreaterThan(rewards[i + 1].Score);
            }
        }
    }
}
