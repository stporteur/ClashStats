using ClashEntities;
using System;

namespace ClashData
{
    public interface IWarDal : ICrudActions<War>
    {
        War LoadCurrentWar();
        int GetWarsCount(DateTime from);
        int GetWarsCount(int warriorId);
    }
}