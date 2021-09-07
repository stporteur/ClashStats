using Dapper.Contrib.Extensions;

namespace ClashEntities
{
    [Table("GameWarriors")]
    public class GameWarrior : IDatabaseEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int WarriorId { get; set; }
        [Write(false)] public Warrior Warrior { get; set; }
        [Write(false)] public string WarriorName { get { return Warrior.Name; } }
        public int Score { get; set; }
    }
}
