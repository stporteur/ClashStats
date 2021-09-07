using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class LeaguePlayerDal : CrudActions<LeaguePlayer>, ILeaguePlayerDal
    {
        public LeaguePlayerDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<Warrior> LoadLeaguePlayers(int leagueId)
        {
            return _iSQLiteManagement.GetAll<Warrior>($"SELECT W.* FROM Warriors W INNER JOIN LeaguePlayers LP ON W.Id = LP.WarriorId WHERE LP.LeagueId = {leagueId}").ToList();
        }
    }
}
