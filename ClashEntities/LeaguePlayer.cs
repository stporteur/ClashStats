namespace ClashEntities
{
    public class LeaguePlayer : LeagueAttack, IDatabaseEntity
    {
        public int WarriorId { get; set; }
        public string WarriorName { get { return Warrior.Name; } }
        public Warrior Warrior { get; set; }
        public int Position { get; set; }
    }
}
