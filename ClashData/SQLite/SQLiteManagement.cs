using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace ClashData.SQLite
{
    public class SQLiteManagement : ISQLiteManagement
    {
        private SQLiteConnection _sqliteConnection;

        public void InitializeDatabaseAccess(string fileName)
        {
            _sqliteConnection = new SQLiteConnection($"URI=file:{fileName}");
            _sqliteConnection.Open();
        }

        public void CloseConnection()
        {
            _sqliteConnection.Close();
        }

        public void CreateDatabase(string fileName)
        {
            SQLiteConnection.CreateFile(fileName);
        }

        public int ExecuteNonQueryScript(string sqlCommand)
        {
            var command = new SQLiteCommand(sqlCommand, _sqliteConnection);
            return command.ExecuteNonQuery();
        }

        public T Get<T>(int id) where T : class
        {
            return _sqliteConnection.Get<T>(id);
        }

        public T Get<T>(string query) where T : class
        {
            return _sqliteConnection.Query<T>(query).FirstOrDefault();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _sqliteConnection.GetAll<T>();
        }

        public IEnumerable<T> GetAll<T>(string query) where T : class
        {
            return _sqliteConnection.Query<T>(query);
        }

        public bool Update<T>(T item) where T : class
        {
            return _sqliteConnection.Update<T>(item);
        }

        public int Insert<T>(T item) where T : class
        {
            return (int)_sqliteConnection.Insert(item);
        }

        public bool Delete<T>(T item) where T : class
        {
            return _sqliteConnection.Delete(item);
        }
    }
}
