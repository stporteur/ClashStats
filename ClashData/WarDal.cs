using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class WarDal : CrudActions<War>, IWarDal
    {
        public WarDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public War LoadCurrentWar(int clanId)
        {
            return _iSQLiteManagement.Get<War>($"SELECT * FROM Wars WHERE ClanId = @clanId ORDER BY WarDate DESC LIMIT 1", new { clanId = clanId });
        }

        public int GetWarsCount(DateTime from, int clanId)
        {
            string sql = "SELECT count(*) FROM Wars WHERE WarDate >= @from AND ClanId = @clanId";
            var parameters = new
            {
                from = from,
                clanId = clanId
            };
            return _iSQLiteManagement.Count(sql, parameters);
        }

        public List<War> GetWars(int warriorId)
        {
            string sql = "SELECT w.* FROM Wars w INNER JOIN WarPlayers wp ON w.Id = wp.WarId WHERE wp.WarriorId = @warriorId";
            return _iSQLiteManagement.GetAll<War>(sql, new { warriorId = warriorId }).ToList();
        }
    }
}
