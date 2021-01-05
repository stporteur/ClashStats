namespace ClashEntities.Rewards
{
    public interface IAbstractReward
    {
        int Score { get; set; }
        string WarrioName { get; }
        Warrior Warrior { get; set; }
    }
}