using System;

namespace ClashEntities
{
    public class LeagueWarPlayer : LeagueWarAttack
    {
        public int PlayerId { get; set; }
        public string PlayerName { get { return Player.Name; } }
        public Warrior Player { get; set; }
        public int Position { get; set; }
    }
}
