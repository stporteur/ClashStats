using ClashEntities;
using ClashEntities.Rewards;
using System;
using System.Collections.Generic;

namespace ClashBusiness.Rewards
{
    public interface IRewardManagement
    {
        List<Reward> GetRankSuggestion(League leagueWar);
        void GiveRewards(DateTime leagueDate, List<int> warriors);
    }
}