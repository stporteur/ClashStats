using ClashBusiness.EqualityComparers;
using ClashData;
using ClashEntities;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness
{
    public class ClanManagement : IClanManagement
    {
        private readonly IClanDal _clanDal;
        private readonly IEqualityComparer<Clan> _clanEqualityComparer;

        public ClanManagement(IClanDal clanDal, IEqualityComparer<Clan> clanEqualityComparer)
        {
            _clanDal = clanDal;
            _clanEqualityComparer = clanEqualityComparer;
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

                if (!result) break;
            }

            return result;
        }

        public bool DeleteClans(List<Clan> clans)
        {
            var result = true;

            foreach (var clan in clans)
            {
                result &= _clanDal.Delete(clan);
                if (!result) break;
            }

            return result;
        }

        public List<Clan> ImportClans(List<Clan> importedClans)
        {
            var localClans = new List<Clan>();
            var databaseClans = _clanDal.GetAll().ToList();

            foreach (var importedClan in importedClans.Distinct(_clanEqualityComparer))
            {
                var dbClan = databaseClans.SingleOrDefault(x => x.Hash == importedClan.Hash);
                if (dbClan == null)
                {
                    _clanDal.Insert(importedClan);
                    localClans.Add(importedClan);
                }
                else
                {
                    localClans.Add(dbClan);
                }
            }

            return localClans;
        }
    }
}
