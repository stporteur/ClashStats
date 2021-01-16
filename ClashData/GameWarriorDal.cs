using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public class GameWarriorDal : CrudActions<GameWarrior>, IGameWarriorDal
    {
        public GameWarriorDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<GameWarrior> GetGames(int warriorId)
        {
            throw new NotImplementedException();
        }
    }
}
