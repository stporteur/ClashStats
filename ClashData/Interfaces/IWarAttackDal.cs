using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IWarAttackDal : ICrudActions<WarAttack>
    {
        List<WarAttack> LoadCurrentWarAttacks(int clanWarId);
    }
}