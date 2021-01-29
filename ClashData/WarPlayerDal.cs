using ClashData.SQLite;
using ClashEntities;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class WarPlayerDal : CrudActions<WarPlayer>, IWarPlayerDal
    {
        public WarPlayerDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<WarPlayer> LoadCurrentWarPlayers(int warId)
        {
            return _iSQLiteManagement.GetAll<WarPlayer>($"SELECT * FROM WarPlayers WHERE WarId = {warId} ORDER BY Position").ToList();
        }
    }
}
