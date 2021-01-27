using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public interface ILeagueDal : ICrudActions<League>
    {
        League LoadCurrentLeague(int clanId);
        List<League> GetLeagues(DateTime from, List<int> clanIds);
        int GetLeaguesCount(int warriorId);
    }
}