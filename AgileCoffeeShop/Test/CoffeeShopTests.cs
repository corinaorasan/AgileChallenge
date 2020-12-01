using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AgileCoffeeShop.Test
{
    [TestFixture]
    class CoffeeShopTests
    {
        [Test]
        public void TestCalculateDistances()
        {
            Coordinate mockA = new Coordinate();
            mockA.XCoordinate = -122.4;
            mockA.YCoordinate = 47.6;
            Coordinate mockB = new Coordinate();
            mockB.XCoordinate = -122.3340;
            mockB.YCoordinate = 37.5209; 
            var distance = Program.CalculateDistance(mockA, mockB);

            Assert.AreEqual(10.0793, distance);
        }
       
    }
}
