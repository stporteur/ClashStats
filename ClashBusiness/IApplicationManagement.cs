namespace ClashBusiness
{
    public interface IApplicationManagement
    {
        bool ExecuteScript(string filename);
        string GetApplicationSetting(string key);
    }
}