namespace ClashEntities.Rewards
{
    public class AbstractReward : IAbstractReward
    {
        public string WarrioName { get { return Warrior.Name; } }
        public Warrior Warrior { get; set; }
        public int Score { get; set; }
    }
}
