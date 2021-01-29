using ClashBusiness.Exceptions;
using ClashData;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness
{
    public class WarManagement : IWarManagement
    {
        private readonly IClanDal _clanDal;
        private readonly IWarriorDal _warriorDal;
        private readonly IWarDal _warDal;
        private readonly IWarPlayerDal _warPlayerDal;
        private readonly IWarAttackDal _warAttackDal;

        public WarManagement(IClanDal clanDal, IWarriorDal warriorDal, IWarDal warDal, IWarPlayerDal warPlayerDal, IWarAttackDal warAttackDal)
        {
            _clanDal = clanDal;
            _warriorDal = warriorDal;
            _warDal = warDal;
            _warPlayerDal = warPlayerDal;
            _warAttackDal = warAttackDal;
        }

        private List<Clan> _loadedClans;

        public War LoadCurrentWar(int clanId)
        {
            _loadedClans = new List<Clan>();

            var clan = _clanDal.Get(clanId);

            if (clan == null)
            {
                throw new UnkownClanException();
            }

            _loadedClans.Add(clan);

            var war = _warDal.LoadCurrentWar(clan.Id);
            if (war == null)
            {
                return null;
            }

            war.Players = _warPlayerDal.LoadCurrentWarPlayers(war.Id);
            war.Players.ForEach(FillWarrior);

            var attacks = _warAttackDal.LoadCurrentWarAttacks(war.Id);
            foreach(var player in war.Players)
            {
                player.FirstAttack = attacks.Single(x => x.WarPlayerId == player.Id && x.AttackNumber == 1);
                player.SecondAttack = attacks.Single(x => x.WarPlayerId == player.Id && x.AttackNumber == 2);
            }

            return war;
        }

        public bool RegisterNewWar(War newWar)
        {
            var result = true;
            _warDal.Insert(newWar);
            result &= newWar.Id > 0;

            foreach (var player in newWar.Players)
            {
                player.WarId = newWar.Id;
                _warPlayerDal.Insert(player);
                result &= player.Id > 0;
                if (player.Id > 0)
                {
                    var attack1 = new WarAttack
                    {
                        WarId = newWar.Id,
                        WarPlayerId = player.Id,
                        AttackNumber = 1
                    };
                    result &= attack1.Id > 0;
                    _warAttackDal.Insert(attack1);
                    var attack2 = new WarAttack
                    {
                        WarId = newWar.Id,
                        WarPlayerId = player.Id,
                        AttackNumber = 2
                    };
                    _warAttackDal.Insert(attack2);
                    result &= attack2.Id > 0;
                }
            }

            return result;
        }

        public bool UpdateWar(War war)
        {
            var result = _warDal.Update(war);

            foreach(var warPlayer in war.Players)
            {
                result &= _warPlayerDal.Update(warPlayer);
                result &= _warAttackDal.Update(warPlayer.FirstAttack);
                result &= _warAttackDal.Update(warPlayer.SecondAttack);
            }

            return result;
        }

        private void FillWarriorClan(Warrior warrior)
        {
            var loadedClan = _loadedClans.SingleOrDefault(x => x.Id == warrior.ClanId);
            if (loadedClan == null)
            {
                loadedClan = _clanDal.Get(warrior.ClanId);
                _loadedClans.Add(loadedClan);
            }

            warrior.Clan = loadedClan;
        }

        private void FillWarrior(WarPlayer player)
        {
            player.Warrior = _warriorDal.Get(player.WarriorId);
            FillWarriorClan(player.Warrior);
        }
    }
}
