using ClashEntities;
using ClashEntities.Rewards;
using System.Collections.Generic;

namespace ClashBusiness.Rewards
{
    public interface IRewardManagement
    {
        List<Reward> GetRankSuggestion(LeagueWar leagueWar);
    }
}