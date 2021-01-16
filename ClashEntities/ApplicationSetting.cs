namespace ClashEntities
{
    public class ApplicationSetting : IDatabaseEntity
    {
        public int Id { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
