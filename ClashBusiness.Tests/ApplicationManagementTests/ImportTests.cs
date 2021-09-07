using ClashBusiness.Exceptions;
using ClashData;
using ClashData.FileSystem;
using ClashData.SQLite;
using ClashEntities;
using Newtonsoft.Json;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness.Tests.ApplicationManagementTests
{
    public class ImportTests
    {
        private IApplicationManagement _applicationManagement;
        private ISQLiteManagement _sQLiteManagement;
        private IApplicationSettingDal _applicationSettingDal;
        private IFileSystemDal _fileSystemDal;
        private List<ApplicationSetting> _applicationSettings;
        private League _league;

        [SetUp]
        public void Setup()
        {
            _sQLiteManagement = Substitute.For<ISQLiteManagement>();
            _applicationSettingDal = Substitute.For<IApplicationSettingDal>();
            _fileSystemDal = Substitute.For<IFileSystemDal>();

            _applicationSettings = new List<ApplicationSetting>
            {
                new ApplicationSetting { Id =1, SettingName = "Setting#1", SettingValue = "Value#1" },
                new ApplicationSetting { Id =2, SettingName = "Setting#2", SettingValue = "Value#2" },
                new ApplicationSetting { Id =3, SettingName = "Setting#3", SettingValue = "Value#3" },
                new ApplicationSetting { Id =4, SettingName = "Setting#4", SettingValue = "Value#4" }
            };
            _applicationSettingDal.GetAll().Returns(_applicationSettings);
            _applicationSettingDal.Get(_applicationSettings[0].SettingName).Returns(_applicationSettings[0]);
            _applicationSettingDal.Get(_applicationSettings[1].SettingName).Returns(_applicationSettings[1]);
            _applicationSettingDal.Get(_applicationSettings[2].SettingName).Returns(_applicationSettings[2]);
            _applicationSettingDal.Get(_applicationSettings[3].SettingName).Returns(_applicationSettings[3]);

            _applicationManagement = new ApplicationManagement(_fileSystemDal, _sQLiteManagement, _applicationSettingDal);
        }

        [Test]
        public void Should_try_to_create_temporary_import_folder_when_importing_data()
        {
            _fileSystemDal.GetFiles(Arg.Any<string>()).Returns(new List<string>());
            _applicationManagement.ImportData<League>(@"c:\test\ClashExport_League_Timestamp.zip");

            _fileSystemDal.Received(1).CreateFolder(@"c:\test\ClashTemporaryFolder");
        }

        [Test]
        public void Should_clean_temporary_import_folder_when_importing_data()
        {
            _fileSystemDal.GetFiles(Arg.Any<string>()).Returns(new List<string>());
            _applicationManagement.ImportData<League>(@"c:\test\ClashExport_League_Timestamp.zip");

            _fileSystemDal.Received().CleanFolder(@"c:\test\ClashTemporaryFolder");
        }

        [Test]
        public void Should_extract_files_to_temporary_folder_when_importing_data()
        {
            _fileSystemDal.GetFiles(Arg.Any<string>()).Returns(new List<string>());
            _applicationManagement.ImportData<League>(@"c:\test\ClashExport_League_Timestamp.zip");

            _fileSystemDal.Received().ExtractToDirectory(@"c:\test\ClashExport_League_Timestamp.zip", @"c:\test\ClashTemporaryFolder");
        }

        [Test]
        public void Should_get_extracted_files_from_temporary_folder_when_importing_data()
        {
            _fileSystemDal.GetFiles(Arg.Any<string>()).Returns(new List<string>());
            _applicationManagement.ImportData<League>(@"c:\test\ClashExport_League_Timestamp.zip");

            _fileSystemDal.Received().GetFiles(@"c:\test\ClashTemporaryFolder");
        }

        [Test]
        public void Should_throw_exception_when_imported_data_type_differs_from_expected_type()
        {
            _fileSystemDal.GetFiles(Arg.Any<string>()).Returns(new List<string>());
            Check.ThatCode(()=> _applicationManagement.ImportData<League>(@"c:\test\ClashExport_War_Timestamp.zip")).Throws<DifferentTypeImportException>();
        }

        [Test]
        public void Should_get_league_entities_when_importing_data()
        {
            var leagues = ImportExportHelper.GetLeagues(3);

            var jsons = new Dictionary<string, string>
            {
                {"file1", JsonConvert.SerializeObject(leagues[0]) },
                {"file2", JsonConvert.SerializeObject(leagues[1]) },
                {"file3", JsonConvert.SerializeObject(leagues[2]) }
            };

            _fileSystemDal.GetFiles(@"c:\test\ClashTemporaryFolder").Returns(jsons.Keys.ToList());

            foreach (var jsonKeyValue in jsons)
            {
                _fileSystemDal.ReadTextFile(jsonKeyValue.Key).Returns(jsonKeyValue.Value);
            }
            
            var result = _applicationManagement.ImportData<League>(@"c:\test\ClashExport_League_Timestamp.zip");

            Check.That(result).HasSize(3);
            Check.That(result[0].Id).IsEqualTo(leagues[0].Id);
            Check.That(result[1].Id).IsEqualTo(leagues[1].Id);
            Check.That(result[2].Id).IsEqualTo(leagues[2].Id);
        }

        [Test]
        public void Should_clean_temporary_folder_before_and_after_when_importing_data()
        {
            _fileSystemDal.GetFiles(Arg.Any<string>()).Returns(new List<string>());
            var result = _applicationManagement.ImportData<League>(@"c:\test\ClashExport_League_Timestamp.zip");

            Received.InOrder(() =>
            {
                _fileSystemDal.CreateFolder(Arg.Any<string>());
                _fileSystemDal.CleanFolder(Arg.Any<string>());
                _fileSystemDal.ExtractToDirectory
                (Arg.Any<string>(), Arg.Any<string>());
                _fileSystemDal.CleanFolder(Arg.Any<string>());
                _fileSystemDal.DeleteFolder(Arg.Any<string>());
            });
        }
    }
}
