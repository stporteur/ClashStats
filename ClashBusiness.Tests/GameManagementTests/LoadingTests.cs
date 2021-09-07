using ClashBusiness.Exceptions;
using ClashData;
using ClashEntities;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClashBusiness.Tests.GameManagementTests
{
    public class LoadingTests
    {
        private GameManagement _gameManagement;
        private IGameWarriorDal _gameWarriorDal;
        private IGameDal _gameDal;
        private IClanDal _clanDal;
        private IWarriorDal _warriorDal;

        [SetUp]
        public void Setup()
        {
            _gameDal = Substitute.For<IGameDal>();
            _gameWarriorDal = Substitute.For<IGameWarriorDal>();
            _clanDal = Substitute.For<IClanDal>();
            _warriorDal = Substitute.For<IWarriorDal>();

            _gameManagement = new GameManagement(_clanDal, _warriorDal, _gameDal, _gameWarriorDal);
        }

        [Test]
        public void Should_throw_UnknownClanException_exception_when_loading_current_game_and_clan_doesnt_exist()
        {
            var clanId = 1;
            _gameDal.GetCurrentGame(Arg.Any<int>()).Returns(new Game { ClanId = clanId });
            _clanDal.Get(clanId).Returns(x => null);
            Check.ThatCode(() => _gameManagement.LoadCurrentGame(clanId)).Throws<UnknownClanException>();
        }

        [Test]
        public void Should_return_null_when_loading_current_game_and_none_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            _gameDal.GetCurrentGame(clan.Id).Returns(x => null);

            var game = _gameManagement.LoadCurrentGame(clanId);
            Check.That(game).IsNull();
        }

        [Test]
        public void Should_return_current_game_when_game_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            var currentGame = new Game { Id = 20, ClanId = 1 };
            _gameDal.GetCurrentGame(clan.Id).Returns(x => currentGame);
            _gameWarriorDal.LoadGameWarriors(20).Returns(new List<GameWarrior>());

            var game = _gameManagement.LoadCurrentGame(clanId);

            Check.That(game).IsEqualTo(currentGame);
        }

        [Test]
        public void Should_return_current_game_with_players_when_game_is_started()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            _clanDal.GetAll().Returns(x => new List<Clan> { clan });

            var currentGame = new Game { Id = 1, ClanId = clanId };
            _gameDal.GetCurrentGame(clan.Id).Returns(currentGame);

            var warrior = new Warrior { Id = 30, ClanId = 1 };
            _warriorDal.GetAll().Returns(new List<Warrior> { warrior });

            var gameWarrior = new GameWarrior { Id = 10, WarriorId = 30 };
            _gameWarriorDal.LoadGameWarriors(currentGame.Id).Returns(new List<GameWarrior> { gameWarrior });

            var game = _gameManagement.LoadCurrentGame(clanId);
            Check.That(game.Players).IsNotNull();
            Check.That(game.Players).HasSize(1);
            Check.That(game.Players).Contains(gameWarrior);
        }

        [Test]
        public void Should_return_all_warriors_when_registered_warrior_list_is_empty()
        {
            var resgisteredWarriors = new List<Warrior>();

            var allWarriors = new List<Warrior> { new Warrior { Id = 1 }, new Warrior { Id = 2 } };
            _warriorDal.GetAll().Returns(allWarriors);
            _clanDal.Get(Arg.Any<int>()).Returns(new Clan());

            var result = _gameManagement.GetUnregisteredWarriors(resgisteredWarriors);
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

            var result = _gameManagement.GetUnregisteredWarriors(resgisteredWarriors);
            Check.That(result).HasSize(2);
            Check.That(result).Contains(notRegisteredWarrior1);
            Check.That(result).Contains(notRegisteredWarrior2);
        }

        [Test]
        public void Should_return_all_games()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            var game1 = new Game { Id = 1, ClanId = 1 };
            var game2 = new Game { Id = 2, ClanId = 1 };
            var game3 = new Game { Id = 3, ClanId = 1 };

            _gameWarriorDal.LoadGameWarriors(Arg.Any<int>()).Returns(new List<GameWarrior>());

            _gameDal.Get(1).Returns(x => game1);
            _gameDal.Get(2).Returns(x => game2);
            _gameDal.Get(3).Returns(x => game3);

            var games = _gameManagement.LoadGames(new List<int> { 1, 2, 3 });
            Check.That(games).HasSize(3);
        }

        [Test]
        public void Should_return_games_of_clan()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            var game1 = new Game { Id = 1, ClanId = 1 };
            var game2 = new Game { Id = 2, ClanId = 1 };
            var game3 = new Game { Id = 3, ClanId = 3 };

            _gameWarriorDal.LoadGameWarriors(Arg.Any<int>()).Returns(new List<GameWarrior>());

            _gameDal.GetAll().Returns(x => new List<Game> { game1, game2, game3 });

            var games = _gameManagement.GetGamesOfClan(1);
            Check.That(games).HasSize(2);
        }

        [Test]
        public void Should_return_null_when_no_game_is_found_by_hash_and_date()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);
            _gameDal.GetGame("dummyClanHash", DateTime.Today).Returns(x => null);

            var game = _gameManagement.LoadClanGame("dummyClanHash", DateTime.Today);
            Check.That(game).IsNull();
        }

        [Test]
        public void Should_return_game_when_game_is_found_by_hash_and_date()
        {
            var clanId = 1;
            var clan = new Clan { Id = 1, Name = "dummy clan" };
            _clanDal.Get(clanId).Returns(x => clan);

            _gameWarriorDal.LoadGameWarriors(Arg.Any<int>()).Returns(new List<GameWarrior>());
            var game = new Game { ClanId = 1 };
            _gameDal.GetGame("dummyClanHash", DateTime.Today).Returns(x => game);

            var result = _gameManagement.LoadClanGame("dummyClanHash", DateTime.Today);
            Check.That(result).IsEqualTo(game);
        }
    }
}
