using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashBusiness
{
    public interface IGameManagement
    {
        List<Warrior> GetUnregisteredWarriors(List<Warrior> registeredWarriors);
        Game LoadCurrentGame(int clanId);
        bool RegisterNewGame(Game newGame);
        bool UpdateGame(Game game);
        bool SaveImportedGame(Game game);
        List<Game> GetGamesOfClan(int clanId);
        List<Game> LoadGames(List<int> gameIdsToLoad);
        Game LoadClanGame(string clanHash, DateTime gamesDate);
    }
}