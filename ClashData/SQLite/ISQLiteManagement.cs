using System.Collections.Generic;

namespace ClashData.SQLite
{
    public interface ISQLiteManagement
    {
        void CloseConnection();
        void CreateDatabase(string fileName);
        bool Delete<T>(T item) where T : class;
        int ExecuteNonQueryScript(string sqlCommand);
        T Get<T>(int id) where T : class;
        T Get<T>(string query) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> GetAll<T>(string query) where T : class;
        void InitializeDatabaseAccess(string fileName);
        int Insert<T>(T item) where T : class;
        bool Update<T>(T item) where T : class;
    }
}