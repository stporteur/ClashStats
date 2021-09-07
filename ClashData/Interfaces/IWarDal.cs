using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public interface IWarDal : ICrudActions<War>
    {
        War LoadCurrentWar(int clanId);
        int GetWarsCount(DateTime from, int clanId);
        List<War> GetWars(int warriorId);
    }
}