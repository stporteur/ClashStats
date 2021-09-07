using ClashData;
using ClashEntities;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness.Tests.GameManagementTests
{
    public class SavingTests
    {
        private IGameDal _gameDal;
        private IGameWarriorDal _gameWarriorDal;
        private IGameManagement _gameManagement;

        [SetUp]
        public void Setup()
        {
            _gameDal = Substitute.For<IGameDal>();
            _gameWarriorDal = Substitute.For<IGameWarriorDal>();
            var warriorDal = Substitute.For<IWarriorDal>();

            var clanDal = Substitute.For<IClanDal>();
            _gameManagement = new GameManagement(clanDal, warriorDal, _gameDal, _gameWarriorDal);
        }

        [Test]
        public void Should_insert_game_when_registering_a_new_game()
        {
            var game = new Game { Players = new List<GameWarrior>() };
            _gameManagement.RegisterNewGame(game);

            _gameDal.Received(1).Insert(game);
        }

        [Test]
        public void Should_associate_player_to_game_when_registering_a_new_game()
        {
            var warrior = new GameWarrior();
            var game = new Game { Players = new List<GameWarrior> { warrior } };

            _gameDal.When(x => x.Insert(game)).Do(x => game.Id = 1);
            GameWarrior gameWarrior = null;
            _gameWarriorDal.Insert(Arg.Do<GameWarrior>(x => gameWarrior = x));

            _gameManagement.RegisterNewGame(game);

            _gameWarriorDal.Received(1).Insert(Arg.Any<GameWarrior>());
            Check.That(gameWarrior.GameId).IsEqualTo(1);

        }

        [Test]
        public void Should_associate_all_players_to_game_when_registering_a_new_game()
        {
            var warrior = new GameWarrior { Id = 10 };
            var warrior2 = new GameWarrior { Id = 20 };
            var game = new Game { Players = new List<GameWarrior> { warrior, warrior2 } };

            _gameManagement.RegisterNewGame(game);

            _gameWarriorDal.Received(2).Insert(Arg.Any<GameWarrior>());
        }

        [Test]
        public void Should_update_game_in_database_when_updating_game()
        {
            var game = new Game
            {
                Players = new List<GameWarrior>()
            };

            _gameDal.Update(game).Returns(true);
            _gameManagement.UpdateGame(game);

            _gameDal.Received(1).Update(game);
        }

        [Test]
        public void Should_delete_all_participations_in_database_when_updating_game()
        {
            var game = new Game
            {
                Players = new List<GameWarrior>()
            };
            _gameDal.Update(game).Returns(true);
            _gameManagement.UpdateGame(game);

            _gameWarriorDal.Received(1).DeleteGamePlayers(game.Id);
        }

        [Test]
        public void Should_insert_participations_in_database_when_updating_game()
        {
            var gameWarrior = new GameWarrior();
            var gameWarrior2 = new GameWarrior();
            var game = new Game
            {
                Players = new List<GameWarrior> { gameWarrior, gameWarrior2 }
            };
            _gameDal.Update(game).Returns(true);
            _gameWarriorDal.When(x=> x.Insert(gameWarrior)).Do(x => gameWarrior.Id = 1);
            _gameWarriorDal.When(x=> x.Insert(gameWarrior2)).Do(x => gameWarrior2.Id = 2);
            _gameWarriorDal.Update(gameWarrior2).Returns(true);
            _gameManagement.UpdateGame(game);

            _gameWarriorDal.Received(1).Insert(gameWarrior);
            _gameWarriorDal.Received(1).Insert(gameWarrior2);
        }

        [Test]
        public void Should_not_insert_participations_in_database_when_updating_game_failed()
        {
            var gameWarrior = new GameWarrior();
            var gameWarrior2 = new GameWarrior();
            var game = new Game
            {
                Players = new List<GameWarrior> { gameWarrior, gameWarrior2 }
            };
            _gameDal.Update(game).Returns(false);
            _gameManagement.UpdateGame(game);

            _gameWarriorDal.DidNotReceive().Insert(gameWarrior);
            _gameWarriorDal.DidNotReceive().Insert(gameWarrior2);
        }

        [Test]
        public void Should_not_continue_inserting_participations_in_database_when_updating_game_failed()
        {
            var gameWarrior = new GameWarrior();
            var gameWarrior2 = new GameWarrior();
            var game = new Game
            {
                Players = new List<GameWarrior> { gameWarrior, gameWarrior2 }
            };
            _gameDal.Update(game).Returns(true);
            _gameManagement.UpdateGame(game);

            _gameWarriorDal.Received(1).Insert(gameWarrior);
            _gameWarriorDal.DidNotReceive().Insert(gameWarrior2);
        }
    }
}
