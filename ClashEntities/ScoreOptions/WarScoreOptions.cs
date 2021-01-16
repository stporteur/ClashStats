namespace ClashEntities.ScoreOptions
{
    public class WarScoreOptions
    {
        public bool ScoreStarResults { get; set; }

        public bool ScoreHigherTownHallVillageAttack { get; set; }
        public int HigherTownHallAttackMinimumStars { get; set; }
        public int HigherTownHallAttackPoints { get; set; }


        public bool ScoreNoAttackDone { get; set; }
        public int NoAttackDonePoints { get; set; }

        public bool ScoreIncoherentAttack { get; set; }
        public int IncoherentAttackPoints { get; set; }

        public bool ScoreNotFollowedStrategy { get; set; }
        public int NotFollowedStrategyPoints { get; set; }

        public bool ScoreFailedWarFault { get; set; }
        public int FailedWarFaultPoints { get; set; }
    }
}
