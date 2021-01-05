using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public interface IGameWarriorDal
    {
        List<GameWarrior> GetGames(int warriorId);
    }
}