using ClashData;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness
{
    public class MergeManagement : IMergeManagement
    {
        private readonly IClanDal _clanDal;
        private readonly IWarriorDal _warriorDal;

        public MergeManagement(IClanDal clanDal, IWarriorDal warriorDal)
        {
            _clanDal = clanDal;
            _warriorDal = warriorDal;
        }

        public void MergeGames(Game mergeFrom, Game mergeTo)
        {
            mergeTo.GamesEnded = mergeFrom.GamesEnded;

            foreach (var fromPlayer in mergeFrom.Players)
            {
                var toPlayer = mergeTo.Players.SingleOrDefault(x => x.Warrior.Hash == fromPlayer.Warrior.Hash);
                if (toPlayer == null)
                {
                    var warrior = FindOrAddWarrior(fromPlayer.Warrior);
                    toPlayer = new GameWarrior
                    {
                        Id = 0,
                        WarriorId = warrior.Id,
                        Warrior = warrior
                    };
                    mergeTo.Players.Add(toPlayer);
                }
                toPlayer.GameId = mergeTo.Id;

                if (toPlayer.Score < fromPlayer.Score)
                {
                    toPlayer.Score = fromPlayer.Score;
                }
            }

            mergeTo.Players = mergeTo.Players.OrderByDescending(x => x.Score).ThenBy(x => x.WarriorName).ToList();
        }

        private List<Warrior> _allWarriors;
        private Warrior FindOrAddWarrior(Warrior importedWarrior)
        {
            if (_allWarriors == null) _allWarriors = _warriorDal.GetAll().ToList();
            if (_allclans == null) _allclans = _clanDal.GetAll().ToList();

            var warrior = _allWarriors.SingleOrDefault(x => x.Hash == importedWarrior.Hash);
            if (warrior == null)
            {
                var clan = FindOrAddClan(importedWarrior.Clan);
                warrior = new Warrior
                {
                    Id = 0,
                    ArrivalDate = importedWarrior.ArrivalDate,
                    ClanId = clan.Id,
                    Clan = clan,
                    Hash = importedWarrior.Hash,
                    Name = importedWarrior.Name,
                    TownHallLevel = importedWarrior.TownHallLevel,
                    TownHallLevelMaturity = importedWarrior.TownHallLevelMaturity
                };
            }
            else
            {
                warrior.Clan = _allclans.Single(x => x.Id == warrior.ClanId);
            }

            return warrior;
        }

        private List<Clan> _allclans;
        private Clan FindOrAddClan(Clan importedClan)
        {
            if (_allclans == null) _allclans = _clanDal.GetAll().ToList();

            var clan = _allclans.SingleOrDefault(x => x.Hash == importedClan.Hash);
            if (clan == null)
            {
                clan = new Clan
                {
                    Id = 0,
                    Hash = importedClan.Hash,
                    Name = importedClan.Name
                };
            }

            return clan;
        }
    }
}
