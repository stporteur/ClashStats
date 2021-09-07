using ClashBusiness.EqualityComparers;
using ClashEntities;
using NFluent;
using NUnit.Framework;

namespace ClashBusiness.Tests.EqualityComparersTests
{
    public class ClanEqualityComparerTests
    {
        [Test]
        public void Should_return_false_when_first_object_to_compare_is_null()
        {
            Clan clan1 = null;
            Clan clan2 = new Clan();

            var comparer = new ClanEqualityComparer();
            var result = comparer.Equals(clan1, clan2);

            Check.That(result).IsFalse();
        }

        [Test]
        public void Should_return_false_when_second_object_to_compare_is_null()
        {
            Clan clan1 = new Clan();
            Clan clan2 = null;

            var comparer = new ClanEqualityComparer();
            var result = comparer.Equals(clan1, clan2);

            Check.That(result).IsFalse();
        }

        [Test]
        public void Should_return_true_when_both_objects_to_compare_are_null()
        {
            Clan clan1 = null;
            Clan clan2 = null;

            var comparer = new ClanEqualityComparer();
            var result = comparer.Equals(clan1, clan2);

            Check.That(result).IsTrue();
        }

        [Test]
        public void Should_return_true_when_both_clan_hash_to_compare_are_same()
        {
            Clan clan1 = new Clan { Hash = "AAAAA" };
            Clan clan2 = new Clan { Hash = "AAAAA" };

            var comparer = new ClanEqualityComparer();
            var result = comparer.Equals(clan1, clan2);

            Check.That(result).IsTrue();
        }

        [Test]
        public void Should_return_false_when_clan_hash_to_compare_are_different()
        {
            Clan clan1 = new Clan { Hash = "AAAAA" };
            Clan clan2 = new Clan { Hash = "BBBBB" };

            var comparer = new ClanEqualityComparer();
            var result = comparer.Equals(clan1, clan2);

            Check.That(result).IsFalse();
        }

        [Test]
        public void Should_return_clan_hash_as_hashcode()
        {
            Clan clan1 = new Clan { Hash = "AAAAA" };

            var expected = clan1.Hash.GetHashCode();

            var comparer = new ClanEqualityComparer();
            var result = comparer.GetHashCode(clan1);

            Check.That(result).IsEqualTo(expected);
        }
    }
}
