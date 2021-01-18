using ClashBusiness.Storage;
using ClashData;
using ClashData.FileSystem;
using ClashData.SQLite;
using ClashEntities;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace ClashBusiness.Tests.Storage
{
    public class StorageManagementTests
    {
        private StorageManagement _storageManagement;
        private ISQLiteManagement _sqliteManagement;
        private IFileSystemDal _fileSystemDal;

        [SetUp]
        public void Setup()
        {
            _sqliteManagement = Substitute.For<ISQLiteManagement>();
            
            _fileSystemDal = Substitute.For<IFileSystemDal>();
            _fileSystemDal.ReadTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt").Returns("v0.0");
            _fileSystemDal.GetCurrentDirectory().Returns(@"C:\dummyFolder");
            _fileSystemDal.GetSubDirectories(@"C:\dummyFolder\SQLite").Returns(new List<string>());

            _sqliteManagement.GetDatabaseSettings().Returns(new List<ApplicationSetting>
            {
                new ApplicationSetting { SettingName = "DatabaseFolder", SettingValue = @"C:\ClashStatDatabase" },
                new ApplicationSetting { SettingName = "DatabaseFile", SettingValue = "ClashStat.db" },
                new ApplicationSetting { SettingName = "DatabaseVersionFile", SettingValue = "ClashStatVersion.txt" },
                new ApplicationSetting { SettingName = "DatabaseScriptsFile", SettingValue = "Scripts.txt" }
            });

            _storageManagement = new StorageManagement(_sqliteManagement, _fileSystemDal);
        }

        [Test]
        public void Should_load_application_settings_only_once_when_initializing_storage()
        {
            _storageManagement.InitializeStorage();
            _sqliteManagement.Received(1).GetDatabaseSettings();
        }

        [Test]
        public void Should_create_database_file_version_when_initializing_storage_for_first_time()
        {
            _storageManagement.InitializeStorage();
            _fileSystemDal.Received(1).WriteTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt", "v0.0");
        }

        [Test]
        public void Should_run_script_from_v0_1_folder_when_initializing_storage_for_first_time()
        {
            _fileSystemDal.ReadTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt").Returns("v0.0");
            _fileSystemDal.GetSubDirectories(@"C:\dummyFolder\SQLite").Returns(new List<string> { "v0.1" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.1\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript.sql").Returns("my dummy query to SQLite database");

            _storageManagement.InitializeStorage();

            _sqliteManagement.Received(1).ExecuteNonQueryScript("my dummy query to SQLite database");
        }

        [Test]
        public void Should_update_clash_stat_version_to_v0_1_folder_when_initializing_storage_for_first_time()
        {
            _fileSystemDal.ReadTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt").Returns("v0.0");
            _fileSystemDal.GetSubDirectories(@"C:\dummyFolder\SQLite").Returns(new List<string> { "v0.1" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.1\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript.sql").Returns("my dummy query to SQLite database");

            _storageManagement.InitializeStorage();

            _fileSystemDal.Received(1).WriteTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt", "v0.1");
        }

        [Test]
        public void Should_initialize_database_access_when_initializing_storage_and_there_is_new_version_to_update()
        {
            _fileSystemDal.ReadTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt").Returns("v0.0");
            _fileSystemDal.GetSubDirectories(@"C:\dummyFolder\SQLite").Returns(new List<string> { "v0.1" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.1\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript.sql").Returns("my dummy query to SQLite database");

            _storageManagement.InitializeStorage();

            _sqliteManagement.Received(1).InitializeDatabaseAccess();
        }

        [Test]
        public void Should_not_initialize_database_access_when_initializing_storage_and_there_is_no_new_version_to_update()
        {
            _fileSystemDal.ReadTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt").Returns("v0.0");
            _fileSystemDal.GetSubDirectories(@"C:\dummyFolder\SQLite").Returns(new List<string>());

            _storageManagement.InitializeStorage();

            _sqliteManagement.DidNotReceive().InitializeDatabaseAccess();
        }

        [Test]
        public void Should_call_version_scripts_ordered_by_version_number_when_initializing_storage_with_several_versions_gap()
        {
            _fileSystemDal.ReadTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt").Returns("v0.0");
            _fileSystemDal.GetSubDirectories(@"C:\dummyFolder\SQLite").Returns(new List<string> { "v0.4", "v0.1", "v0.11", "v0.3", "v0.2" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.1\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.11\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.2\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.3\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.4\Scripts.txt").Returns(new List<string> { "dummyScript.sql" });
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript.sql").Returns("my dummy query to SQLite database");
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.11\dummyScript.sql").Returns("my dummy query to SQLite database");
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.2\dummyScript.sql").Returns("my dummy query to SQLite database");
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.3\dummyScript.sql").Returns("my dummy query to SQLite database");
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.4\dummyScript.sql").Returns("my dummy query to SQLite database");

            _storageManagement.InitializeStorage();

            Received.InOrder(() => {
                _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.1\Scripts.txt");
                _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.11\Scripts.txt");
                _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.2\Scripts.txt");
                _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.3\Scripts.txt");
                _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.4\Scripts.txt");
            });
        }

        [Test]
        public void Should_call_scripts_ordered_by_inputs_when_initializing_storage()
        {
            _fileSystemDal.ReadTextFile(@"C:\ClashStatDatabase\ClashStatVersion.txt").Returns("v0.0");
            _fileSystemDal.GetSubDirectories(@"C:\dummyFolder\SQLite").Returns(new List<string> { "v0.1" });
            _fileSystemDal.ReadTextFileByLines(@"C:\dummyFolder\SQLite\v0.1\Scripts.txt").Returns(new List<string> 
            { 
                "dummyScript20.sql",
                "dummyScript10.sql",
                "dummyScript30.sql"
            });
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript20.sql").Returns("my dummy query to SQLite database");
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript10.sql").Returns("my dummy query to SQLite database");
            _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript30.sql").Returns("my dummy query to SQLite database");

            _storageManagement.InitializeStorage();

            Received.InOrder(() => {
                _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript20.sql");
                _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript10.sql");
                _fileSystemDal.ReadTextFile(@"C:\dummyFolder\SQLite\v0.1\dummyScript30.sql");
            });
        }
    }
}
