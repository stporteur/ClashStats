using ClashEntities;
using System;

namespace ClashData
{
    public interface IWarDal : ICrudActions<War>
    {
        War LoadCurrentWar(int clanId);
        int GetWarsCount(DateTime from);
        int GetWarsCount(int warriorId);
    }
}