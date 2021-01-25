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

        public ApplicationSetting Get(string key)
        {
            return _iSQLiteManagement.Get<ApplicationSetting>($"SELECT * FROM ApplicationSettings WHERE SettingName = '{key}'");
        }
    }
}
