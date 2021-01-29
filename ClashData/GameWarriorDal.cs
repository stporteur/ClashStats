using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashData
{
    public class GameWarriorDal : CrudActions<GameWarrior>, IGameWarriorDal
    {
        public GameWarriorDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public bool DeleteCurrentGamePlayers(int gameId)
        {
            return _iSQLiteManagement.ExecuteNonQueryScript($"DELETE FROM GameWarriors WHERE GameId = {gameId}") >= 0;
        }

        public List<GameWarrior> GetGames(int warriorId)
        {
            return _iSQLiteManagement.GetAll<GameWarrior>($"SELECT * FROM GameWarriors WHERE WarriorId = {warriorId}").ToList();
        }

        public List<GameWarrior> LoadCurrentGameWarriors(int gameId)
        {
            return _iSQLiteManagement.GetAll<GameWarrior>($"SELECT * FROM GameWarriors WHERE GameId = {gameId}").ToList();
        }
    }
}
