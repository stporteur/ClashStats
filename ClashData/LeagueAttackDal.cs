using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class LeagueAttackDal : CrudActions<LeagueAttack>, ILeagueAttackDal
    {
        public LeagueAttackDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public bool DeleteLeaguePlayers(int leagueId)
        {
            return _iSQLiteManagement.ExecuteNonQueryScript($"DELETE FROM LeagueAttacks WHERE LeagueId = {leagueId}") >= 0;
        }

        public List<LeagueAttack> LoadLeaguePlayersOfDay(int leagueId, int day)
        {
            return _iSQLiteManagement.GetAll<LeagueAttack>($"SELECT * FROM LeagueAttacks WHERE LeagueId = {leagueId} and Day = {day} ORDER BY Position").ToList();
        }
    }
}
