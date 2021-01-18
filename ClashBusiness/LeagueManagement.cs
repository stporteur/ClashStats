using ClashBusiness.Exceptions;
using ClashData;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness
{
    public class LeagueManagement : ILeagueManagement
    {
        private readonly IClanDal _clanDal;
        private readonly IWarriorDal _warriorDal;
        private readonly ILeagueDal _leagueDal;
        private readonly ILeaguePlayerDal _leaguePlayerDal;
        private readonly ILeagueAttackDal _leagueAttackDal;

        private List<Clan> _loadedClans;
        private List<Warrior> _loadedWarriors;

        public LeagueManagement(IClanDal clanDal, IWarriorDal warriorDal, ILeagueDal leagueDal, ILeaguePlayerDal leaguePlayerDal, ILeagueAttackDal leagueAttackDal)
        {
            _clanDal = clanDal;
            _warriorDal = warriorDal;
            _leagueDal = leagueDal;
            _leaguePlayerDal = leaguePlayerDal;
            _leagueAttackDal = leagueAttackDal;
        }

        public League LoadCurrentLeague(int clanId)
        {
            _loadedClans = new List<Clan>();
            _loadedWarriors = new List<Warrior>();

            var clan = _clanDal.Get(clanId);

            if (clan == null)
            {
                throw new UnkownClanException();
            }

            _loadedClans.Add(clan);

            var league = _leagueDal.LoadCurrentLeague(clan.Id);
            if (league == null)
            {
                return null;
            }

            league.Players = _leaguePlayerDal.LoadCurrentLeaguePlayers(league.Id);
            league.Players.ForEach(x => FillWarriorClan(x));

            league.PlayersPerDay = new Dictionary<int, List<LeagueAttack>>();
            for (int i = 1; i <= 7; i++)
            {
                var playersOfDay = _leagueAttackDal.LoadCurrentLeaguePlayersOfDay(league.Id, i);
                if (playersOfDay == null)
                {
                    playersOfDay = new List<LeagueAttack>();
                }
                playersOfDay.ForEach(x => FillWarrior(x));
                league.PlayersPerDay.Add(i, playersOfDay);
            }

            return league;
        }

        private void FillWarriorClan(Warrior warrior)
        {
            var loadedClan = _loadedClans.SingleOrDefault(x => x.Id == warrior.ClanId);
            if(loadedClan == null)
            {
                loadedClan = _clanDal.Get(warrior.ClanId);
                _loadedClans.Add(loadedClan);
            }

            warrior.Clan = loadedClan;
        }

        private void FillWarrior(LeagueAttack attack)
        {
            var loadedWarrior = _loadedWarriors.SingleOrDefault(x => x.Id == attack.WarriorId);
            if (loadedWarrior == null)
            {
                loadedWarrior = _warriorDal.Get(attack.WarriorId);
                _loadedWarriors.Add(loadedWarrior);
            }

            attack.Warrior = loadedWarrior;
            FillWarriorClan(attack.Warrior);
        }

        public bool RegisterNewLeague(League newLeague)
        {
            var result = true;
            _leagueDal.Insert(newLeague);
            result &= newLeague.Id > 0;

            foreach (var player in newLeague.Players)
            {
                var leaguePlayer = new LeaguePlayer
                {
                    LeagueId = newLeague.Id,
                    WarriorId = player.Id
                };
                _leaguePlayerDal.Insert(leaguePlayer);
                result &= leaguePlayer.Id > 0;
            }

            return result;
        }

        public bool UpdateLeague(League league)
        {
            var result = _leagueDal.Update(league);

            _leagueAttackDal.DeleteCurrentLeaguePlayers(league.Id);
            for (int i = 1; i <= 7; i++)
            {
                int position = 1;
                foreach (var playerOfDay in league.PlayersPerDay[i])
                {
                    playerOfDay.LeagueId = league.Id;
                    playerOfDay.Position = position;
                    _leagueAttackDal.Insert(playerOfDay);
                    result &= playerOfDay.Id > 0;
                    position++;
                }
            }

            return result;
        }
    }
}
