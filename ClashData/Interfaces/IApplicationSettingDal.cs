using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IApplicationSettingDal : ICrudActions<ApplicationSetting>
    {
        ApplicationSetting Get(string key);
    }
}