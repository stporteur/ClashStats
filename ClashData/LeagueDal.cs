using ClashData.SQLite;
using ClashEntities;
using System;

namespace ClashData
{
    public class LeagueDal : CrudActions<League>, ILeagueDal
    {
        public LeagueDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public int GetLeaguesCount(DateTime from)
        {
            throw new NotImplementedException();
        }

        public int GetLeaguesCount(int warriorId)
        {
            throw new NotImplementedException();
        }

        public League LoadCurrentLeague(int clanId)
        {
            return _iSQLiteManagement.Get<League>($"SELECT * FROM Leagues WHERE ClanId = {clanId} ORDER BY LeagueDate DESC LIMIT 1");
        }
    }
}
