using ClashData;
using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
