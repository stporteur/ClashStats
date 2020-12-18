using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface ILeagueWarPlayerDal
    {
        List<Warrior> LoadCurrentLeaguePlayers(int leagueId);
        List<LeagueWarPlayer> LoadCurrentLeaguePlayersOfDay(int leagueId, int day);
    }
}