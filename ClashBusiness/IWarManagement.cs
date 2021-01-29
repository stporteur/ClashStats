using ClashEntities;

namespace ClashBusiness
{
    public interface IWarManagement
    {
        War LoadCurrentWar(int clanId);
        bool RegisterNewWar(War newWar);
        bool UpdateWar(War war);
    }
}