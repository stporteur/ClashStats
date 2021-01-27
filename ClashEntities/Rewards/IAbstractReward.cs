namespace ClashEntities.Rewards
{
    public interface IAbstractReward
    {
        int Score { get; set; }
        string WarriorName { get; }
        Warrior Warrior { get; set; }
    }
}