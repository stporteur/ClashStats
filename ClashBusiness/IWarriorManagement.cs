using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness
{
    public interface IWarriorManagement
    {
        bool DeleteWarriors(List<Warrior> warriors);
        List<Warrior> GetWarriors();
        List<Warrior> GetWarriors(int clanId);
        bool SaveWarriors(List<Warrior> warriors);
    }
}