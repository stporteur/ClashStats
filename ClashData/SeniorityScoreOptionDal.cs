using ClashData.DataEntities;
using ClashData.SQLite;
using ClashEntities.ScoreOptions;
using System;

namespace ClashData
{
    public class SeniorityScoreOptionsDal : CrudActions<SeniorityBonus>, ISeniorityScoreOptionsDal
    {
        public SeniorityScoreOptionsDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }
    }
}
