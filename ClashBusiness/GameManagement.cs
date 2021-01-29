using ClashBusiness.Exceptions;
using ClashData;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness
{
    public class GameManagement : IGameManagement
    {
        private readonly IClanDal _clanDal;
        private readonly IWarriorDal _warriorDal;
        private readonly IGameDal _gameDal;
        private readonly IGameWarriorDal _gameWarriorDal;

        private List<Clan> _loadedClans;

        public GameManagement(IClanDal clanDal, IWarriorDal warriorDal, IGameDal gameDal, IGameWarriorDal gameWarriorDal)
        {
            _clanDal = clanDal;
            _warriorDal = warriorDal;
            _gameDal = gameDal;
            _gameWarriorDal = gameWarriorDal;
        }

        public Game LoadCurrentGames(int clanId)
        {
            _loadedClans = new List<Clan>();

            var clan = _clanDal.Get(clanId);

            if (clan == null)
            {
                throw new UnkownClanException();
            }

            _loadedClans.Add(clan);

            var game = _gameDal.LoadCurrentGame(clan.Id);
            if (game == null)
            {
                return null;
            }

            var allWarriors = _warriorDal.GetAll().ToList();
            game.Players = _gameWarriorDal.LoadCurrentGameWarriors(game.Id).OrderByDescending(x => x.Score).ThenBy(x => x.WarriorName).ToList();
            game.Players.ForEach(x => FillWarrior(allWarriors, x));

            return game;
        }

        public bool RegisterNewGames(Game newGame)
        {
            var result = true;
            _gameDal.Insert(newGame);
            result &= newGame.Id > 0;

            foreach (var player in newGame.Players)
            {
                player.GameId = newGame.Id;
                _gameWarriorDal.Insert(player);
                result &= player.Id > 0;
            }

            return result;
        }

        public bool UpdateGames(Game game)
        {
            var result = _gameDal.Update(game);

            _gameWarriorDal.DeleteCurrentGamePlayers(game.Id);
            foreach (var player in game.Players)
            {
                _gameWarriorDal.Insert(player);
                result &= player.Id > 0;
            }

            return result;
        }

        public List<Warrior> GetUnregisteredWarriors(List<Warrior> registeredWarriors)
        {
            if (_loadedClans == null) _loadedClans = new List<Clan>();

            var allWarriors = _warriorDal.GetAll();
            var registeredWarriorsId = registeredWarriors.Select(x => x.Id).ToList();
            var unregisteredWarriors = allWarriors.Where(x => !registeredWarriorsId.Contains(x.Id)).ToList();
            unregisteredWarriors.ForEach(FillWarriorClan);
            return unregisteredWarriors;

        }

        private void FillWarrior(List<Warrior> allWarriors, GameWarrior gameWarrior)
        {
            var warrior = allWarriors.Single(x => x.Id == gameWarrior.WarriorId);
            gameWarrior.WarriorId = warrior.Id;
            gameWarrior.Warrior = warrior;
            FillWarriorClan(warrior);
        }

        private void FillWarriorClan(Warrior warrior)
        {
            var loadedClan = _loadedClans.SingleOrDefault(x => x.Id == warrior.ClanId);
            if (loadedClan == null)
            {
                loadedClan = _clanDal.Get(warrior.ClanId);
                _loadedClans.Add(loadedClan);
            }

            warrior.Clan = loadedClan;
        }
    }
}
