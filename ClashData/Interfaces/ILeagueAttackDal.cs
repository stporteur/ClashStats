using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface ILeagueAttackDal : ICrudActions<LeagueAttack>
    {
        List<LeagueAttack> LoadLeaguePlayersOfDay(int leagueId, int day);
        bool DeleteLeaguePlayers(int leagueId);
    }
}