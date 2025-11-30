using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        [DataRow(1, 0)]
        [DataRow(2, 3)]
        [DataRow(3, 6)]
        [DataRow(4, 0)]
        [DataRow(5, 3)]
        [DataRow(6, 3)]
        [DataRow(7, 1)]
        [DataRow(8, 0)]
        [DataRow(9, 4)]
        [DataRow(10, 0)]
        [DataRow(2020, 436)]
        public void VerifyAlgorithm(int turn, int expected)
        {
            var data = new int[]
            {
                0,3,6
            };

            Assert.AreEqual(expected, Day15.Algorithm(data, turn));
        }

    }
}
