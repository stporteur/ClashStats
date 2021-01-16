using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IGameWarriorDal : ICrudActions<GameWarrior>
    {
        List<GameWarrior> GetGames(int warriorId);
    }
}