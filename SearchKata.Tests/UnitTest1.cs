using NUnit.Framework;
using System.Collections.Generic;

namespace SearchKata.Tests
{
    [TestFixture]
    public class Tests
    {
        ICityFinder _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new CityFinder(new DbCities());
        }

        [Test]
        public void Find_ReturnsNoResult_IfSearchTermLessThan2char()
        {
            Assert.IsEmpty(_sut.Find("A"));
            Assert.IsEmpty(_sut.Find("R"));
            Assert.IsEmpty(_sut.Find(""));
        }


        [Test]
        public void Find_ReturnCityExactMatch()
        {
            var expected = new List<string>() { "Paris" };

            var actual = _sut.Find("Paris");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Find_ReturnsCitiesStartingWithSearchTerm()
        {
            var expected = new List<string>() { "Valencia", "Vancouver" };

            var actual = _sut.Find("Va");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Find_ReturnsCitiesStartingWithSearchTerm_CaseInsensitive()
        {
            var expected = new List<string>() { "Valencia", "Vancouver" };

            var actual = _sut.Find("vA");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Find_ReturnsSingleCityContainingSearchTerm()
        {
            var expected = new List<string>() { "Budapest" };

            var actual = _sut.Find("ape");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Find_ReturnsCitiesContainingSearchTerm()
        {
            var expected = new List<string>() { "Bangkok", "Hong Kong" };

            var actual = _sut.Find("ng");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Find_ReturnsAllCities_WhenAsterisk()
        {
            var expected = new List<string>() {
                "Paris",
                "Budapest",
                "Skopje",
                "Rotterdam",
                "Valencia",
                "Vancouver",
                "Amsterdam",
                "Vienna",
                "Sydney",
                "New York City",
                "London",
                "Bangkok",
                "Hong Kong",
                "Dubai",
                "Rome",
                "Istanbul"
            };

            var actual = _sut.Find("*");

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}