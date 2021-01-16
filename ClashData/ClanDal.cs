using ClashData.SQLite;
using ClashEntities;

namespace ClashData
{
    public class ClanDal : CrudActions<Clan>, IClanDal
    {
        public ClanDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }
    }
}
