using ClashData;
using ClashEntities;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness
{
    public class ClanManagement : IClanManagement
    {
        private readonly IClanDal _clanDal;

        public ClanManagement(IClanDal clanDal)
        {
            _clanDal = clanDal;
        }

        public List<Clan> GetClans()
        {
            return _clanDal.GetAll().ToList();
        }

        public bool SaveClans(List<Clan> clans)
        {
            var result = true;

            foreach (var clan in clans)
            {
                if (clan.Id == 0)
                {
                    _clanDal.Insert(clan);
                    result &= clan.Id > 0;
                }
                else
                {
                    result &= _clanDal.Update(clan);
                }
            }

            return result;
        }

        public bool DeleteClans(List<Clan> clans)
        {
            var result = true;

            foreach (var clan in clans)
            {
                result &= _clanDal.Delete(clan);
            }

            return result;
        }
    }
}
