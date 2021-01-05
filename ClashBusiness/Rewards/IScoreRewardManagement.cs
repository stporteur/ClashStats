using ClashEntities;
using ClashEntities.Rewards;
using ClashEntities.ScoreOptions;
using System.Collections.Generic;

namespace ClashBusiness.Rewards
{
    public interface IScoreRewardManagement
    {
        List<IAbstractReward> ComputeLeagueScore(LeagueWar leagueWar);
    }
}