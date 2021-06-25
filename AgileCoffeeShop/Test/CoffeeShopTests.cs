using NUnit.Framework;

namespace AgileCoffeeShop.Test
{
    [TestFixture]
    class CoffeeShopTests
    {
        [Test]
        public void TestCalculateDistances()
        {
            Coordinate mockA = new Coordinate(-122.4, 47.6);
            Coordinate mockB = new Coordinate(-122.3340, 37.5209);
            var distance = Program.CalculateDistance(mockA, mockB);
            Assert.AreEqual(10.0793, distance);
        }
       
    }
}
