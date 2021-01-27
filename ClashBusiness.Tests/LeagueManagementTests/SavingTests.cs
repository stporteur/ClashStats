using ClashData;
using ClashEntities;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness.Tests.LeagueManagementTests
{
    public class SavingTests
    {
        private ILeagueDal _leagueDal;
        private ILeaguePlayerDal _leaguePlayerDal;
        private ILeagueAttackDal _leagueAttackDal;
        private ILeagueManagement _leagueManagement;

        [SetUp]
        public void Setup()
        {
            _leagueDal = Substitute.For<ILeagueDal>();
            _leagueAttackDal = Substitute.For<ILeagueAttackDal>();
            _leaguePlayerDal = Substitute.For<ILeaguePlayerDal>();
            var warriorDal = Substitute.For<IWarriorDal>();

            var clanDal = Substitute.For<IClanDal>();
            _leagueManagement = new LeagueManagement(clanDal, warriorDal, _leagueDal, _leaguePlayerDal, _leagueAttackDal);
        }

        [Test]
        public void Should_insert_league_when_registering_a_new_league()
        {
            var league = new League { Players = new List<Warrior>() };
            _leagueManagement.RegisterNewLeague(league);

            _leagueDal.Received(1).Insert(league);
        }

        [Test]
        public void Should_associate_player_to_league_when_registering_a_new_league()
        {
            var warrior = new Warrior { Id = 10 };
            var league = new League { Players = new List<Warrior> { warrior } };

            _leagueDal.When(x => x.Insert(league)).Do(x => league.Id = 1);
            LeaguePlayer leaguePlayer = null;
            _leaguePlayerDal.Insert(Arg.Do<LeaguePlayer>(x => leaguePlayer = x));

            _leagueManagement.RegisterNewLeague(league);

            _leaguePlayerDal.Received(1).Insert(Arg.Any<LeaguePlayer>());
            Check.That(leaguePlayer.LeagueId).IsEqualTo(1);
            Check.That(leaguePlayer.WarriorId).IsEqualTo(10);

        }

        [Test]
        public void Should_associate_all_players_to_league_when_registering_a_new_league()
        {
            var warrior = new Warrior { Id = 10 };
            var warrior2 = new Warrior { Id = 20 };
            var league = new League { Players = new List<Warrior> { warrior, warrior2 } };

            _leagueManagement.RegisterNewLeague(league);

            _leaguePlayerDal.Received(2).Insert(Arg.Any<LeaguePlayer>());
        }

        [Test]
        public void Should_update_league_in_database_when_updating_league()
        {
            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack>() },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };

            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            _leagueDal.Received(1).Update(league);
        }

        [Test]
        public void Should_delete_all_days_in_database_when_updating_league()
        {
            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack>() },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };
            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            _leagueAttackDal.Received(1).DeleteCurrentLeaguePlayers(league.Id);
        }

        [Test]
        public void Should_insert_attack_of_first_day_in_database_when_updating_league()
        {
            var leagueAttack = new LeagueAttack();
            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack> { leagueAttack } },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };
            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            _leagueAttackDal.Received(1).Insert(leagueAttack);
        }

        [Test]
        public void Should_insert_all_attacks_of_first_day_in_database_when_updating_league()
        {
            var leagueAttack1 = new LeagueAttack();
            var leagueAttack2 = new LeagueAttack();
            var leagueAttack3 = new LeagueAttack();
            var leagueAttack4 = new LeagueAttack();
            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack> { leagueAttack1, leagueAttack2, leagueAttack3, leagueAttack4 } },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };
            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            _leagueAttackDal.Received(1).Insert(leagueAttack1);
            _leagueAttackDal.Received(1).Insert(leagueAttack2);
            _leagueAttackDal.Received(1).Insert(leagueAttack3);
            _leagueAttackDal.Received(1).Insert(leagueAttack4);
        }

        [Test]
        public void Should_insert_attack_of_all_days_in_database_when_updating_league()
        {
            var leagueAttack1 = new LeagueAttack();
            var leagueAttack2 = new LeagueAttack();
            var leagueAttack3 = new LeagueAttack();
            var leagueAttack4 = new LeagueAttack();
            var leagueAttack5 = new LeagueAttack();
            var leagueAttack6 = new LeagueAttack();
            var leagueAttack7 = new LeagueAttack();
            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack> { leagueAttack1 } },
                    { 2, new List<LeagueAttack> { leagueAttack2 } },
                    { 3, new List<LeagueAttack> { leagueAttack3 } },
                    { 4, new List<LeagueAttack> { leagueAttack4 } },
                    { 5, new List<LeagueAttack> { leagueAttack5 } },
                    { 6, new List<LeagueAttack> { leagueAttack6 } },
                    { 7, new List<LeagueAttack> { leagueAttack7 } }
                }
            };
            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            _leagueAttackDal.Received(1).Insert(leagueAttack1);
            _leagueAttackDal.Received(1).Insert(leagueAttack2);
            _leagueAttackDal.Received(1).Insert(leagueAttack3);
            _leagueAttackDal.Received(1).Insert(leagueAttack4);
            _leagueAttackDal.Received(1).Insert(leagueAttack5);
            _leagueAttackDal.Received(1).Insert(leagueAttack6);
            _leagueAttackDal.Received(1).Insert(leagueAttack7);
        }

        [Test]
        public void Should_insert_all_attacks_of_all_days_in_database_when_updating_league()
        {
            var leagueAttack1 = new LeagueAttack();
            var leagueAttack2 = new LeagueAttack();
            var leagueAttack3 = new LeagueAttack();
            var leagueAttack4 = new LeagueAttack();
            var leagueAttack5 = new LeagueAttack();
            var leagueAttack6 = new LeagueAttack();
            var leagueAttack7 = new LeagueAttack();
            var leagueAttack8 = new LeagueAttack();
            var leagueAttack9 = new LeagueAttack();
            var leagueAttack10 = new LeagueAttack();
            var leagueAttack11 = new LeagueAttack();
            var leagueAttack12 = new LeagueAttack();
            var leagueAttack13 = new LeagueAttack();
            var leagueAttack14 = new LeagueAttack();
            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack> { leagueAttack1, leagueAttack8 } },
                    { 2, new List<LeagueAttack> { leagueAttack2, leagueAttack9 } },
                    { 3, new List<LeagueAttack> { leagueAttack3, leagueAttack10 } },
                    { 4, new List<LeagueAttack> { leagueAttack4, leagueAttack11 } },
                    { 5, new List<LeagueAttack> { leagueAttack5, leagueAttack12 } },
                    { 6, new List<LeagueAttack> { leagueAttack6, leagueAttack13 } },
                    { 7, new List<LeagueAttack> { leagueAttack7, leagueAttack14 } }
                }
            };
            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            _leagueAttackDal.Received(1).Insert(leagueAttack1);
            _leagueAttackDal.Received(1).Insert(leagueAttack2);
            _leagueAttackDal.Received(1).Insert(leagueAttack3);
            _leagueAttackDal.Received(1).Insert(leagueAttack4);
            _leagueAttackDal.Received(1).Insert(leagueAttack5);
            _leagueAttackDal.Received(1).Insert(leagueAttack6);
            _leagueAttackDal.Received(1).Insert(leagueAttack7);
            _leagueAttackDal.Received(1).Insert(leagueAttack8);
            _leagueAttackDal.Received(1).Insert(leagueAttack9);
            _leagueAttackDal.Received(1).Insert(leagueAttack10);
            _leagueAttackDal.Received(1).Insert(leagueAttack11);
            _leagueAttackDal.Received(1).Insert(leagueAttack12);
            _leagueAttackDal.Received(1).Insert(leagueAttack13);
            _leagueAttackDal.Received(1).Insert(leagueAttack14);
        }

        [Test]
        public void Should_reorder_attacks_of_first_day_in_database_when_updating_league()
        {
            var leagueAttack1 = new LeagueAttack();
            var leagueAttack2 = new LeagueAttack();
            var leagueAttack3 = new LeagueAttack();
            var leagueAttack4 = new LeagueAttack();
            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack> { leagueAttack1, leagueAttack2, leagueAttack3, leagueAttack4 } },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };
            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            Check.That(leagueAttack1.Position).IsEqualTo(1);
            Check.That(leagueAttack2.Position).IsEqualTo(2);
            Check.That(leagueAttack3.Position).IsEqualTo(3);
            Check.That(leagueAttack4.Position).IsEqualTo(4);
        }

        [Test]
        public void Should_reorder_attacks_per_day_in_database_when_updating_league()
        {
            var leagueAttack1 = new LeagueAttack();
            var leagueAttack2 = new LeagueAttack();
            var leagueAttack3 = new LeagueAttack();
            var leagueAttack4 = new LeagueAttack();

            var leagueAttack5 = new LeagueAttack();
            var leagueAttack6 = new LeagueAttack();
            var leagueAttack7 = new LeagueAttack();
            var leagueAttack8 = new LeagueAttack();


            var league = new League
            {
                Players = new List<Warrior>(),
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack> { leagueAttack1, leagueAttack2, leagueAttack3, leagueAttack4 } },
                    { 2, new List<LeagueAttack> { leagueAttack5, leagueAttack6, leagueAttack7, leagueAttack8 } },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };
            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>());
            _leagueManagement.UpdateLeague(league);

            Check.That(leagueAttack1.Position).IsEqualTo(1);
            Check.That(leagueAttack2.Position).IsEqualTo(2);
            Check.That(leagueAttack3.Position).IsEqualTo(3);
            Check.That(leagueAttack4.Position).IsEqualTo(4);

            Check.That(leagueAttack5.Position).IsEqualTo(1);
            Check.That(leagueAttack6.Position).IsEqualTo(2);
            Check.That(leagueAttack7.Position).IsEqualTo(3);
            Check.That(leagueAttack8.Position).IsEqualTo(4);
        }

        [Test]
        public void Should_assign_new_player_to_league_in_database_when_updating_league()
        {
            var league = new League
            {
                Id = 1, 
                Players = new List<Warrior>
                {
                    new Warrior { Id = 1},
                    new Warrior { Id = 2}
                },
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack>() },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };

            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>
                {
                    new Warrior { Id = 1}
                });
            _leagueManagement.UpdateLeague(league);

            _leaguePlayerDal.Received(1).Insert(Arg.Is<LeaguePlayer>(x => x.WarriorId == 2 && x.LeagueId == 1));
        }

        [Test]
        public void Should_assign_new_players_to_league_in_database_when_updating_league()
        {
            var league = new League
            {
                Id = 1,
                Players = new List<Warrior>
                {
                    new Warrior { Id = 1},
                    new Warrior { Id = 2},
                    new Warrior { Id = 3}
                },
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack>() },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };

            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>
                {
                    new Warrior { Id = 1}
                });
            _leagueManagement.UpdateLeague(league);

            _leaguePlayerDal.Received(1).Insert(Arg.Is<LeaguePlayer>(x => x.WarriorId == 2 && x.LeagueId == 1));
            _leaguePlayerDal.Received(1).Insert(Arg.Is<LeaguePlayer>(x => x.WarriorId == 3 && x.LeagueId == 1));
        }

        [Test]
        public void Should_not_assign_existing_player_to_league_in_database_when_updating_league()
        {
            var league = new League
            {
                Id = 1,
                Players = new List<Warrior>
                {
                    new Warrior { Id = 1}
                },
                PlayersPerDay = new Dictionary<int, List<LeagueAttack>>
                {
                    { 1, new List<LeagueAttack>() },
                    { 2, new List<LeagueAttack>() },
                    { 3, new List<LeagueAttack>() },
                    { 4, new List<LeagueAttack>() },
                    { 5, new List<LeagueAttack>() },
                    { 6, new List<LeagueAttack>() },
                    { 7, new List<LeagueAttack>() }
                }
            };

            _leaguePlayerDal.LoadCurrentLeaguePlayers(Arg.Any<int>()).Returns(new List<Warrior>
                {
                    new Warrior { Id = 1}
                });
            _leagueManagement.UpdateLeague(league);

            _leaguePlayerDal.DidNotReceive().Insert(Arg.Any<LeaguePlayer>());
        }
    }
}
