using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness
{
    public interface ILeagueManagement
    {
        League LoadCurrentLeague(int clanId);
        bool RegisterNewLeague(League newLeague);
        bool UpdateLeague(League league);
        List<Warrior> GetUnregisteredWarriors(List<Warrior> registeredWarriors);
    }
}