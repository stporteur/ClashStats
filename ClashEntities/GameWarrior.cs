namespace ClashEntities
{
    public class GameWarrior
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Warrior Warrior { get; set; }
        public int Score { get; set; }
    }
}
