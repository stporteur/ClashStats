using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface ILeaguePlayerDal
    {
        List<Warrior> LoadCurrentLeaguePlayers(int leagueId);
        List<LeaguePlayer> LoadCurrentLeaguePlayersOfDay(int leagueId, int day);
    }
}