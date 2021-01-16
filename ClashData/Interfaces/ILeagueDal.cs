using ClashEntities;
using System;

namespace ClashData
{
    public interface ILeagueDal : ICrudActions<League>
    {
        League LoadCurrentLeague(int clanId);
        int GetLeaguesCount(DateTime from);
        int GetLeaguesCount(int warriorId);
    }
}