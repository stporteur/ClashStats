using ClashData;
using ClashData.SQLite;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness
{
    public class ApplicationManagement : IApplicationManagement
    {
        private readonly ISQLiteManagement _sQLiteManagement;
        private readonly IApplicationSettingDal _applicationSettingDal;

        public ApplicationManagement(ISQLiteManagement sQLiteManagement, IApplicationSettingDal applicationSettingDal)
        {
            _sQLiteManagement = sQLiteManagement;
            _applicationSettingDal = applicationSettingDal;
        }

        public bool ExecuteScript(string filename)
        {
            var script = File.ReadAllText(filename);
            return _sQLiteManagement.ExecuteNonQueryScript(script) > 1;
        }

        public List<ApplicationSetting> GetApplicationSettings()
        {
            return _applicationSettingDal.GetAll().ToList();
        }

        public string GetApplicationSetting(string key)
        {
            return _applicationSettingDal.Get(key).SettingValue;
        }
    }
}
