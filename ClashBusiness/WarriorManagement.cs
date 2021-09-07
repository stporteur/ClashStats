using ClashData;
using ClashEntities;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness
{
    public class WarriorManagement : IWarriorManagement
    {
        private readonly IWarriorDal _warriorDal;

        public WarriorManagement(IWarriorDal warriorDal)
        {
            _warriorDal = warriorDal;
        }

        public List<Warrior> GetWarriors()
        {
            return _warriorDal.GetAll().Where(x => x.IsActive).OrderBy(x=>x.ClanId).ThenBy(x=>x.Name).ToList();
        }

        public List<Warrior> GetWarriors(int clanId)
        {
            return _warriorDal.GetAll().Where(x => x.IsActive && x.ClanId == clanId).ToList();
        }

        public bool SaveWarriors(List<Warrior> warriors)
        {
            var result = true;

            foreach (var warrior in warriors)
            {
                if (warrior.Id == 0)
                {
                    _warriorDal.Insert(warrior);
                    result &= warrior.Id > 0;
                }
                else
                {
                    result &= _warriorDal.Update(warrior);
                }
            }

            return result;
        }

        public bool DeleteWarriors(List<Warrior> warriors)
        {
            var result = true;

            foreach (var warrior in warriors)
            {
                result &= _warriorDal.Delete(warrior);
            }

            return result;
        }
    }
}
