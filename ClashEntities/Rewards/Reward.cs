using System.Collections.Generic;

namespace ClashEntities.Rewards
{
    public class Reward : AbstractReward
    {
        public List<IAbstractReward> RewardDetails { get; set; }
    }
}
