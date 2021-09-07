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

namespace ClashBusiness.Tests
{
    public class ClanManagementTests
    {
        private ClanManagement _clanManagement;
        private IClanDal _clanDal;
        private IEqualityComparer<Clan> _clanEqualityComparer;

        [SetUp]
        public void Setup()
        {
            _clanDal = Substitute.For<IClanDal>();
            _clanEqualityComparer = Substitute.For<IEqualityComparer<Clan>>();
            _clanManagement = new ClanManagement(_clanDal, _clanEqualityComparer);
        }

        [Test]
        public void Should_return_all_clans_in_database()
        {
            var clans = new List<Clan>
            {
                new Clan { Id = 1, Hash = "Hash#1", Name = "Clan 1"},
                new Clan { Id = 2, Hash = "Hash#2", Name = "Clan 2"}
            };

            _clanDal.GetAll().Returns(clans);
            var result = _clanManagement.GetClans();

            Check.That(result).HasSize(clans.Count);
            Check.That(result).ContainsExactly(clans);
        }

        [Test]
        public void Should_insert_clan_when_saving_clans_and_id_is_set_to_0()
        {
            var clan = new Clan { Id = 0, Hash = "Hash#1", Name = "Clan 1" };

            _clanDal.When(x => x.Insert(clan)).Do(x => clan.Id = 1);

            var result = _clanManagement.SaveClans(new List<Clan> { clan });

            Check.That(result).IsTrue();
            _clanDal.Received(1).Insert(clan);
        }

        [Test]
        public void Should_update_clan_when_saving_clans_and_id_is_not_0()
        {
            var clan = new Clan { Id = 1, Hash = "Hash#1", Name = "Clan 1" };

            _clanDal.Update(clan).Returns(true);
            var result = _clanManagement.SaveClans(new List<Clan> { clan });

            Check.That(result).IsTrue();
            _clanDal.Received(1).Update(clan);
        }

        [Test]
        public void Should_upsert_clans_when_saving_clans()
        {
            var clanToInsert = new Clan { Id = 0, Hash = "Hash#1", Name = "Clan 1" };
            var clanToUpdate = new Clan { Id = 1, Hash = "Hash#2", Name = "Clan 2" };

            _clanDal.When(x => x.Insert(clanToInsert)).Do(x => clanToInsert.Id = 1);
            _clanDal.Update(clanToUpdate).Returns(true);

            var result = _clanManagement.SaveClans(new List<Clan> { clanToInsert, clanToUpdate });

            Check.That(result).IsTrue();
            _clanDal.Received(1).Insert(clanToInsert);
            _clanDal.Received(1).Update(clanToUpdate);
        }

        [Test]
        public void Should_stop_upsert_clans_when_saving_clans_and_inserting_failed()
        {
            var clanToInsert = new Clan { Id = 0, Hash = "Hash#1", Name = "Clan 1" };
            var clanToUpdate = new Clan { Id = 1, Hash = "Hash#2", Name = "Clan 2" };

            _clanDal.Update(clanToUpdate).Returns(true);

            var result = _clanManagement.SaveClans(new List<Clan> { clanToInsert, clanToUpdate });

            Check.That(result).IsFalse();
            _clanDal.Received(1).Insert(clanToInsert);
            _clanDal.DidNotReceive().Update(clanToUpdate);
        }

        [Test]
        public void Should_return_false_when_saving_clans_and_last_upsert_failed()
        {
            var clanToInsert = new Clan { Id = 0, Hash = "Hash#1", Name = "Clan 1" };
            var clanToUpdate = new Clan { Id = 1, Hash = "Hash#2", Name = "Clan 2" };
            var clanToUpdate1 = new Clan { Id = 2, Hash = "Hash#3", Name = "Clan 3" };
            var clanToUpdate2 = new Clan { Id = 3, Hash = "Hash#4", Name = "Clan 4" };

            _clanDal.When(x => x.Insert(clanToInsert)).Do(x => clanToInsert.Id = 1);
            _clanDal.Update(clanToUpdate).Returns(true);
            _clanDal.Update(clanToUpdate1).Returns(true);
            _clanDal.Update(clanToUpdate2).Returns(false);

            var result = _clanManagement.SaveClans(new List<Clan> { clanToInsert, clanToUpdate, clanToUpdate1, clanToUpdate2 });

            Check.That(result).IsFalse();
            _clanDal.Received(1).Insert(clanToInsert);
            _clanDal.Received(1).Update(clanToUpdate);
            _clanDal.Received(1).Update(clanToUpdate1);
            _clanDal.Received(1).Update(clanToUpdate2);
        }

        [Test]
        public void Should_delete_clan()
        {
            var clan = new Clan { Id = 1, Hash = "Hash#1", Name = "Clan 1" };

            _clanDal.Delete(clan).Returns(true);

            var result = _clanManagement.DeleteClans(new List<Clan> { clan });

            Check.That(result).IsTrue();
            _clanDal.Received(1).Delete(clan);
        }

        [Test]
        public void Should_delete_clans()
        {
            var clan1 = new Clan { Id = 1, Hash = "Hash#1", Name = "Clan 1" };
            var clan2 = new Clan { Id = 2, Hash = "Hash#2", Name = "Clan 2" };

            _clanDal.Delete(clan1).Returns(true);
            _clanDal.Delete(clan2).Returns(true);

            var result = _clanManagement.DeleteClans(new List<Clan> { clan1, clan2 });

            Check.That(result).IsTrue();
            _clanDal.Received(1).Delete(clan1);
            _clanDal.Received(1).Delete(clan2);
        }

        [Test]
        public void Should_stop_clan_deletion_when_a_clan_deletion_failed()
        {
            var clan1 = new Clan { Id = 1, Hash = "Hash#1", Name = "Clan 1" };
            var clan2 = new Clan { Id = 2, Hash = "Hash#2", Name = "Clan 2" };
            var clan3 = new Clan { Id = 3, Hash = "Hash#3", Name = "Clan 3" };

            _clanDal.Delete(clan1).Returns(true);
            _clanDal.Delete(clan2).Returns(false);

            var result = _clanManagement.DeleteClans(new List<Clan> { clan1, clan2, clan3 });

            Check.That(result).IsFalse();
            _clanDal.Received(1).Delete(clan1);
            _clanDal.Received(1).Delete(clan2);
            _clanDal.DidNotReceive().Delete(clan3);
        }

        [Test]
        public void Should_insert_clan_when_hash_is_not_found_in_database()
        {
            _clanDal.GetAll().Returns(new List<Clan>());

            var clan = new Clan { Hash = "Hash1" };
            _clanManagement.ImportClans(new List<Clan> { clan });

            _clanDal.Received(1).Insert(clan);
        }

        [Test]
        public void Should_not_insert_clan_and_return_clan_from_database_when_hash_is_found_in_database()
        {
            var databaseClan = new Clan { Id = 1, Hash = "Hash1" };
            _clanDal.GetAll().Returns(new List<Clan> { databaseClan });

            var clan = new Clan { Id = 2, Hash = "Hash1" };
            var returnedClan = _clanManagement.ImportClans(new List<Clan> { clan });

            _clanDal.DidNotReceive().Insert(clan);
            Check.That(returnedClan.First().Id).IsEqualTo(databaseClan.Id);
        }

        [Test]
        public void Should_insert_clan_only_once_when_hash_is_not_found_in_database_and_clan_is_duplicated()
        {
            _clanDal.GetAll().Returns(new List<Clan>());

            var clan1 = new Clan { Hash = "Hash1" };
            var clan2 = new Clan { Hash = "Hash1" };

            _clanEqualityComparer.Equals(clan1, clan2).Returns(true);

            var returnedClan = _clanManagement.ImportClans(new List<Clan> { clan1, clan2 });

            _clanDal.Received(1).Insert(clan1);
            _clanDal.DidNotReceive().Insert(clan2);
            Check.That(returnedClan).HasSize(1);
            Check.That(returnedClan.First()).IsEqualTo(clan1);
        }

        [Test]
        public void Should_return_clan_only_once_when_hash_is_found_in_database_and_clan_is_duplicated()
        {
            var databaseClan = new Clan { Id = 1, Hash = "Hash1" };
            _clanDal.GetAll().Returns(new List<Clan> { databaseClan });

            var clan1 = new Clan { Id = 2, Hash = "Hash1" };
            var clan2 = new Clan { Id = 3, Hash = "Hash1" };

            _clanEqualityComparer.Equals(clan1, clan2).Returns(true);

            var returnedClan = _clanManagement.ImportClans(new List<Clan> { clan1, clan2 });

            _clanDal.DidNotReceive().Insert(clan1);
            _clanDal.DidNotReceive().Insert(clan2);
            Check.That(returnedClan).HasSize(1);
            Check.That(returnedClan.First()).IsEqualTo(databaseClan);
        }
    }
}
