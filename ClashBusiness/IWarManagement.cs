using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness
{
    public interface IWarManagement
    {
        War LoadCurrentWar(int clanId);
        bool RegisterNewWar(War newWar);
        bool UpdateWar(War war);
        List<War> GetClanWars(int clanId);
        List<War> LoadWars(List<int> warIdsToLoad);
    }
}