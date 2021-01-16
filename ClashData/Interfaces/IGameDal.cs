using ClashEntities;
using System;

namespace ClashData
{
    public interface IGameDal : ICrudActions<Game>
    {
        int GetGamesCount(DateTime from);
    }
}