using ClashEntities;
using ClashEntities.ScoreOptions;
using System.Collections.Generic;

namespace ClashBusiness.Rewards
{
    public interface ILeagueRewardManagement
    {
        List<Reward> ComputeLeagueScore(LeagueWar league, LeagueScoreOptions options);
    }
}