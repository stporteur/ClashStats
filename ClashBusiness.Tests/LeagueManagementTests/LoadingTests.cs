using ClashBusiness.Exceptions;
using ClashData;
using ClashEntities;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace ClashBusiness.Tests.LeagueManagementTests
{
    public class LoadingTests
    {
        private LeagueManagement _leagueManagement;
        private ILeaguePlayerDal _leaguePlayerDal;
        private ILeagueAttackDal _leagueAttackDal;
        private ILeagueDal _leagueDal;
        private IClanDal _clanDal;
        private IWarriorDal _warriorDal;

        [SetUp]
        public void Setup()
        {
            _leagueDal = Substitute.For<ILeagueDal>();
            _leaguePlayerDal = Substitute.For<ILeaguePlayerDal>();
            _leagueAttackDal = Substitute.For<ILeagueAttackDal>();
            _clanDal = Substitute.For<IClanDal>();
            _warriorDal = Substitute.For<IWarriorDal>();

            _leagueManagement = new LeagueManagement(_clanDal, _warriorDal, _leagueDal, _leaguePlayerDal, _leagueAttackDal);
        }

        [Test]
        public void Should_throw_UnknownClanException_exception_when_loading_current_league_and_clan_doesnt_exist()
        {
            var clanId = 1;
            _leagueDal.LoadCurrentLeague(Arg.Any<int>()).Returns(new League { ClanId = clanId });
            _clanDal.Get(clanId).Returns(x => null);
            Check.ThatCode(() => _leagueManagement.LoadCurrentLeague(clanId)).Throws<UnknownClanException>();
        }

        [Test]
        public void Should_return_null_when_loading_current_league_and_none_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            _leagueDal.LoadCurrentLeague(clan.Id).Returns(x => null);

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league).IsNull();
        }

        [Test]
        public void Should_return_current_league_when_league_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            var currentLeague = new League { ClanId = 1 };
            _leagueDal.LoadCurrentLeague(clan.Id).Returns(x => currentLeague);
            _leaguePlayerDal.LoadLeaguePlayers(currentLeague.Id).Returns(new List<Warrior>());

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league).IsEqualTo(currentLeague);
        }

        [Test]
        public void Should_return_current_league_with_players_when_league_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);

            var currentLeague = new League { Id = 1, ClanId = clanId };
            _leagueDal.LoadCurrentLeague(clan.Id).Returns(currentLeague);

            var warrior = new Warrior();
            _leaguePlayerDal.LoadLeaguePlayers(currentLeague.Id).Returns(new List<Warrior> { warrior });

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league.Players).IsNotNull();
            Check.That(league.Players).HasSize(1);
            Check.That(league.Players).Contains(warrior);
        }

        [Test]
        public void Should_load_clan_of_players_only_once_when_they_are_coming_from_other_clans()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            var clan2 = new Clan { Id = 2, Name = "dummy clan 2" };
            var clan3 = new Clan { Id = 3, Name = "dummy clan 3" };
            _clanDal.Get(clanId).Returns(x => clan);
            _clanDal.Get(2).Returns(x => clan2);
            _clanDal.Get(3).Returns(x => clan3);


            var currentLeague = new League { Id = 1, ClanId = clanId };
            _leagueDal.LoadCurrentLeague(clan.Id).Returns(currentLeague);

            var warrior1 = new Warrior { ClanId = 1 };
            var warrior2 = new Warrior { ClanId = 2 };
            var warrior3 = new Warrior { ClanId = 3 };
            var warrior4 = new Warrior { ClanId = 3 };
            _leaguePlayerDal.LoadLeaguePlayers(currentLeague.Id).Returns(new List<Warrior> { warrior1, warrior2, warrior3, warrior4 });

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league.Players).HasSize(4);
            _clanDal.Received(1).Get(2);
            _clanDal.Received(1).Get(3);
        }

        [Test]
        public void Should_return_current_league_with_seven_days_and_players_when_league_is_started_and_no_day_is_setup()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);

            var currentLeague = new League { Id = 1, ClanId = clanId };
            _leagueDal.LoadCurrentLeague(clan.Id).Returns(currentLeague);

            var warrior = new Warrior();
            _leaguePlayerDal.LoadLeaguePlayers(currentLeague.Id).Returns(new List<Warrior> { warrior });
            _leagueAttackDal.LoadLeaguePlayersOfDay(currentLeague.Id, Arg.Any<int>()).Returns(x => null);

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league.PlayersPerDay).IsNotNull();
            Check.That(league.PlayersPerDay).HasSize(7);
            for (int i = 1; i <= 7; i++)
            {
                _leagueAttackDal.Received(1).LoadLeaguePlayersOfDay(currentLeague.Id, i);
                Check.That(league.PlayersPerDay[i]).IsNotNull();
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void Should_return_current_league_with_seven_days_and_players_for_specified_days_when_league_is_started_and_no_day_is_setup_after_specified_day(int numberOfSetupDays)
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);

            var currentLeague = new League { Id = 1, ClanId = clanId };
            _leagueDal.LoadCurrentLeague(clan.Id).Returns(currentLeague);

            var warrior = new Warrior { Id = 1, ClanId = 1 };
            _warriorDal.Get(1).Returns(warrior);
            _leaguePlayerDal.LoadLeaguePlayers(currentLeague.Id).Returns(new List<Warrior> { warrior });
            _leagueAttackDal.LoadLeaguePlayersOfDay(currentLeague.Id, Arg.Any<int>()).Returns(x => null);
            var leagueWarPlayers = new List<LeagueAttack>();
            for (int i = 1; i <= numberOfSetupDays; i++)
            {
                var leagueWarPlayer = new LeagueAttack { WarriorId = 1, LeagueId = 1 };
                leagueWarPlayers.Add(leagueWarPlayer);
                _leagueAttackDal.LoadLeaguePlayersOfDay(currentLeague.Id, i).Returns(x => new List<LeagueAttack> { leagueWarPlayer });
            }

            var league = _leagueManagement.LoadCurrentLeague(clanId);

            for (int i = 1; i <= numberOfSetupDays; i++)
            {
                Check.That(league.PlayersPerDay[i]).IsNotNull();
                Check.That(league.PlayersPerDay[i]).HasSize(1);
                Check.That(league.PlayersPerDay[i]).Contains(leagueWarPlayers[i - 1]);
            }

            if (numberOfSetupDays != 7)
            {
                for (int i = numberOfSetupDays + 1; i <= 7; i++)
                {
                    _leagueAttackDal.Received(1).LoadLeaguePlayersOfDay(currentLeague.Id, i);
                    Check.That(league.PlayersPerDay[i]).IsNotNull();
                    Check.That(league.PlayersPerDay[i]).HasSize(0);
                }
            }
        }

        [Test]
        public void Should_return_all_warriors_when_registered_warrior_list_is_empty()
        {
            var resgisteredWarriors = new List<Warrior>();

            var allWarriors = new List<Warrior> { new Warrior { Id = 1 }, new Warrior { Id = 2 } };
            _warriorDal.GetAll().Returns(allWarriors);
            _clanDal.Get(Arg.Any<int>()).Returns(new Clan());

            var result = _leagueManagement.GetUnregisteredWarriors(resgisteredWarriors);
            Check.That(result).HasSize(allWarriors.Count);
            Check.That(result).ContainsExactly(allWarriors);
        }

        [Test]
        public void Should_return_not_registered_warriors()
        {
            var registeredWarrior = new Warrior { Id = 1 };
            var resgisteredWarriors = new List<Warrior> { registeredWarrior };

            var notRegisteredWarrior1 = new Warrior { Id = 2 };
            var notRegisteredWarrior2 = new Warrior { Id = 3 };
            var allWarriors = new List<Warrior> { registeredWarrior, notRegisteredWarrior1, notRegisteredWarrior2 };
            _warriorDal.GetAll().Returns(allWarriors);
            _clanDal.Get(Arg.Any<int>()).Returns(new Clan());

            var result = _leagueManagement.GetUnregisteredWarriors(resgisteredWarriors);
            Check.That(result).HasSize(2);
            Check.That(result).Contains(notRegisteredWarrior1);
            Check.That(result).Contains(notRegisteredWarrior2);
        }

        [Test]
        public void Should_return_all_leagues()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            var league1 = new League { Id = 1, ClanId = 1 };
            var league2 = new League { Id = 2, ClanId = 1 };
            var league3 = new League { Id = 3, ClanId = 1 };

            _leaguePlayerDal.LoadLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());

            _leagueDal.Get(1).Returns(x => league1);
            _leagueDal.Get(2).Returns(x => league2);
            _leagueDal.Get(3).Returns(x => league3);

            var leagues = _leagueManagement.LoadLeagues(new List<int> { 1, 2, 3 });
            Check.That(leagues).HasSize(3);
        }

        [Test]
        public void Should_return_all_leagues_for_a_clan()
        {
            var clanId = 1;
            var clan = new Clan { Id = clanId, Name = "dummy clan" };
            var clan2 = new Clan { Id = 2, Name = "dummy clan 2" };
            _clanDal.Get(clanId).Returns(x => clan);
            var league1 = new League { Id = 1, ClanId = clanId };
            var league2 = new League { Id = 2, ClanId = clanId };
            var league3 = new League { Id = 3, ClanId = clanId };
            var league4 = new League { Id = 3, ClanId = 2 };
            var league5 = new League { Id = 3, ClanId = 2 };
            var league6 = new League { Id = 3, ClanId = 2 };

            _leagueDal.GetAll().Returns(new List<League>
            {
                league1,
                league2,
                league3,
                league4,
                league5,
                league6
            });

            var leagues = _leagueManagement.GetClanLeagues(clanId);
            Check.That(leagues).HasSize(3);
            Check.That(leagues).ContainsExactly(league1, league2, league3);
        }
    }
}
