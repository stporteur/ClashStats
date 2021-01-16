using ClashBusiness.Exceptions;
using ClashData;
using ClashEntities;
using System.Collections.Generic;

namespace ClashBusiness
{
    public class LeagueManagement
    {
        private readonly IClanDal _clanDal;
        private readonly ILeagueDal _leagueWarDal;
        private readonly ILeaguePlayerDal _leagueWarPlayerDal;

        public LeagueManagement(IClanDal clanDal, ILeagueDal leagueWarDal, ILeaguePlayerDal leagueWarPlayerDal)
        {
            _clanDal = clanDal;
            _leagueWarDal = leagueWarDal;
            _leagueWarPlayerDal = leagueWarPlayerDal;
        }

        public League LoadCurrentLeague(int clanId)
        {
            var clan = _clanDal.Get(clanId);

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

            leagueWar.PlayersPerDay = new Dictionary<int, List<LeaguePlayer>>();
            for(int i = 1; i <= 7; i++)
            {
                var playersOfDay = _leagueWarPlayerDal.LoadCurrentLeaguePlayersOfDay(leagueWar.Id, i);
                if(playersOfDay == null)
                {
                    playersOfDay = new List<LeaguePlayer>();
                }
                leagueWar.PlayersPerDay.Add(i, playersOfDay);
            }

            return leagueWar;
        }
    }
}
