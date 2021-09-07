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
    public class OtherTests
    {
        private IApplicationManagement _applicationManagement;
        private ISQLiteManagement _sQLiteManagement;
        private IApplicationSettingDal _applicationSettingDal;
        private IFileSystemDal _fileSystemDal;
        private List<ApplicationSetting> _applicationSettings;

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
        public void Should_read_text_file_and_send_content_to_sql_execution()
        {
            var sqlFile = "dummy.sql";
            var sqlCommand = "Select * from toto";
            _fileSystemDal.ReadTextFile(sqlFile).Returns(sqlCommand);

            _applicationManagement.ExecuteScript(sqlFile);

            _sQLiteManagement.Received(1).ExecuteNonQueryScript(sqlCommand);

        }

        [Test]
        public void Should_get_all_application_settings()
        {
            var settings = _applicationManagement.GetApplicationSettings();

            _applicationSettingDal.Received(1).GetAll();

            Check.That(settings).HasSize(4);
        }

        [Test]
        public void Should_get_application_setting_value_when_existing()
        {
            var firstSetting = _applicationSettings.First();
            var setting = _applicationManagement.GetApplicationSetting(firstSetting.SettingName);

            Check.That(setting).IsEqualTo(firstSetting.SettingValue);
        }


        [Test]
        public void Should_throw_UnknownApplicationSettingException_exception_when_setting_doesnt_exist()
        {
            Check.ThatCode(() => _applicationManagement.GetApplicationSetting("dummySettingKey")).Throws<UnkownapplicationSettingException>();
        }
    }
}
