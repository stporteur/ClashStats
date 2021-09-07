using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness.EqualityComparers
{
    public class ClanEqualityComparer : IEqualityComparer<Clan>
    {
        public bool Equals(Clan c1, Clan c2)
        {
            if (c2 == null && c1 == null)
                return true;
            else if (c1 == null || c2 == null)
                return false;
            else if (c1.Hash == c2.Hash)
                return true;
            else
                return false;
        }

        public int GetHashCode(Clan clan)
        {
            return clan.Hash.GetHashCode();
        }
    }
}
