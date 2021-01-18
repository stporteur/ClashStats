using ClashEntities;

namespace ClashBusiness
{
    public interface ILeagueManagement
    {
        League LoadCurrentLeague(int clanId);
        bool RegisterNewLeague(League newLeague);
        bool UpdateLeague(League league);
    }
}