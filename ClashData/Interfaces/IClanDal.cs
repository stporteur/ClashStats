using ClashEntities;

namespace ClashData
{
    public interface IClanDal
    {
        Clan LoadClan(int id);
    }
}