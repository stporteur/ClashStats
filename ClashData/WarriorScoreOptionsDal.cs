using ClashEntities.ScoreOptions;
using System;

namespace ClashData
{
    public class WarriorScoreOptionsDal : IWarriorScoreOptionsDal, IScoreOptionsDal
    {
        public T LoadOptions<T>()
        {
            return (T)Convert.ChangeType(LoadOptions(), typeof(T));
        }

        public WarriorScoreOptions LoadOptions()
        {
            throw new NotImplementedException();
        }
    }
}
