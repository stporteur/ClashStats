using ClashEntities;

namespace ClashBusiness
{
    public interface IMergeManagement
    {
        void MergeGames(Game mergeFrom, Game mergeTo);
    }
}