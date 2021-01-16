using ClashData;
using ClashData.FileSystem;
using ClashData.SQLite;
using ClashEntities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ClashBusiness.Storage
{
    public class StorageManagement : IStorageManagement
    {
        private readonly ISQLiteManagement _sqliteManagement;
        private readonly IFileSystemDal _fileSystemDal;
        private readonly IApplicationSettingDal _applicationSettingDal;

        private List<ApplicationSetting> _applicationSettings;

        public StorageManagement(ISQLiteManagement sqliteManagement, IFileSystemDal fileSystemDal, IApplicationSettingDal applicationSettingDal)
        {
            _sqliteManagement = sqliteManagement;
            _fileSystemDal = fileSystemDal;
            _applicationSettingDal = applicationSettingDal;
        }

        public void InitializeStorage()
        {
            if (!DoesDatabaseExist())
            {
                CreateDatabase();
                CreateDatabaseVersion();
            }

            var databaseVersionsToUpdate = GetDatabaseVersionsToUpdate();
            if (databaseVersionsToUpdate.Count > 0)
            {
                _sqliteManagement.InitializeDatabaseAccess(GetDatabaseFile());

                foreach (var dbVersion in databaseVersionsToUpdate)
                {
                    UpdateDatabaseStructure(dbVersion);
                }
            }
        }

        private void InitializeApplicationSettings()
        {
            if (_applicationSettings == null)
            {
                _applicationSettings = _applicationSettingDal.LoadSettings();
            }
        }

        private string GetAppSetting(string settingName)
        {
            InitializeApplicationSettings();
            return _applicationSettings.Single(x => x.SettingName == settingName).SettingValue;
        }

        private bool DoesDatabaseExist()
        {
            return _fileSystemDal.DoesFileExist(GetDatabaseFile());
        }

        private void CreateDatabase()
        {
            _fileSystemDal.CreateFolder(GetAppSetting("DatabaseFolder"));
            _sqliteManagement.CreateDatabase(GetDatabaseFile());
        }

        private void CreateDatabaseVersion()
        {
            _fileSystemDal.WriteTextFile(GetDatabaseVersionFile(), "v0.0");
        }

        private string GetCurrentDatabaseVersion()
        {
            return _fileSystemDal.ReadTextFile(GetDatabaseVersionFile());
        }

        private string GetDatabaseFile()
        {
            return Path.Combine(GetAppSetting("DatabaseFolder"), GetAppSetting("DatabaseFile"));
        }

        private string GetDatabaseVersionFile()
        {
            return Path.Combine(GetAppSetting("DatabaseFolder"), GetAppSetting("DatabaseVersionFile"));
        }

        private string GetScriptsFolder()
        {
            return Path.Combine(_fileSystemDal.GetCurrentDirectory(), "SQLite");
        }

        private List<string> GetAllDatabaseVersions()
        {
            return _fileSystemDal.GetSubDirectories(GetScriptsFolder());
        }

        private List<string> GetDatabaseVersionsToUpdate()
        {
            var versionNumber = double.Parse(GetCurrentDatabaseVersion().Replace("v", ""), CultureInfo.InvariantCulture);

            var versionsToUdpate = new List<string>();
            foreach (var updateVersion in GetAllDatabaseVersions().OrderBy(x => x))
            {
                var versionNumberUpdate = double.Parse(updateVersion.Replace("v", ""), CultureInfo.InvariantCulture);
                if (versionNumberUpdate > versionNumber)
                {
                    versionsToUdpate.Add(updateVersion);
                }
            }

            return versionsToUdpate;
        }

        private void UpdateDatabaseStructure(string dbVersion)
        {
            var scripts = _fileSystemDal.ReadTextFileByLines(Path.Combine(GetScriptsFolder(), dbVersion, GetAppSetting("DatabaseScriptsFile")));

            foreach (var script in scripts)
            {
                if (!string.IsNullOrEmpty(script))
                {
                    ExecuteScript(_fileSystemDal.ReadTextFile(Path.Combine(GetScriptsFolder(), dbVersion, script)));
                }
            }
            _fileSystemDal.WriteTextFile(GetDatabaseVersionFile(), dbVersion);
        }

        private void ExecuteScript(string sqlCommand)
        {
            _sqliteManagement.ExecuteNonQueryScript(sqlCommand);
        }
    }
}
