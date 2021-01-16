using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface ICrudActions<T> where T : class, IDatabaseEntity
    {
        bool Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        bool Update(T entity);
    }
}