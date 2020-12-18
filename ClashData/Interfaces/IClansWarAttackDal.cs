using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IClansWarAttackDal
    {
        List<ClansWarAttack> LoadCurrentWarAttacks(int clansWarId);
    }
}