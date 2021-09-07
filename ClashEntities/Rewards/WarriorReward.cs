namespace ClashEntities.Rewards
{
    public class WarriorReward : AbstractReward
    {
        public double LeagueParticipationRatio { get; set; }
        public int LeagueParticipationScore { get; set; }
        public double WarParticipationRatio { get; set; }
        public int WarParticipationScore { get; set; }
        public double GameParticipationRatio { get; set; }
        public int GameParticipationScore { get; set; }
        public double SucceedeedGameRatio { get; set; }
        public int SucceedeedGameScore { get; set; }
        public double SnippedGameRatio { get; set; }
        public int SnippedGameScore { get; set; }
        public int TownhallLevelScore { get; set; }
        public int SeniorityScore { get; set; }
        public int LastBonusInMonth { get; set; }
        public int LastBonusScore { get; set; }

    }
}
