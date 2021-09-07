using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace ClashEntities
{
    [Table("LeagueBonus")]
    public class LeagueBonus : IDatabaseEntity
    {
        public int Id { get; set; }
        public int WarriorId { get; set; }
        [Write(false)] public string WarriorName { get { return Warrior.Name; } }
        [Write(false)] public Warrior Warrior { get; set; }
        public DateTime BonusDate { get; set; }
    }
}
