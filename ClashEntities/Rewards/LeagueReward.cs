namespace ClashEntities.Rewards
{
    public class LeagueReward : AbstractReward
    {
        public int TotalStars { get; set; }
        public int StarScore { get; set; }
        public int TotalHigherAttacks { get; set; }
        public int OpeningAttackScore { get; set; }
        public int TotalAttacksNotDone { get; set; }
        public int AttackNoDoneScore { get; set; }
        public int TotalIncoherentAttacks { get; set; }
        public int IncoherentAttackScore { get; set; }
        public int TotalNotFollowedStrategy { get; set; }
        public int NotFollowedStrategyScore { get; set; }
        public int TotalFailedWarFault { get; set; }
        public int FailedWarFaultScore { get; set; }

    }
}
