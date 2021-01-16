using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public class WarPlayerDal : CrudActions<WarPlayer>, IWarPlayerDal
    {
        public WarPlayerDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<WarPlayer> LoadCurrentWarPlayers(int clanWarId)
        {
            throw new NotImplementedException();
        }
    }
}
