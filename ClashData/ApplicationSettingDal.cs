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
    }
}
