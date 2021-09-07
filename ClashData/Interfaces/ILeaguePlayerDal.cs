using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface ILeaguePlayerDal : ICrudActions<LeaguePlayer>
    {
        List<Warrior> LoadLeaguePlayers(int leagueId);
    }
}