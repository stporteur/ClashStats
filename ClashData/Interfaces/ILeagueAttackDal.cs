using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface ILeagueAttackDal : ICrudActions<LeagueAttack>
    {
        List<LeagueAttack> LoadCurrentLeaguePlayersOfDay(int leagueId, int day);
        bool DeleteCurrentLeaguePlayers(int leagueId);
    }
}