using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day20Tests
    {
        [TestMethod]
        public void ConvertTests()
        {
            var data = new string[]
            {
                "5-8",
                "0-2",
                "4-7"
            };

            var expected = new (uint, uint)[]
            {
                (5,8),
                (0,2),
                (4,7)
            };

            CollectionAssert.AreEqual(expected, Day20.Convert(data));
        }

        [TestMethod]

        public void FirstProblemTest()
        {
            var data = new (uint, uint)[]
            {
                (5,8),
                (0,2),
                (4,7)
            };
            Assert.AreEqual(3u, Day20.FirstProblem(data));
        }

        [TestMethod]

        public void SecondProblemTest()
        {
            var data = new (uint, uint)[]
            {
                (0,2),
                (4,7),
                (5,8),
                (11,14),
                (16, uint.MaxValue)
            };
            Assert.AreEqual(4u, Day20.SecondProblem(data));
        }

        [TestMethod]

        public void GetUniqueIntervalsTest()
        {
            var data = new (uint, uint)[]
            {
                (0,2),
                (4,7),
                (5,8),
                (11,14),
                (12,17),
                (16, 22),
                (25, uint.MaxValue - 10)
            };

            var expected = new List<(long, long)>
            {
                (0,2),(4,8),(11,22),(25, uint.MaxValue - 10)
            };

            CollectionAssert.AreEqual(expected, Day20.GetUniqueIntervals(data));
        }

    }
}
