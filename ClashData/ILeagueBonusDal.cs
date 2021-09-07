using ClashEntities;
using System;

namespace ClashData
{
    public interface ILeagueBonusDal : ICrudActions<LeagueBonus>
    {
        DateTime? GetLastBonus(int warriorId);
    }
}