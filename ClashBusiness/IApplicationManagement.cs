using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness
{
    public interface IApplicationManagement
    {
        bool ExecuteScript(string filename);
        List<ApplicationSetting> GetApplicationSettings();
        string GetApplicationSetting(string key);
        List<T> ImportData<T>(string zipFile);
        bool ExportData<T>(List<T> entities, string exportPath) where T : IDatabaseEntity;
    }
}