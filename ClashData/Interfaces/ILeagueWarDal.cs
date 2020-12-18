using ClashEntities;

namespace ClashData
{
    public interface ILeagueWarDal
    {
        LeagueWar LoadCurrentLeague(int clanId);
    }
}