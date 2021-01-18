using ClashEntities.ScoreOptions;
using System.Collections.Generic;

namespace ClashBusiness.ScoreOptions
{
    public interface IScoreOptionsManagement
    {
        LeagueScoreOptions LoadLeagueScoreOptions();
        WarriorScoreOptions LoadWarriorScoreOptions();

        bool SaveLeagueScoreOptions(LeagueScoreOptions leagueScoreOptions);
        bool SaveWarriorScoreOptions(WarriorScoreOptions leagueScoreOptions);
        bool DeleteTownHallLevelScoreOptions(List<TownHallMaturityBonus> maturities);
        bool DeleteSeniorityScoreOptions(List<SeniorityBonus> seniorities);

    }
}