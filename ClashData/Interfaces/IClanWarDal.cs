using ClashEntities;
using System;

namespace ClashData
{
    public interface IClanWarDal
    {
        ClanWar LoadCurrentWar();
        int GetWarsCount(DateTime from);
        int GetWarsCount(int warriorId);
    }
}