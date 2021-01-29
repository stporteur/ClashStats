using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IGameWarriorDal : ICrudActions<GameWarrior>
    {
        List<GameWarrior> GetGames(int warriorId);
        List<GameWarrior> LoadCurrentGameWarriors(int gameId);
        bool DeleteCurrentGamePlayers(int id);
    }
}