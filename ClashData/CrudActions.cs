using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashData
{
    public abstract class CrudActions<T> : ICrudActions<T> where T : class, IDatabaseEntity
    {
        protected readonly ISQLiteManagement _iSQLiteManagement;

        public CrudActions(ISQLiteManagement iSQLiteManagement)
        {
            _iSQLiteManagement = iSQLiteManagement;
        }

        public T Get(int id)
        {
            return _iSQLiteManagement.Get<T>(id);
        }

        public bool Update(T entity)
        {
            return _iSQLiteManagement.Update(entity);
        }

        public void Insert(T entity)
        {
            entity.Id = _iSQLiteManagement.Insert(entity);
        }

        public bool Delete(T entity)
        {
            return _iSQLiteManagement.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _iSQLiteManagement.GetAll<T>();
        }
    }
}
