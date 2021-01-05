using ClashEntities;
using System;

namespace ClashData
{
    public interface ILeagueWarDal
    {
        LeagueWar LoadCurrentLeague(int clanId);
        int GetLeaguesCount(DateTime from);
        int GetLeaguesCount(int warriorId);
    }
}