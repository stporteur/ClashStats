using ClashBusiness.Exceptions;
using ClashData;
using ClashEntities;
using System;
using System.Collections.Generic;

namespace ClashBusiness
{
    public class LeagueManagement
    {
        private readonly IClanDal _clanDal;
        private readonly ILeagueWarDal _leagueWarDal;
        private readonly ILeagueWarPlayerDal _leagueWarPlayerDal;

        public LeagueManagement(IClanDal clanDal, ILeagueWarDal leagueWarDal, ILeagueWarPlayerDal leagueWarPlayerDal)
        {
            _clanDal = clanDal;
            _leagueWarDal = leagueWarDal;
            _leagueWarPlayerDal = leagueWarPlayerDal;
        }

        public LeagueWar LoadCurrentLeague(int clanId)
        {
            var clan = _clanDal.LoadClan(clanId);

            if (clan == null)
            {
                throw new UnkownClanException();
            }

            var leagueWar = _leagueWarDal.LoadCurrentLeague(clan.Id);
            if (leagueWar == null)
            {
                return null;
            }

            leagueWar.Players = _leagueWarPlayerDal.LoadCurrentLeaguePlayers(leagueWar.Id);

            leagueWar.PlayersPerDay = new Dictionary<int, List<LeagueWarPlayer>>();
            for(int i = 1; i <= 7; i++)
            {
                var playersOfDay = _leagueWarPlayerDal.LoadCurrentLeaguePlayersOfDay(leagueWar.Id, i);
                if(playersOfDay == null)
                {
                    playersOfDay = new List<LeagueWarPlayer>();
                }
                leagueWar.PlayersPerDay.Add(i, playersOfDay);
            }

            return leagueWar;
        }
    }
}
