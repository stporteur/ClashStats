using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness
{
    public interface IClanManagement
    {
        List<Clan> GetClans();
        bool SaveClans(List<Clan> clans);
        bool DeleteClans(List<Clan> clans);
    }
}