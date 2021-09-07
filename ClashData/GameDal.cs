using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class GameDal : CrudActions<Game>, IGameDal
    {
        public GameDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<Game> GetGames(DateTime from, List<int> clanIds)
        {
            string sql = "SELECT * FROM Games WHERE GamesDate >= @from AND ClanId IN @clanIds";
            var parameters = new
            {
                from = from,
                clanIds = clanIds.ToArray()
            };
            return _iSQLiteManagement.GetAll<Game>(sql, parameters).ToList();
        }

        public Game GetCurrentGame(int clanId)
        {
            return _iSQLiteManagement.Get<Game>($"SELECT * FROM Games WHERE ClanId = @clanId ORDER BY GamesDate DESC LIMIT 1", new { clanId = clanId });
        }

        public Game GetGame(string clanHash, DateTime gamesDate)
        {
            string sql = "SELECT g.* FROM Games g INNER JOIN Clans c on g.ClanId = c.Id WHERE g.GamesDate = @gamesDate AND c.Hash = @clanHash";
            var parameters = new
            {
                gamesDate = gamesDate,
                clanHash = clanHash
            };

            return _iSQLiteManagement.Get<Game>(sql, parameters);
        }
    }
}
