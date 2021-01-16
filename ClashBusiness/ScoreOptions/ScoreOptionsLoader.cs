using ClashData;
using ClashEntities.ScoreOptions;

namespace ClashBusiness.ScoreOptions
{
    public class ScoreOptionsLoader : IScoreOptionsLoader
    {
        private readonly ILeagueScoreOptionsDal _leagueScoreOptionsDal;
        private readonly IWarriorScoreOptionsDal _warriorScoreOptionsDal;

        public ScoreOptionsLoader(ILeagueScoreOptionsDal leagueScoreOptionsDal, IWarriorScoreOptionsDal warriorScoreOptionsDal)
        {
            _leagueScoreOptionsDal = leagueScoreOptionsDal;
            _warriorScoreOptionsDal = warriorScoreOptionsDal;
        }

        //public T LoadScoreOptions<T>()
        //{
        //    return _leagueScoreOptionsDal.LoadOptions();
        //}

        public LeagueScoreOptions LoadLeagueScoreOptions()
        {
            return _leagueScoreOptionsDal.LoadOptions();
        }

        public WarriorScoreOptions LoadWarriorScoreOptions()
        {
            return _warriorScoreOptionsDal.LoadOptions();
        }
    }
}
