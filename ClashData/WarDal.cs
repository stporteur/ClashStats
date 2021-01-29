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

        public War LoadCurrentWar(int clanId)
        {
            return _iSQLiteManagement.Get<War>($"SELECT * FROM Wars WHERE ClanId = @clanId ORDER BY WarDate DESC LIMIT 1", new { clanId = clanId });
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
