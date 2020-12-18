using ClashEntities;

namespace ClashData
{
    public interface IWarriorDal
    {
        Warrior LoadWarrior(int warriorId);
    }
}