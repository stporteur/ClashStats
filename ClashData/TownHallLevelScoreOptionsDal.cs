using ClashData.DataEntities;
using ClashData.SQLite;
using ClashEntities.ScoreOptions;
using System;

namespace ClashData
{
    public class TownHallLevelScoreOptionsDal : CrudActions<TownHallMaturityBonus>, ITownHallLevelScoreOptionsDal
    {
        public TownHallLevelScoreOptionsDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }
    }
}
