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
        private ILeaguePlayerDal _leagueWarPlayerDal;
        private ILeagueDal _leagueWarDal;
        private IClanDal _clanDal;

        [SetUp]
        public void Setup()
        {
            _leagueWarDal = Substitute.For<ILeagueDal>();
            _leagueWarPlayerDal = Substitute.For<ILeaguePlayerDal>();
            _clanDal = Substitute.For<IClanDal>();

            _leagueManagement = new LeagueManagement(_clanDal, _leagueWarDal, _leagueWarPlayerDal);
        }

        [Test]
        public void Should_throw_UnkownClanException_exception_when_loading_current_league_and_clan_doesnt_exist()
        {
            var clanId = 1;
            _clanDal.Get(clanId).Returns(x => null);
            Check.ThatCode(() => _leagueManagement.LoadCurrentLeague(clanId)).Throws<UnkownClanException>();
        }

        [Test]
        public void Should_return_null_when_loading_current_league_and_none_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            _leagueWarDal.LoadCurrentLeague(clan.Id).Returns(x => null);

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league).IsNull();
        }

        [Test]
        public void Should_return_current_league_when_league_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            var currentLeague = new League { };
            _leagueWarDal.LoadCurrentLeague(clan.Id).Returns(x => null);

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league).IsNull();
        }

        [Test]
        public void Should_return_current_league_with_players_when_league_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);

            var currentLeague = new League { Id = 1 };
            _leagueWarDal.LoadCurrentLeague(clan.Id).Returns(currentLeague);

            var warrior = new Warrior();
            _leagueWarPlayerDal.LoadCurrentLeaguePlayers(currentLeague.Id).Returns(new List<Warrior> { warrior });

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league.Players).IsNotNull();
            Check.That(league.Players).HasSize(1);
            Check.That(league.Players).Contains(warrior);
        }

        [Test]
        public void Should_return_current_league_with_seven_days_and_players_when_league_is_started_and_no_day_is_setup()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);

            var currentLeague = new League { Id = 1 };
            _leagueWarDal.LoadCurrentLeague(clan.Id).Returns(currentLeague);

            var warrior = new Warrior();
            _leagueWarPlayerDal.LoadCurrentLeaguePlayers(currentLeague.Id).Returns(new List<Warrior> { warrior });
            _leagueWarPlayerDal.LoadCurrentLeaguePlayersOfDay(currentLeague.Id, Arg.Any<int>()).Returns(x => null);

            var league = _leagueManagement.LoadCurrentLeague(clanId);
            Check.That(league.PlayersPerDay).IsNotNull();
            Check.That(league.PlayersPerDay).HasSize(7);
            for (int i = 1; i <= 7; i++)
            {
                _leagueWarPlayerDal.Received(1).LoadCurrentLeaguePlayersOfDay(currentLeague.Id, i);
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

            var currentLeague = new League { Id = 1 };
            _leagueWarDal.LoadCurrentLeague(clan.Id).Returns(currentLeague);

            var warrior = new Warrior();
            _leagueWarPlayerDal.LoadCurrentLeaguePlayers(currentLeague.Id).Returns(new List<Warrior> { warrior });
            _leagueWarPlayerDal.LoadCurrentLeaguePlayersOfDay(currentLeague.Id, Arg.Any<int>()).Returns(x => null);
            var leagueWarPlayers = new List<LeaguePlayer>();
            for (int i = 1; i <= numberOfSetupDays; i++)
            {
                var leagueWarPlayer = new LeaguePlayer();
                leagueWarPlayers.Add(leagueWarPlayer);
                _leagueWarPlayerDal.LoadCurrentLeaguePlayersOfDay(currentLeague.Id, i).Returns(x => new List<LeaguePlayer> { leagueWarPlayer });
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
                    _leagueWarPlayerDal.Received(1).LoadCurrentLeaguePlayersOfDay(currentLeague.Id, i);
                    Check.That(league.PlayersPerDay[i]).IsNotNull();
                    Check.That(league.PlayersPerDay[i]).HasSize(0);
                }
            }
        }
    }
}
