namespace ClashEntities
{
    public class GameWarrior : IDatabaseEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int WarriorId { get; set; }
        public Warrior Warrior { get; set; }
        public int Score { get; set; }
    }
}
