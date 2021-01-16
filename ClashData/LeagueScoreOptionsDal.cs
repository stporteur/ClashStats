using ClashEntities.ScoreOptions;
using System;

namespace ClashData
{
    public class LeagueScoreOptionsDal : ILeagueScoreOptionsDal, IScoreOptionsDal
    {
        public T LoadOptions<T>()
        {
            return (T)Convert.ChangeType(LoadOptions(), typeof(T));
        }

        public LeagueScoreOptions LoadOptions()
        {
            throw new NotImplementedException();
        }
    }
}
