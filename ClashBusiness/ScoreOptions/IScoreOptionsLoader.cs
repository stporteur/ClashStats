using ClashEntities.ScoreOptions;

namespace ClashBusiness.ScoreOptions
{
    public interface IScoreOptionsLoader
    {
        LeagueScoreOptions LoadLeagueScoreOptions();
        WarriorScoreOptions LoadWarriorScoreOptions();
    }
}