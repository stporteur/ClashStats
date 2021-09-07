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

        public List<War> LoadWars(List<int> warIdsToLoad)
        {
            var wars = new List<War>();
            foreach (var warId in warIdsToLoad)
            {
                var war = _warDal.Get(warId);
                LoadAdditionalWarData(war);
                wars.Add(war);
            }

            return wars;
        }

        private void LoadAdditionalWarData(War war)
        {
            FillWarClan(war);

            war.Players = _warPlayerDal.LoadCurrentWarPlayers(war.Id);
            war.Players.ForEach(FillWarrior);

            var attacks = _warAttackDal.LoadCurrentWarAttacks(war.Id);
            foreach (var player in war.Players)
            {
                player.FirstAttack = attacks.Single(x => x.WarPlayerId == player.Id && x.AttackNumber == 1);
                player.SecondAttack = attacks.Single(x => x.WarPlayerId == player.Id && x.AttackNumber == 2);
            }
        }

        private void FillWarClan(War war)
        {
            if (_loadedClans == null) _loadedClans = new List<Clan>();

            var loadedClan = _loadedClans.SingleOrDefault(x => x.Id == war.ClanId);
            if (loadedClan == null)
            {
                loadedClan = _clanDal.Get(war.ClanId);

                if (loadedClan == null)
                {
                    throw new UnknownClanException();
                }

                _loadedClans.Add(loadedClan);
            }

            war.Clan = loadedClan;
        }

        public War LoadCurrentWar(int clanId)
        {
            _loadedClans = new List<Clan>();

            var clan = _clanDal.Get(clanId);

            if (clan == null)
            {
                throw new UnknownClanException();
            }

            _loadedClans.Add(clan);

            var war = _warDal.LoadCurrentWar(clan.Id);
            if (war == null)
            {
                return null;
            }

            LoadAdditionalWarData(war);

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
                    result &= AddAttack(newWar, player, 1);
                    result &= AddAttack(newWar, player, 2);
                }
            }

            return result;
        }

        private bool AddAttack(War war, WarPlayer player, int attackNumber)
        {
            var attack = new WarAttack
            {
                WarId = war.Id,
                WarPlayerId = player.Id,
                AttackNumber = attackNumber
            };
            _warAttackDal.Insert(attack);
            return attack.Id > 0;
        }

        public bool UpdateWar(War war)
        {
            var result = _warDal.Update(war);

            foreach (var warPlayer in war.Players)
            {
                result &= _warPlayerDal.Update(warPlayer);
                result &= _warAttackDal.Update(warPlayer.FirstAttack);
                result &= _warAttackDal.Update(warPlayer.SecondAttack);
            }

            return result;
        }

        public List<War> GetClanWars(int clanId)
        {
            return _warDal.GetAll().Where(x => x.ClanId == clanId).ToList();
        }

        private void FillWarriorClan(Warrior warrior)
        {
            if(_loadedClans == null)
            {
                _loadedClans = new List<Clan>();
            }

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
