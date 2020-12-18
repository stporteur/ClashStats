using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashBusiness.Rewards
{
    public class RewardManagement
    {
        private readonly ILeagueRewardManagement _leagueRewardManagement;

        public RewardManagement(ILeagueRewardManagement leagueRewardManagement)
        {
            _leagueRewardManagement = leagueRewardManagement;
        }

        public List<Reward> GetRankSuggestion(LeagueWar leagueWar)
        {
            throw new NotImplementedException();
        }
    }
}
