using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public class LeaguePlayerDal : CrudActions<LeaguePlayer>, ILeaguePlayerDal
    {
        public LeaguePlayerDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<Warrior> LoadCurrentLeaguePlayers(int leagueId)
        {
            throw new NotImplementedException();
        }

        public List<LeaguePlayer> LoadCurrentLeaguePlayersOfDay(int leagueId, int day)
        {
            throw new NotImplementedException();
        }
    }
}
