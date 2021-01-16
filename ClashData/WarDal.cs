using ClashData.SQLite;
using ClashEntities;
using System;

namespace ClashData
{
    public class WarDal : CrudActions<War>, IWarDal
    {
        public WarDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public War LoadCurrentWar()
        {
            throw new NotImplementedException();
        }

        public int GetWarsCount(DateTime from)
        {
            throw new NotImplementedException();
        }

        public int GetWarsCount(int warriorId)
        {
            throw new NotImplementedException();
        }
    }
}
