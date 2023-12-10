using AdventOfCode.Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Common.Tests.DataStructures
{
    [TestClass]
    public class CoordinateTests
    {
        [TestMethod]
        public void VerifyEquality()
        {
            var coordinateOne = new Coordinate(0, 1);
            var coordinateTwo = new Coordinate(0, 1);

            Assert.IsTrue(coordinateOne == coordinateTwo);
            Assert.AreEqual(coordinateOne, coordinateTwo);
        }
    }
}
