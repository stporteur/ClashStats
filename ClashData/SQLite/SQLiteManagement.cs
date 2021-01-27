using ClashEntities;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace ClashData.SQLite
{
    public class SQLiteManagement : ISQLiteManagement, IDisposable
    {
        private bool _isDisposed;

        private SQLiteConnection _sqliteConnection;
        private List<ApplicationSetting> _databaseSettings;

        public SQLiteManagement()
        {
            InitializeDatabaseAccess();
        }

        public List<ApplicationSetting> GetDatabaseSettings()
        {
            return new List<ApplicationSetting>
            {
                new ApplicationSetting { SettingName = "DatabaseFolder", SettingValue = @"C:\ClashStatDatabase" },
                new ApplicationSetting { SettingName = "DatabaseFile", SettingValue = "ClashStat.db" },
                new ApplicationSetting { SettingName = "DatabaseVersionFile", SettingValue = "ClashStatVersion.txt" },
                new ApplicationSetting { SettingName = "DatabaseScriptsFile", SettingValue = "Scripts.txt" }
            };
        }

        public string GetDatabaseFile()
        {
            return Path.Combine(GetAppSetting("DatabaseFolder"), GetAppSetting("DatabaseFile"));
        }

        public void InitializeDatabaseAccess()
        {
            _sqliteConnection = new SQLiteConnection($"URI=file:{GetDatabaseFile()}");
            _sqliteConnection.Open();
        }

        public void CloseConnection()
        {
            _sqliteConnection.Close();
        }

        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile(GetDatabaseFile());
        }

        public int ExecuteNonQueryScript(string sqlCommand)
        {
            var command = new SQLiteCommand(sqlCommand, _sqliteConnection);
            return command.ExecuteNonQuery();
        }

        public int Count(string sqlCommand)
        {
            return _sqliteConnection.QuerySingle<int>(sqlCommand);
        }

        public int Count(string sqlCommand, object parameters)
        {
            return _sqliteConnection.QuerySingle<int>(sqlCommand, parameters);
        }

        #region CRUD
        public T Get<T>(int id) where T : class
        {
            return _sqliteConnection.Get<T>(id);
        }

        public T Get<T>(string query) where T : class
        {
            return _sqliteConnection.Query<T>(query).FirstOrDefault();
        }

        public T Get<T>(string query, object parameters) where T : class
        {
            return _sqliteConnection.Query<T>(query, parameters).FirstOrDefault();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _sqliteConnection.GetAll<T>();
        }

        public IEnumerable<T> GetAll<T>(string query) where T : class
        {
            return _sqliteConnection.Query<T>(query);
        }

        public IEnumerable<T> GetAll<T>(string query, object parameters) where T : class
        {
            return _sqliteConnection.Query<T>(query, parameters);
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
        #endregion

        private void InitializeApplicationSettings()
        {
            if (_databaseSettings == null)
            {
                _databaseSettings = GetDatabaseSettings();
            }
        }

        private string GetAppSetting(string settingName)
        {
            InitializeApplicationSettings();
            return _databaseSettings.Single(x => x.SettingName == settingName).SettingValue;
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                CloseConnection();
            }

            _isDisposed = true;
        }

        ~SQLiteManagement()
        {
            Dispose(false);
        } 
        #endregion
    }
}
