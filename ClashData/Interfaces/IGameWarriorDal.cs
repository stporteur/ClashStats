using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IGameWarriorDal : ICrudActions<GameWarrior>
    {
        List<GameWarrior> GetGames(int warriorId);
        List<GameWarrior> LoadGameWarriors(int gameId);
        bool DeleteGamePlayers(int id);
    }
}