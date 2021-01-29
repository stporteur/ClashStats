using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class LeagueDal : CrudActions<League>, ILeagueDal
    {
        public LeagueDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<League> GetLeagues(DateTime from, List<int> clanIds)
        {
            string sql = "SELECT * FROM Leagues WHERE LeagueDate >= @from AND ClanId IN @clanIds";
            var parameters = new
            {
                from = from,
                clanIds = clanIds.ToArray()
            };
            return _iSQLiteManagement.GetAll<League>(sql, parameters).ToList();
        }

        public int GetLeaguesCount(int warriorId)
        {
            string sql = "SELECT COUNT(DISTINCT l.Id) FROM Leagues l INNER JOIN LeagueAttacks la ON l.Id = la.LeagueId WHERE la.WarriorId = @warriorId";
            return _iSQLiteManagement.Count(sql, new { warriorId = warriorId });
        }

        public League LoadCurrentLeague(int clanId)
        {
            return _iSQLiteManagement.Get<League>($"SELECT * FROM Leagues WHERE ClanId = @clanId ORDER BY LeagueDate DESC LIMIT 1", new { clanId = clanId });
        }
    }
}
