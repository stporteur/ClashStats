using ClashData.SQLite;
using ClashEntities;
using System;

namespace ClashData
{
    public class GameDal : CrudActions<Game>, IGameDal
    {
        public GameDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public int GetGamesCount(DateTime from)
        {
            throw new NotImplementedException();
        }
    }
}
