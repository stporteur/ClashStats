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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClashBusiness.Tests.ApplicationManagementTests
{
    public class ExportTests
    {
        private IApplicationManagement _applicationManagement;
        private ISQLiteManagement _sQLiteManagement;
        private IApplicationSettingDal _applicationSettingDal;
        private IFileSystemDal _fileSystemDal;
        private List<League> _leagues;

        [SetUp]
        public void Setup()
        {
            _sQLiteManagement = Substitute.For<ISQLiteManagement>();
            _applicationSettingDal = Substitute.For<IApplicationSettingDal>();
            _fileSystemDal = Substitute.For<IFileSystemDal>();

            _applicationManagement = new ApplicationManagement(_fileSystemDal, _sQLiteManagement, _applicationSettingDal);

             _leagues = ImportExportHelper.GetLeagues(2);
        }

        [Test]
        public void Should_try_to_create_temporary_export_folder_when_exporting_data()
        {
            _applicationManagement.ExportData(new List<League>(), @"c:\test");

            _fileSystemDal.Received(1).CreateFolder(@"c:\test\ClashTemporaryFolder");
        }

        [Test]
        public void Should_clean_temporary_export_folder_when_exporting_data()
        {
            _applicationManagement.ExportData(new List<League>(), @"c:\test");

            _fileSystemDal.Received().CleanFolder(@"c:\test\ClashTemporaryFolder");
        }

        [Test]
        public void Should_create_file_with_json_from_entity_when_exporting_data()
        {
            _applicationManagement.ExportData(new List<League>{ _leagues[0] }, @"c:\test");
            var json = JsonConvert.SerializeObject(_leagues[0]);
            _fileSystemDal.Received(1).WriteTextFile(@"c:\test\ClashTemporaryFolder\League_1.json", json);
        }

        [Test]
        public void Should_create_2_files_with_json_from_entities_when_exporting_data()
        {
            _applicationManagement.ExportData(new List<League> { _leagues[0], _leagues[1] }, @"c:\test");
            var json1 = JsonConvert.SerializeObject(_leagues[0]);
            var json2 = JsonConvert.SerializeObject(_leagues[1]);

            _fileSystemDal.Received(1).WriteTextFile(@"c:\test\ClashTemporaryFolder\League_1.json", json1);
            _fileSystemDal.Received(1).WriteTextFile(@"c:\test\ClashTemporaryFolder\League_2.json", json2);
        }

        [Test]
        public void Should_create_archive_from_temporary_folder_when_exporting_data()
        {
            _applicationManagement.ExportData(new List<League> { _leagues[0] }, @"c:\test");
            var pattern = $"c:\\test\\ClashExport_League_{DateTime.Now.ToString("yyyyMMdd")}([0-9]+).zip";
            Regex.Match(pattern, @"content/([A-Za-z0-9\-]+)\.aspx$", RegexOptions.IgnoreCase);
            _fileSystemDal.Received(1).CreateFromDirectory(@"c:\test\ClashTemporaryFolder", Arg.Is<string>(x=> x == $"c:\\test\\ClashExport_League_{DateTime.Now.ToString("yyyyMMddhhmmss")}.zip"));
        }

        [Test]
        public void Should_return_true_when_exporting_data()
        {
            var result = _applicationManagement.ExportData(new List<League> { _leagues[0] }, @"c:\test");
            Check.That(result).IsTrue();
        }

        [Test]
        public void Should_return_false_when_exporting_data_and_something_is_wrong()
        {
            _fileSystemDal.When(x=> x.CreateFolder(Arg.Any<string>())).Do(x => { throw new Exception(); });
            var result = _applicationManagement.ExportData(new List<League> { _leagues[0] }, @"c:\test");
            Check.That(result).IsFalse();
        }

        [Test]
        public void Should_clean_temporary_export_folder_before_and_after_when_exporting_data()
        {
            _applicationManagement.ExportData(new List<League>(), @"c:\test");

            Received.InOrder(() =>
            {
                _fileSystemDal.CreateFolder(Arg.Any<string>());
                _fileSystemDal.CleanFolder(Arg.Any<string>());
                _fileSystemDal.CreateFromDirectory(Arg.Any<string>(), Arg.Any<string>());
                _fileSystemDal.CleanFolder(Arg.Any<string>());
                _fileSystemDal.DeleteFolder(Arg.Any<string>());
            }) ;
        }
    }
}
