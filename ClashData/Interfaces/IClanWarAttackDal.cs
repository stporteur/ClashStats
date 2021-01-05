using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IClanWarAttackDal
    {
        List<ClanWarAttack> LoadCurrentWarAttacks(int clanWarId);
    }
}