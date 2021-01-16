using ClashEntities;

namespace ClashData
{
    public interface IWarriorDal : ICrudActions<Warrior>
    {
        Warrior LoadWarrior(int warriorId);
    }
}