namespace ClashEntities
{
    public class WarAttack
    {
        public int Id { get; set; }
        public int CurrentThLevel { get; set; }
        public int AttackedThLevel { get; set; }
        public int Stars { get; set; }
        public bool AttackDone { get; set; }
        public bool IsCoherentAttack { get; set; }
        public bool HasFollowedStrategy { get; set; }
        public bool FailedWarFault { get; set; }
        public string Comment { get; set; }
    }
}
