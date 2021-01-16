using ClashData.SQLite;
using ClashEntities;
using System;

namespace ClashData
{
    public class WarriorDal : CrudActions<Warrior>, IWarriorDal
    {
        public WarriorDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public Warrior LoadWarrior(int warriorId)
        {
            throw new NotImplementedException();
        }
    }
}
