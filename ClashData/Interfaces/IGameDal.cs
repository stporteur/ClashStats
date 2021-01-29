using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public interface IGameDal : ICrudActions<Game>
    {
        List<Game> GetGames(DateTime from, List<int> clanIds);
        Game LoadCurrentGame(int clanId);
    }
}