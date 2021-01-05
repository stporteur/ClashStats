using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public interface IGameDal
    {
        int GetGamesCount(DateTime from);
    }
}