using ClashEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness.Tests.ApplicationManagementTests
{
    public class ImportExportHelper
    {
        private static Random rnd = new Random();
        public static List<League> GetLeagues(int nbLeagues)
        {
            var leagues = new List<League>();

            for(int i = 1; i <= nbLeagues; i++)
            {
                leagues.Add(GetDummyLeague(i));
            }

            return leagues;
        }

        public static League GetDummyLeague(int rangeId)
        {
            var league = new League
            {
                Id = rangeId,
                ClanId = 2,
                Clan = new Clan
                {
                    Id = 20,
                    Name = "dummyClan",
                    Hash = "dummyClanHash"
                },
                LeagueDate = DateTime.Today,
                LeagueSize = 15,
                Position = rnd.Next(7)
            };

            AddWarriors(league);
            AddDays(league);

            return league;
        }

        private static void AddWarriors(League league)
        {
            league.Players = new List<Warrior>();

            for (int i = 0; i < 20; i++)
            {
                var id = league.Id * 10 + i;

                league.Players.Add(new Warrior
                {
                    Id = id,
                    ClanId = league.ClanId,
                    ArrivalDate = DateTime.Today.AddMonths(rnd.Next(60)),
                    Hash = $"#Hash{id}",
                    Name = $"dummyWarrior #{id}",
                    Clan = league.Clan,
                    TownHallLevel = 12,
                    TownHallLevelMaturity = TownHallLevelMaturities.Intermediate
                });
            }
        }


        private static void AddDays(League league)
        {
            league.PlayersPerDay = new Dictionary<int, List<LeagueAttack>>();
            for (int i = 1; i <= 7; i++)
            {
                var attacks = new List<LeagueAttack>();
                league.PlayersPerDay.Add(i, attacks);

                var availableWarriors = league.Players.ToList();

                for (int j = 0; j < 15; j++)
                {

                    var id = i * 100 + j;
                    int r = rnd.Next(availableWarriors.Count);
                    var warrior = availableWarriors[r];
                    availableWarriors.RemoveAt(r);

                    league.PlayersPerDay[i].Add(new LeagueAttack
                    {
                        Id = id,
                        Day = i,
                        AttackDone = true,
                        FailedWarFault = false,
                        IsCoherentAttack = true,
                        HasFollowedStrategy = true,
                        CurrentThLevel = warrior.TownHallLevel,
                        AttackedThLevel = warrior.TownHallLevel,
                        Position = j + 1,
                        Stars = 2,
                        LeagueId = league.Id,
                        Comment = $"dumy comment #{id}",
                        WarriorId = warrior.Id,
                        Warrior = warrior
                    });
                }
            }
        }
    }
}
