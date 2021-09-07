using ClashData.SQLite;
using ClashEntities;
using System;

namespace ClashData
{
    public class LeagueBonusDal : CrudActions<LeagueBonus>, ILeagueBonusDal
    {
        public LeagueBonusDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public DateTime? GetLastBonus(int warriorId)
        {
            string sql = "SELECT * FROM LeagueBonus WHERE WarriorId = @warriorId ORDER BY BonusDate DESC LIMIT 1";
            var parameters = new
            {
                warriorId = warriorId
            };
            var lastBonus = _iSQLiteManagement.Get<LeagueBonus>(sql, parameters);

            if (lastBonus != null)
            {
                return lastBonus.BonusDate;
            }

            return null;
        }

    }
}
