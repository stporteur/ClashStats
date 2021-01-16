using ClashEntities;
using ClashEntities.Rewards;
using System.Collections.Generic;

namespace ClashBusiness.Rewards
{
    public interface IScoreRewardManagement
    {
        List<IAbstractReward> ComputeLeagueScore(League leagueWar);
    }
}