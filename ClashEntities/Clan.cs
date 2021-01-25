using Dapper.Contrib.Extensions;

namespace ClashEntities
{
    [Table("Clans")]
    public class Clan : IDatabaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
