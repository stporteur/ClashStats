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

        public List<League> LoadLeagues(List<int> leagueIdsToLoad)
        {
            var leagues = new List<League>();
            foreach (var leagueId in leagueIdsToLoad)
            {
                var league = _leagueDal.Get(leagueId);
                LoadAdditionalLeagueData(league);
                leagues.Add(league);
            }

            return leagues;
        }

        private void LoadAdditionalLeagueData(League league)
        {
            FillLeagueClan(league);

            league.Players = _leaguePlayerDal.LoadLeaguePlayers(league.Id);
            league.Players.ForEach(x => FillWarriorClan(x));

            league.PlayersPerDay = new Dictionary<int, List<LeagueAttack>>();
            for (int i = 1; i <= 7; i++)
            {
                var playersOfDay = _leagueAttackDal.LoadLeaguePlayersOfDay(league.Id, i);
                if (playersOfDay == null)
                {
                    playersOfDay = new List<LeagueAttack>();
                }
                playersOfDay.ForEach(x => FillWarrior(x));
                league.PlayersPerDay.Add(i, playersOfDay);
            }
        }

        public League LoadCurrentLeague(int clanId)
        {
            _loadedWarriors = new List<Warrior>();

            var league = _leagueDal.LoadCurrentLeague(clanId);
            if (league == null)
            {
                return null;
            }

            LoadAdditionalLeagueData(league);

            return league;
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

            var registeredWarriorsId = _leaguePlayerDal.LoadLeaguePlayers(league.Id).Select(x => x.Id);
            var unregisteredWarriors = league.Players.Where(x => !registeredWarriorsId.Contains(x.Id)).ToList();
            foreach (var player in unregisteredWarriors)
            {
                var leaguePlayer = new LeaguePlayer
                {
                    LeagueId = league.Id,
                    WarriorId = player.Id
                };
                _leaguePlayerDal.Insert(leaguePlayer);
                result &= leaguePlayer.Id > 0;
            }


            _leagueAttackDal.DeleteLeaguePlayers(league.Id);
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

        public List<Warrior> GetUnregisteredWarriors(List<Warrior> registeredWarriors)
        {
            var allWarriors = _warriorDal.GetAll();
            var registeredWarriorsId = registeredWarriors.Select(x => x.Id).ToList();
            var unregisteredWarriors = allWarriors.Where(x => !registeredWarriorsId.Contains(x.Id)).ToList();
            unregisteredWarriors.ForEach(FillWarriorClan);
            return unregisteredWarriors;

        }

        private void FillLeagueClan(League league)
        {
            var loadedClan = LoadClan(league.ClanId);
            if (loadedClan == null)
            {
                throw new UnknownClanException();
            }

            league.Clan = loadedClan;
        }

        private void FillWarriorClan(Warrior warrior)
        {
            Clan loadedClan = LoadClan(warrior.ClanId);
            warrior.Clan = loadedClan;
        }

        private Clan LoadClan(int clanId)
        {
            if (_loadedClans == null) _loadedClans = new List<Clan>();

            var loadedClan = _loadedClans.SingleOrDefault(x => x.Id == clanId);
            if (loadedClan == null)
            {
                loadedClan = _clanDal.Get(clanId);
                _loadedClans.Add(loadedClan);
            }

            return loadedClan;
        }

        private void FillWarrior(LeagueAttack attack)
        {
            if (_loadedWarriors == null) _loadedWarriors = new List<Warrior>();

            var loadedWarrior = _loadedWarriors.SingleOrDefault(x => x.Id == attack.WarriorId);
            if (loadedWarrior == null)
            {
                loadedWarrior = _warriorDal.Get(attack.WarriorId);
                _loadedWarriors.Add(loadedWarrior);
            }

            attack.Warrior = loadedWarrior;
            FillWarriorClan(attack.Warrior);
        }

        public List<League> GetClanLeagues(int clanId)
        {
            return _leagueDal.GetAll().Where(x => x.ClanId == clanId).ToList();
        }
    }
}
