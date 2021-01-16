using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IApplicationSettingDal : ICrudActions<ApplicationSetting>
    {
        List<ApplicationSetting> LoadSettings();
    }
}