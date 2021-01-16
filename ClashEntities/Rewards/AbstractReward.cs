namespace ClashEntities.Rewards
{
    public class AbstractReward : IAbstractReward
    {
        public int WarriorId { get; set; }
        public string WarrioName { get { return Warrior.Name; } }
        public Warrior Warrior { get; set; }
        public int Score { get; set; }
    }
}
