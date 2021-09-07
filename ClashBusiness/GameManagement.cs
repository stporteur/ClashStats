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

        public List<Game> LoadGames(List<int> gameIdsToLoad)
        {
            var games = new List<Game>();
            foreach (var gameId in gameIdsToLoad)
            {
                var game = _gameDal.Get(gameId);
                if (game != null)
                {
                    LoadAdditionalGamesData(game);
                    games.Add(game);
                }
            }

            return games;
        }

        public Game LoadClanGame(string clanHash, DateTime gamesDate)
        {
            var game = _gameDal.GetGame(clanHash, gamesDate);
            if (game == null)
            {
                return null;
            }

            LoadAdditionalGamesData(game);

            return game;
        }

        public Game LoadCurrentGame(int clanId)
        {
            var game = _gameDal.GetCurrentGame(clanId);
            if (game == null)
            {
                return null;
            }

            LoadAdditionalGamesData(game);

            return game;
        }

        public bool RegisterNewGame(Game newGame)
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

        public bool UpdateGame(Game game)
        {
            var result = _gameDal.Update(game);

            if (result)
            {
                _gameWarriorDal.DeleteGamePlayers(game.Id);
                foreach (var player in game.Players)
                {
                    _gameWarriorDal.Insert(player);
                    result &= player.Id > 0;
                    if (!result) break;
                }
            }

            return result;
        }

        public bool SaveImportedGame(Game game)
        {
            CheckClans(game);
            CheckWarriors(game);

            var result = UpsertGame(game);

            if (result)
            {
                foreach (var player in game.Players)
                {
                    player.GameId = game.Id;
                    result &= UpsertGameWarrior(player);
                    if (!result)
                        break;
                }
            }

            return result;
        }

        private void CheckClans(Game game)
        {
            var databaseClans = _clanDal.GetAll().ToList();

            game.Clan = GetOrInsertClan(databaseClans, game.Clan);
            game.ClanId = game.Clan.Id;

            foreach (var player in game.Players)
            {
                player.Warrior.Clan = GetOrInsertClan(databaseClans, player.Warrior.Clan);
                player.Warrior.ClanId = player.Warrior.Clan.Id;
            }
        }

        private Clan GetOrInsertClan(List<Clan> databaseClans, Clan clan)
        {
            var dbClan = databaseClans.SingleOrDefault(x => x.Hash == clan.Hash);
            if (dbClan == null)
            {
                _clanDal.Insert(clan);
                databaseClans.Add(clan);
                return clan;
            }

            return dbClan;
        }

        private void CheckWarriors(Game game)
        {
            var databaseWarriors = _warriorDal.GetAll().ToList();

            foreach (var player in game.Players)
            {
                player.Warrior = GetOrInsertWarrior(databaseWarriors, player.Warrior);
                player.WarriorId = player.Warrior.Id;
            }
        }

        private Warrior GetOrInsertWarrior(List<Warrior> databaseWarriors, Warrior warrior)
        {
            var dbWarrior = databaseWarriors.SingleOrDefault(x => x.Hash == warrior.Hash);
            if (dbWarrior == null)
            {
                _warriorDal.Insert(warrior);
                databaseWarriors.Add(warrior);
                return warrior;
            }

            return dbWarrior;
        }

        private bool UpsertGame(Game game)
        {
            bool result;
            if (game.Id == 0)
            {
                _gameDal.Insert(game);
                result = game.Id != 0;
            }
            else
            {
                result = _gameDal.Update(game);
            }

            return result;
        }

        private bool UpsertGameWarrior(GameWarrior gameWarrior)
        {
            bool result;
            if (gameWarrior.Id == 0)
            {
                _gameWarriorDal.Insert(gameWarrior);
                result = gameWarrior.Id != 0;
            }
            else
            {
                result = _gameWarriorDal.Update(gameWarrior);
            }

            return result;
        }

        public List<Warrior> GetUnregisteredWarriors(List<Warrior> registeredWarriors)
        {
            var allWarriors = _warriorDal.GetAll();
            var registeredWarriorsId = registeredWarriors.Select(x => x.Id).ToList();
            var unregisteredWarriors = allWarriors.Where(x => !registeredWarriorsId.Contains(x.Id)).ToList();
            unregisteredWarriors.ForEach(FillWarriorClan);
            return unregisteredWarriors;

        }

        public List<Game> GetGamesOfClan(int clanId)
        {
            return _gameDal.GetAll().Where(x => x.ClanId == clanId).ToList();
        }

        private void FillGamesClan(Game game)
        {
            var clan = LoadClan(game.ClanId);
            if (clan == null)
            {
                throw new UnknownClanException();
            }

            game.Clan = clan;
        }

        private void LoadAdditionalGamesData(Game game)
        {
            FillGamesClan(game);

            var allWarriors = _warriorDal.GetAll().ToList();
            var players = _gameWarriorDal.LoadGameWarriors(game.Id);
            players.ForEach(x => FillWarrior(allWarriors, x));
            game.Players = players.OrderByDescending(x => x.Score).ThenBy(x => x.WarriorName).ToList();
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
            var loadedClan = LoadClan(warrior.ClanId);
            warrior.Clan = loadedClan;
        }

        private Clan LoadClan(int clanId)
        {
            if (_loadedClans == null) _loadedClans = new List<Clan>();

            var loadedClan = _loadedClans.SingleOrDefault(x => x.Id == clanId);
            if (loadedClan == null)
            {
                loadedClan = _clanDal.Get(clanId);
                _loadedClans.Add(loadedClan);
            }

            return loadedClan;
        }
    }
}
