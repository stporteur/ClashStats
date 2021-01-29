using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class WarAttackDal : CrudActions<WarAttack>, IWarAttackDal
    {
        public WarAttackDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<WarAttack> LoadCurrentWarAttacks(int warId)
        {
            return _iSQLiteManagement.GetAll<WarAttack>($"SELECT * FROM WarAttacks WHERE WarId = {warId}").ToList();
        }
    }
}
