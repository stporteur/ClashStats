using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashData
{
    public class ApplicationSettingDal : CrudActions<ApplicationSetting>, IApplicationSettingDal
    {
        public ApplicationSettingDal(ISQLiteManagement iSQLiteManagement) : base(iSQLiteManagement)
        {
        }

        public List<ApplicationSetting> LoadSettings()
        {
            return new List<ApplicationSetting>
            {
                new ApplicationSetting { SettingName = "DatabaseFolder", SettingValue = @"C:\ClashStatDatabase" },
                new ApplicationSetting { SettingName = "DatabaseFile", SettingValue = "ClashStat.db" },
                new ApplicationSetting { SettingName = "DatabaseVersionFile", SettingValue = "ClashStatVersion.txt" },
                new ApplicationSetting { SettingName = "DatabaseScriptsFile", SettingValue = "Scripts.txt" }
            };
        }
    }
}
