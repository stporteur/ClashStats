using ClashData.DataEntities;
using ClashData.SQLite;
using ClashEntities.ScoreOptions;
using System;

namespace ClashData
{
    public class ScoreOptionsDal : CrudActions<ScoreOption>, IScoreOptionsDal
    {
        public ScoreOptionsDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }
    }
}
