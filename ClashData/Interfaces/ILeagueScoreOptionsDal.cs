using ClashEntities.ScoreOptions;

namespace ClashData
{
    public interface ILeagueScoreOptionsDal
    {
        LeagueScoreOptions LoadOptions();
    }
}