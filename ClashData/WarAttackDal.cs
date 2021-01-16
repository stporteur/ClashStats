using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public class WarAttackDal : CrudActions<WarAttack>, IWarAttackDal
    {
        public WarAttackDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<WarAttack> LoadCurrentWarAttacks(int warId)
        {
            throw new NotImplementedException();
        }
    }
}
