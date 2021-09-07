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
    public class ImportingTests
    {
        private IClanDal _clanDal;
        private IGameDal _gameDal;
        private IGameWarriorDal _gameWarriorDal;
        private IWarriorDal _warriorDal;
        private IGameManagement _gameManagement;

        [SetUp]
        public void Setup()
        {
            _gameDal = Substitute.For<IGameDal>();
            _gameWarriorDal = Substitute.For<IGameWarriorDal>();
            _warriorDal = Substitute.For<IWarriorDal>();

            _clanDal = Substitute.For<IClanDal>();
            _gameManagement = new GameManagement(_clanDal, _warriorDal, _gameDal, _gameWarriorDal);
        }

        [Test]
        public void Should_insert_non_existing_clans_when_importing_a_game_with_unknonwn_clans_hash_and_no_clan_exists()
        {
            var clan = new Clan { Id = 1, Hash = "NewHash", Name = "New Clan" };
            var game = new Game
            {
                Clan = clan,
                Players = new List<GameWarrior>() 
            };

            _clanDal.GetAll().Returns(new List<Clan>());
            _clanDal.When(x => x.Insert(game.Clan)).Do(x => clan.Id = 100);

            _gameManagement.SaveImportedGame(game);

            _clanDal.Received(1).Insert(game.Clan);
            Check.That(game.ClanId).IsEqualTo(100);
        }

        [Test]
        public void Should_insert_non_existing_clans_when_importing_a_game_with_unknonwn_clans_hash_and_one_clan_exists()
        {
            var game = new Game
            {
                Clan = new Clan { Id = 1, Hash = "NewHash", Name = "New Clan" },
                Players = new List<GameWarrior>()
            };

            _clanDal.GetAll().Returns(new List<Clan> { new Clan { Id = 1, Hash = "OldHash", Name = "Existing Clan" } });
            _gameManagement.SaveImportedGame(game);

            _clanDal.Received(1).Insert(game.Clan);
        }

        [Test]
        public void Should_insert_non_existing_clans_only_once_when_importing_a_game_with_unknonwn_clans_hash()
        {
            var game = new Game
            {
                Clan = new Clan { Id = 1, Hash = "NewHash", Name = "New Clan" },
                Players = new List<GameWarrior>
                {
                    new GameWarrior { Warrior = new Warrior { Clan = new Clan { Id = 1, Hash = "NewHash", Name = "New Clan" }}}
                }
            };

            _clanDal.GetAll().Returns(new List<Clan>());
            _gameManagement.SaveImportedGame(game);

            _clanDal.Received(1).Insert(game.Clan);
        }

        [Test]
        public void Should_insert_non_existing_warrior_clan_when_importing_a_game_with_unknonwn_clans_hash()
        {
            var warriorClan = new Clan { Id = 2, Hash = "NewHash2", Name = "New Clan 2" };
            var game = new Game
            {
                Clan = new Clan { Id = 1, Hash = "NewHash", Name = "New Clan" },
                Players = new List<GameWarrior>
                {
                    new GameWarrior { Warrior = new Warrior { Clan = warriorClan}}
                }
            };

            _clanDal.GetAll().Returns(new List<Clan>());
            _clanDal.When(x => x.Insert(warriorClan)).Do(x => warriorClan.Id = 100);

            _gameManagement.SaveImportedGame(game);

            _clanDal.Received(1).Insert(game.Clan);
            _clanDal.Received(1).Insert(game.Players[0].Warrior.Clan);
            Check.That(game.ClanId).IsEqualTo(1);
            Check.That(game.Players[0].Warrior.ClanId).IsEqualTo(100);
        }

        [Test]
        public void Should_insert_non_existing_warrior_clan_only_once_when_importing_a_game_with_unknonwn_clans_hash()
        {
            var clan = new Clan { Id = 1, Hash = "NewHash", Name = "New Clan" };

            var game = new Game
            {
                Clan = clan,
                Players = new List<GameWarrior>
                {
                    new GameWarrior { Warrior = new Warrior { Clan = clan} },
                    new GameWarrior { Warrior = new Warrior { Clan = new Clan { Id = 2, Hash = "NewHash2", Name = "New Clan 2" }}},
                    new GameWarrior { Warrior = new Warrior { Clan = new Clan { Id = 2, Hash = "NewHash2", Name = "New Clan 2" }}}
                }
            };

            _clanDal.GetAll().Returns(new List<Clan>());
            _gameManagement.SaveImportedGame(game);

            _clanDal.Received(1).Insert(game.Clan);
            _clanDal.Received(1).Insert(game.Players[0].Warrior.Clan);
        }

        [Test]
        public void Should_insert_non_existing_warrior_when_importing_a_game_with_unknonwn_warrors_hash()
        {
            var clan = new Clan { Id = 1, Hash = "Hash", Name = "Clan" };
            var warrior = new Warrior { Id = 10, Hash = "Hash10", Name = "Warrior 10", Clan = clan };
            var game = new Game
            {
                Clan = clan,
                Players = new List<GameWarrior>
                {
                    new GameWarrior { Warrior = warrior }
                }
            };

            _warriorDal.GetAll().Returns(new List<Warrior>());
            _warriorDal.When(x => x.Insert(warrior)).Do(x => warrior.Id = 100);

            _gameManagement.SaveImportedGame(game);

            _warriorDal.Received(1).Insert(game.Players[0].Warrior);
            Check.That(warrior.Id).IsEqualTo(100);
            Check.That(game.Players[0].WarriorId).IsEqualTo(100);
        }

        [Test]
        public void Should_insert_game_when_importing_a_new_game()
        {
            var game = new Game {  Clan = new Clan(), Players = new List<GameWarrior>() };
            _gameManagement.SaveImportedGame(game);

            _gameDal.Received(1).Insert(game);
        }

        [Test]
        public void Should_update_game_when_importing_an_existing_game()
        {
            var game = new Game { Id=10, Clan = new Clan(), Players = new List<GameWarrior>() };
            _gameManagement.SaveImportedGame(game);

            _gameDal.Received(1).Update(game);
        }

        [Test]
        public void Should_insert_warrior_results_when_importing_a_game_and_results_are_not_already_existing()
        {
            var gameWarrior = new GameWarrior { Id = 0, Warrior = new Warrior { Clan = new Clan() } };
            var game = new Game { Clan = new Clan(), Players = new List<GameWarrior> { gameWarrior} };
            _gameDal.When(x => x.Insert(game)).Do(x => game.Id = 100);
            _gameManagement.SaveImportedGame(game);

            _gameWarriorDal.Received(1).Insert(gameWarrior);
        }

        [Test]
        public void Should_update_warrior_results_when_importing_a_game_and_results_exist()
        {
            var gameWarrior = new GameWarrior { Id = 10, Warrior = new Warrior { Clan = new Clan() } };
            var game = new Game { Id= 5, Clan = new Clan(), Players = new List<GameWarrior> { gameWarrior } };
            _gameDal.Update(game).Returns(true);
            _gameManagement.SaveImportedGame(game);

            _gameWarriorDal.Received(1).Update(gameWarrior);
        }

        [Test]
        public void Should_not_save_warrior_results_when_importing_a_game_and_game_inserting_failed()
        {
            var gameWarrior = new GameWarrior { Id = 0, Warrior = new Warrior { Clan = new Clan() } };
            var game = new Game { Clan = new Clan(), Players = new List<GameWarrior> { gameWarrior } };
            _gameDal.When(x => x.Insert(game)).Do(x => game.Id = 00);
            
            var result = _gameManagement.SaveImportedGame(game);

            _gameWarriorDal.DidNotReceive().Insert(gameWarrior);
            _gameWarriorDal.DidNotReceive().Update(gameWarrior);

            Check.That(result).IsFalse();
        }

        [Test]
        public void Should_not_save_warrior_results_when_importing_a_game_and_game_updating_failed()
        {
            var gameWarrior = new GameWarrior { Id = 0, Warrior = new Warrior { Clan = new Clan() } };
            var game = new Game { Id= 100, Clan = new Clan(), Players = new List<GameWarrior> { gameWarrior } };
            _gameDal.Update(game).Returns(false);
            
            var result = _gameManagement.SaveImportedGame(game);

            _gameWarriorDal.DidNotReceive().Insert(gameWarrior);
            _gameWarriorDal.DidNotReceive().Update(gameWarrior);
            Check.That(result).IsFalse();
        }

        [Test]
        public void Should_not_save_second_warrior_results_when_importing_a_game_and_first_warrior_inserting_failed()
        {
            var gameWarrior = new GameWarrior { Id = 0, Warrior = new Warrior { Clan = new Clan() } };
            var gameWarrior2 = new GameWarrior { Id = 0, Warrior = new Warrior { Clan = new Clan() } };
            var game = new Game { Id = 100, Clan = new Clan(), Players = new List<GameWarrior> { gameWarrior, gameWarrior2 } };
            _gameDal.Update(game).Returns(true);
            
            var result = _gameManagement.SaveImportedGame(game);

            _gameWarriorDal.Received(1).Insert(gameWarrior);
            _gameWarriorDal.DidNotReceive().Insert(gameWarrior2);
            Check.That(result).IsFalse();
        }

        [Test]
        public void Should_insert_both_warrior_results_when_importing_a_game()
        {
            var gameWarrior = new GameWarrior { Id = 0, Warrior = new Warrior { Clan = new Clan() } };
            var gameWarrior2 = new GameWarrior { Id = 0, Warrior = new Warrior { Clan = new Clan() } };
            var game = new Game { Id = 100, Clan = new Clan(), Players = new List<GameWarrior> { gameWarrior, gameWarrior2 } };
            
            _gameDal.Update(game).Returns(true);
            _gameWarriorDal.When(x => x.Insert(gameWarrior)).Do(x => gameWarrior.Id = 1);
            _gameWarriorDal.When(x => x.Insert(gameWarrior2)).Do(x => gameWarrior2.Id = 2);


            var result = _gameManagement.SaveImportedGame(game);

            _gameWarriorDal.Received(1).Insert(gameWarrior);
            _gameWarriorDal.Received(1).Insert(gameWarrior2);
            Check.That(result).IsTrue();
        }
    }
}
