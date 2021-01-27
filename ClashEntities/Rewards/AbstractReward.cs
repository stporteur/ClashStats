namespace ClashEntities.Rewards
{
    public class AbstractReward : IAbstractReward
    {
        public int WarriorId { get; set; }
        public string WarriorName { get { return Warrior.Name; } }
        public string ClanName { get { return Warrior.Clan.Name; } }
        public Warrior Warrior { get; set; }
        public int Score { get; set; }
    }
}
