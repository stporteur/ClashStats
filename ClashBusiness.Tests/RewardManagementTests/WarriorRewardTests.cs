using ClashBusiness.Rewards;
using ClashBusiness.ScoreOptions;
using ClashData;
using ClashEntities;
using ClashEntities.Rewards;
using ClashEntities.ScoreOptions;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Tests.RewardManagementTests
{
    public class WarriorRewardTests
    {
        private WarriorScoreOptions _warriorScoreOptions;
        private WarriorRewardManagement _warriorRewardManagement;
        private ILeagueDal _leagueWarDal;
        private IWarDal _clanWarDal;
        private IGameDal _gameDal;
        private IGameWarriorDal _gameWarriorDal;
        private List<Warrior> _warriors;
        private League _league;

        [SetUp]
        public void Setup()
        {
            var scoreOptionsLoader = Substitute.For<IScoreOptionsManagement>();

            _warriors = new List<Warrior>
            {
                new Warrior { Id = 1, ArrivalDate = DateTime.Today.AddDays(-5), TownHallLevel = 8, TownHallLevelMaturity = TownHallLevelMaturities.Beginning },
                new Warrior { Id = 2, ArrivalDate = DateTime.Today.AddMonths(-4), TownHallLevel = 8, TownHallLevelMaturity = TownHallLevelMaturities.Max },
                new Warrior { Id = 3, ArrivalDate = DateTime.Today.AddMonths(-24), TownHallLevel = 11, TownHallLevelMaturity = TownHallLevelMaturities.Beginning }
            };

            _league = new League();
            _league.Id = 1;

            _warriorScoreOptions = new WarriorScoreOptions();
            _warriorScoreOptions.LeagueParticipationPoints = 100;
            _warriorScoreOptions.WarParticipationPoints = 100;
            _warriorScoreOptions.GameParticipationPoints = 100;
            _warriorScoreOptions.MinimumGamePoints = 100;
            _warriorScoreOptions.MinimumGamePointsThreshold = 1000;
            _warriorScoreOptions.TownHallLevelPoints = new List<TownHallMaturityBonus>
            {
                new TownHallMaturityBonus{ TownHallLevel = 7, Maturity = TownHallLevelMaturities.Beginning, Bonus = 100},
                new TownHallMaturityBonus{ TownHallLevel = 7, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 95},
                new TownHallMaturityBonus{ TownHallLevel = 7, Maturity = TownHallLevelMaturities.Max, Bonus = 90},
                new TownHallMaturityBonus{ TownHallLevel = 8, Maturity = TownHallLevelMaturities.Beginning, Bonus = 85},
                new TownHallMaturityBonus{ TownHallLevel = 8, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 80},
                new TownHallMaturityBonus{ TownHallLevel = 8, Maturity = TownHallLevelMaturities.Max, Bonus = 75},
                new TownHallMaturityBonus{ TownHallLevel = 9, Maturity = TownHallLevelMaturities.Beginning, Bonus = 70},
                new TownHallMaturityBonus{ TownHallLevel = 9, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 65},
                new TownHallMaturityBonus{ TownHallLevel = 9, Maturity = TownHallLevelMaturities.Max, Bonus = 60},
                new TownHallMaturityBonus{ TownHallLevel = 10, Maturity = TownHallLevelMaturities.Beginning, Bonus = 55},
                new TownHallMaturityBonus{ TownHallLevel = 10, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 50},
                new TownHallMaturityBonus{ TownHallLevel = 10, Maturity = TownHallLevelMaturities.Max, Bonus = 45},
                new TownHallMaturityBonus{ TownHallLevel = 11, Maturity = TownHallLevelMaturities.Beginning, Bonus = 40},
                new TownHallMaturityBonus{ TownHallLevel = 11, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 35},
                new TownHallMaturityBonus{ TownHallLevel = 11, Maturity = TownHallLevelMaturities.Max, Bonus = 30},
                new TownHallMaturityBonus{ TownHallLevel = 12, Maturity = TownHallLevelMaturities.Beginning, Bonus = 25},
                new TownHallMaturityBonus{ TownHallLevel = 12, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 20},
                new TownHallMaturityBonus{ TownHallLevel = 12, Maturity = TownHallLevelMaturities.Max, Bonus = 15},
                new TownHallMaturityBonus{ TownHallLevel = 13, Maturity = TownHallLevelMaturities.Beginning, Bonus = 10},
                new TownHallMaturityBonus{ TownHallLevel = 13, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 5},
                new TownHallMaturityBonus{ TownHallLevel = 13, Maturity = TownHallLevelMaturities.Max, Bonus = 0},
            };
            _warriorScoreOptions.SeniorityPoints = new List<SeniorityBonus>
            {
                new SeniorityBonus { MinimumMonth = 0, MaximumMonth = 1, Bonus = 50 },
                new SeniorityBonus { MinimumMonth = 1, MaximumMonth = 6, Bonus = 100 },
                new SeniorityBonus { MinimumMonth = 6, MaximumMonth = 50000, Bonus = 150 },
            };

            _clanWarDal = Substitute.For<IWarDal>();
            _clanWarDal.GetWarsCount(Arg.Any<DateTime>()).Returns(10);

            _leagueWarDal = Substitute.For<ILeagueDal>();
            var leagues = new List<League>();
            for (int i = 0; i < 10; i++)
            {
                leagues.Add(new League { Id = i + 1, LeagueDate = DateTime.Today.AddMonths(-(i + 1)) });
            }
            _leagueWarDal.GetLeagues(Arg.Any<DateTime>(), Arg.Any<List<int>>()).Returns(leagues);

            _gameDal = Substitute.For<IGameDal>();
            var games = new List<Game>();
            for (int i = 0; i < 10; i++)
            {
                games.Add(new Game { Id = i + 1, GamesDate = DateTime.Today.AddMonths(-(i + 1)) });
            }
            _gameDal.GetGames(Arg.Any<DateTime>(), Arg.Any<List<int>>()).Returns(games);

            _gameWarriorDal = Substitute.For<IGameWarriorDal>();
            _gameWarriorDal.GetGames(_warriors[0].Id).Returns(new List<GameWarrior> {
                new GameWarrior { Score = 100, Warrior = _warriors[0] },
                new GameWarrior { Score = 100, Warrior = _warriors[0] },
                new GameWarrior { Score = 100, Warrior = _warriors[0] },
                new GameWarrior { Score = 4000, Warrior = _warriors[0] },
                new GameWarrior { Score = 4000, Warrior = _warriors[0] },
                new GameWarrior { Score = 4000, Warrior = _warriors[0] },
                new GameWarrior { Score = 4000, Warrior = _warriors[0] },
                new GameWarrior { Score = 4000, Warrior = _warriors[0] },
                new GameWarrior { Score = 4000, Warrior = _warriors[0] },
                new GameWarrior { Score = 4000, Warrior = _warriors[0] }
            });
            _gameWarriorDal.GetGames(_warriors[1].Id).Returns(new List<GameWarrior> {
                new GameWarrior { Score = 100, Warrior = _warriors[1] },
                new GameWarrior { Score = 100, Warrior = _warriors[1] },
                new GameWarrior { Score = 100, Warrior = _warriors[1] },
                new GameWarrior { Score = 4000, Warrior = _warriors[1] },
                new GameWarrior { Score = 4000, Warrior = _warriors[1] },
                new GameWarrior { Score = 4000, Warrior = _warriors[1] },
                new GameWarrior { Score = 4000, Warrior = _warriors[1] }
            });
            _gameWarriorDal.GetGames(_warriors[2].Id).Returns(new List<GameWarrior> {
                new GameWarrior { Score = 100, Warrior = _warriors[2] },
                new GameWarrior { Score = 100, Warrior = _warriors[2] },
                new GameWarrior { Score = 100, Warrior = _warriors[2] },
                new GameWarrior { Score = 4000, Warrior = _warriors[2] },
                new GameWarrior { Score = 4000, Warrior = _warriors[2] },
                new GameWarrior { Score = 4000, Warrior = _warriors[2] },
                new GameWarrior { Score = 4000, Warrior = _warriors[2] }
            });

            _warriorRewardManagement = new WarriorRewardManagement(scoreOptionsLoader, _leagueWarDal, _clanWarDal, _gameWarriorDal, _gameDal);

            scoreOptionsLoader.LoadWarriorScoreOptions().Returns(_warriorScoreOptions);

        }

        [TestCase(10, 100)]
        [TestCase(9, 90)]
        [TestCase(8, 80)]
        [TestCase(7, 70)]
        [TestCase(6, 60)]
        [TestCase(5, 50)]
        [TestCase(4, 40)]
        [TestCase(3, 30)]
        [TestCase(2, 20)]
        [TestCase(1, 10)]
        [TestCase(0, 0)]
        public void Should_score_warrior_to_according_percent_when_he_participate_to_leagues(int numberOFParticipation, int score)
        {
            _warriorScoreOptions.ScoreLeagueParticipation = true;

            var warriors = new List<Warrior> { _warriors.First() };
            _league.Players = warriors;

            _leagueWarDal.GetLeaguesCount(_warriors.First().Id).Returns(numberOFParticipation);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(((WarriorReward)rewards.First()).LeagueParticipationRatio).IsEqualTo((double)numberOFParticipation / 10);
            Check.That(((WarriorReward)rewards.First()).LeagueParticipationScore).IsEqualTo(score);
            Check.That(rewards.First().Score).IsEqualTo(score);
        }

        [Test]
        public void Should_score_warrior_to_100_percent_when_he_participate_to_all_leagues_after_his_arrival()
        {
            _warriorScoreOptions.ScoreLeagueParticipation = true;

            var warriors = new List<Warrior> { _warriors.First() };
            _league.Players = warriors;

            _leagueWarDal.GetLeaguesCount(_warriors.First().Id).Returns(10);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(100);
        }

        [Test]
        public void Should_score_all_warriors_when_they_participate_to_leagues()
        {
            _warriorScoreOptions.ScoreLeagueParticipation = true;

            _leagueWarDal.GetLeaguesCount(_warriors[0].Id).Returns(5);
            _leagueWarDal.GetLeaguesCount(_warriors[1].Id).Returns(7);
            _leagueWarDal.GetLeaguesCount(_warriors[2].Id).Returns(3);

            _league.Players = _warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards[0].Score).IsEqualTo(70);
            Check.That(rewards[1].Score).IsEqualTo(50);
            Check.That(rewards[2].Score).IsEqualTo(30);
        }

        [Test]
        public void Should_not_score_warrior_with_leagues_when_option_is_deactivated()
        {
            _warriorScoreOptions.ScoreLeagueParticipation = true;

            var warriors = new List<Warrior> { _warriors.First() };
            _league.Players = warriors;

            _warriorScoreOptions.ScoreLeagueParticipation = false;

            _leagueWarDal.GetLeaguesCount(_warriors.First().Id).Returns(10);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(0);
        }


        [TestCase(10, 100)]
        [TestCase(9, 90)]
        [TestCase(8, 80)]
        [TestCase(7, 70)]
        [TestCase(6, 60)]
        [TestCase(5, 50)]
        [TestCase(4, 40)]
        [TestCase(3, 30)]
        [TestCase(2, 20)]
        [TestCase(1, 10)]
        [TestCase(0, 0)]
        public void Should_score_warrior_to_according_percent_when_he_participate_to_wars(int numberOFParticipation, int score)
        {
            _warriorScoreOptions.ScoreWarParticipation = true;

            var warriorId = 1;
            var warriors = new List<Warrior> { new Warrior { Id = warriorId, ArrivalDate = new DateTime(2020, 01, 01) } };
            _league.Players = warriors;

            _clanWarDal.GetWarsCount(warriorId).Returns(numberOFParticipation);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(((WarriorReward)rewards.First()).WarParticipationRatio).IsEqualTo((double)numberOFParticipation / 10);
            Check.That(((WarriorReward)rewards.First()).WarParticipationScore).IsEqualTo(score);
            Check.That(rewards.First().Score).IsEqualTo(score);
        }

        [Test]
        public void Should_score_warrior_to_100_percent_when_he_participate_to_all_wars()
        {
            _warriorScoreOptions.ScoreWarParticipation = true;

            var warriorId = 1;
            var warriors = new List<Warrior> { new Warrior { Id = warriorId, ArrivalDate = new DateTime(2020, 01, 01) } };
            _league.Players = warriors;

            _clanWarDal.GetWarsCount(warriorId).Returns(10);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(100);
        }

        [Test]
        public void Should_score_all_warriors_when_they_participate_to_wars()
        {
            _warriorScoreOptions.ScoreWarParticipation = true;

            var warriors = new List<Warrior>
            {
                new Warrior { Id = 1, ArrivalDate = new DateTime(2020, 01, 01) } ,
                new Warrior { Id = 2, ArrivalDate = new DateTime(2020, 01, 01) } ,
                new Warrior { Id = 3, ArrivalDate = new DateTime(2020, 01, 01) }
            };
            _league.Players = warriors;

            _clanWarDal.GetWarsCount(1).Returns(5);
            _clanWarDal.GetWarsCount(2).Returns(7);
            _clanWarDal.GetWarsCount(3).Returns(3);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards[0].Score).IsEqualTo(70);
            Check.That(rewards[1].Score).IsEqualTo(50);
            Check.That(rewards[2].Score).IsEqualTo(30);
        }

        [Test]
        public void Should_not_score_warrior_with_war_participation_when_option_is_deactivated()
        {
            _warriorScoreOptions.ScoreWarParticipation = true;

            var warriorId = 1;
            var warriors = new List<Warrior> { new Warrior { Id = warriorId } };
            _league.Players = warriors;

            _warriorScoreOptions.ScoreWarParticipation = false;

            _clanWarDal.GetWarsCount(warriorId).Returns(10);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(0);
        }


        [Test]
        public void Should_score_warrior_to_100_percent_when_he_participate_to_all_games()
        {
            _warriorScoreOptions.ScoreGameParticipation = true;

            var warriors = new List<Warrior> { _warriors.First() };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(100);
        }

        [Test]
        public void Should_score_warrior_to_70_percent_when_he_participate_to_seven_games()
        {
            _warriorScoreOptions.ScoreGameParticipation = true;

            var warriors = new List<Warrior> { _warriors[1] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(((WarriorReward)rewards.First()).GameParticipationRatio).IsEqualTo(.7);
            Check.That(((WarriorReward)rewards.First()).GameParticipationScore).IsEqualTo(70);
            Check.That(rewards.First().Score).IsEqualTo(70);
        }

        [Test]
        public void Should_score_all_warriors_when_they_participate_to_games()
        {
            _warriorScoreOptions.ScoreGameParticipation = true;

            _league.Players = _warriors;
            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards[0].Score).IsEqualTo(100);
            Check.That(rewards[1].Score).IsEqualTo(70);
            Check.That(rewards[2].Score).IsEqualTo(70);
        }

        [Test]
        public void Should_not_score_warrior_with_game_participation_when_option_is_deactivated()
        {
            _warriorScoreOptions.ScoreGameParticipation = false;

            var warriorId = 1;
            var warriors = new List<Warrior> { new Warrior { Id = warriorId } };
            _league.Players = warriors;

            _warriorScoreOptions.ScoreWarParticipation = false;

            _clanWarDal.GetWarsCount(warriorId).Returns(10);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(0);
        }


        [Test]
        public void Should_score_warrior_to_70_percent_when_he_participate_to_ten_games_but_only_seven_were_succeedeed()
        {
            _warriorScoreOptions.ScoreMinimumGamePoints = true;

            var warriors = new List<Warrior> { _warriors.First() };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(((WarriorReward)rewards.First()).SucceedeedGameRatio).IsEqualTo(.70);
            Check.That(((WarriorReward)rewards.First()).SucceedeedGameScore).IsEqualTo(70);
            Check.That(rewards.First().Score).IsEqualTo(70);
        }

        [Test]
        public void Should_score_warrior_to_57_percent_when_he_participate_to_seven_games_but_only_four_were_succeedeed()
        {
            _warriorScoreOptions.ScoreMinimumGamePoints = true;

            var warriors = new List<Warrior> { _warriors[1] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(57);
        }

        [Test]
        public void Should_score_all_warriors_with_minimum_points_when_they_participate_to_games()
        {
            _warriorScoreOptions.ScoreMinimumGamePoints = true;
            _league.Players = _warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards[0].Score).IsEqualTo(70);
            Check.That(rewards[1].Score).IsEqualTo(57);
            Check.That(rewards[2].Score).IsEqualTo(57);
        }

        [Test]
        public void Should_not_score_warrior_with_game_minimum_points_when_option_is_deactivated()
        {
            _warriorScoreOptions.ScoreMinimumGamePoints = false;

            var warriorId = 1;
            var warriors = new List<Warrior> { new Warrior { Id = warriorId } };
            _league.Players = warriors;

            _warriorScoreOptions.ScoreWarParticipation = false;

            _clanWarDal.GetWarsCount(warriorId).Returns(10);

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(0);
        }


        [Test]
        public void Should_score_warrior_to_85_points_when_his_townhall_is_level_8_and_beginner()
        {
            _warriorScoreOptions.ScoreTownHallLevel = true;

            var warriors = new List<Warrior> { _warriors[0] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(((WarriorReward)rewards.First()).TownhallLevelScore).IsEqualTo(85);
            Check.That(rewards.First().Score).IsEqualTo(85);
        }

        [Test]
        public void Should_score_all_warriors_with_townhall_level_points_when_option_is_activated()
        {
            _warriorScoreOptions.ScoreTownHallLevel = true;

            _league.Players = _warriors;
            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards[0].Score).IsEqualTo(85);
            Check.That(rewards[1].Score).IsEqualTo(75);
            Check.That(rewards[2].Score).IsEqualTo(40);
        }

        [Test]
        public void Should_not_score_warrior_with_townhall_level_points_when_option_is_deactivated()
        {
            _warriorScoreOptions.ScoreTownHallLevel = false;

            var warriors = new List<Warrior> { _warriors.First() };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(0);
        }

        [Test]
        public void Should_score_warrior_to_50_points_when_his_seniority_is_less_than_1_months()
        {
            _warriorScoreOptions.ScoreSeniority = true;

            var warriors = new List<Warrior> { _warriors[0] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(((WarriorReward)rewards.First()).SeniorityScore).IsEqualTo(50);
            Check.That(rewards.First().Score).IsEqualTo(50);
        }

        [Test]
        public void Should_score_warrior_to_100_points_when_his_seniority_is_1_months()
        {
            _warriorScoreOptions.ScoreSeniority = true;

            _warriors[0].ArrivalDate = DateTime.Today.AddDays(-31);
            var warriors = new List<Warrior> { _warriors[0] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(100);
        }

        [Test]
        public void Should_score_warrior_to_100_points_when_his_seniority_is_between_1_and_6_months()
        {
            _warriorScoreOptions.ScoreSeniority = true;

            var warriors = new List<Warrior> { _warriors[1] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(100);
        }

        [Test]
        public void Should_score_warrior_to_150_points_when_his_seniority_is_6_months()
        {
            _warriorScoreOptions.ScoreSeniority = true;

            _warriors[0].ArrivalDate = DateTime.Today.AddMonths(-6);
            var warriors = new List<Warrior> { _warriors[0] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(150);
        }

        [Test]
        public void Should_score_warrior_to_150_points_when_his_seniority_is_more_than_6_months()
        {
            _warriorScoreOptions.ScoreSeniority = true;

            var warriors = new List<Warrior> { _warriors[2] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(150);
        }

        [Test]
        public void Should_not_score_warrior_when_option_is_deactivated()
        {
            _warriorScoreOptions.ScoreSeniority = false;

            var warriors = new List<Warrior> { _warriors[0] };
            _league.Players = warriors;

            var rewards = _warriorRewardManagement.ComputeLeagueScore(_league);

            Check.That(rewards.First().Score).IsEqualTo(0);
        }
    }
}
