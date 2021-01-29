using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness
{
    public interface IGameManagement
    {
        List<Warrior> GetUnregisteredWarriors(List<Warrior> registeredWarriors);
        Game LoadCurrentGames(int clanId);
        bool RegisterNewGames(Game newGame);
        bool UpdateGames(Game game);
    }
}