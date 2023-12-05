using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day17Tests
    {

        [TestMethod]
        public void VerifyFirstProblemSimple()
        {
            var data = new string[]
            {
                ".#.",
                "..#",
                "###"
            };

            Assert.AreEqual(112, Day17.FirstProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblemSimple()
        {
            var data = new string[]
            {
                ".#.",
                "..#",
                "###"
            };

            Assert.AreEqual(848, Day17.SecondProblem(data));
        }

        [TestMethod]
        public void VerifySingleRoundUpdateNoW()
        {
            var points = new HashSet<(int X, int Y, int Z, int W)>
            {
                (1, 0, 0, 0),
                (2, 1, 0, 0),
                (0, 2, 0, 0),
                (1, 2, 0, 0),
                (2, 2, 0, 0)
            };

            var transformed = Day17.Transform(points, false);

            var expected = new HashSet<(int X, int Y, int Z, int W)>
            {
                (0, 1, -1, 0),
                (2, 2, -1, 0),
                (1, 3, -1, 0),

                (0, 1, 0, 0),
                (2, 1, 0, 0),
                (1, 2, 0, 0),
                (2, 2, 0, 0),
                (1, 3, 0, 0),

                (0, 1, 1, 0),
                (2, 2, 1, 0),
                (1, 3, 1, 0)
            };

            Assert.AreEqual(expected.Count, transformed.Count);
            foreach (var item in transformed)
            {
                if (!expected.Contains(item))
                {
                    Assert.Fail(item + " was not expected");
                }
            }
        }

        [TestMethod]
        public void VerifySingleRoundUpdateWithW()
        {
            var points = new HashSet<(int X, int Y, int Z, int W)>
            {
                (1, 0, 0, 0),
                (2, 1, 0, 0),
                (0, 2, 0, 0),
                (1, 2, 0, 0),
                (2, 2, 0, 0)
            };

            var transformed = Day17.Transform(points, true);

            var expectedTurnOne = new HashSet<(int X, int Y, int Z, int W)>
            {
                (0, 1, -1, -1),
                (2, 2, -1, -1),
                (1, 3, -1, -1),

                (0, 1, 0, -1),
                (2, 2, 0, -1),
                (1, 3, 0, -1),

                (0, 1, 1, -1),
                (2, 2, 1, -1),
                (1, 3, 1, -1),

                (0, 1, -1, 0),
                (2, 2, -1, 0),
                (1, 3, -1, 0),

                (0, 1, 0, 0),
                (2, 1, 0, 0),
                (1, 2, 0, 0),
                (2, 2, 0, 0),
                (1, 3, 0, 0),

                (0, 1, 1, 0),
                (2, 2, 1, 0),
                (1, 3, 1, 0),

                (0, 1, -1, 1),
                (2, 2, -1, 1),
                (1, 3, -1, 1),

                (0, 1, 0, 1),
                (2, 2, 0, 1),
                (1, 3, 0, 1),

                (0, 1, 1, 1),
                (2, 2, 1, 1),
                (1, 3, 1, 1)
            };

            Assert.AreEqual(expectedTurnOne.Count, transformed.Count);
            foreach (var item in transformed)
            {
                if (!expectedTurnOne.Contains(item))
                {
                    Assert.Fail(item + " was not expected");
                }
            }

            transformed = Day17.Transform(transformed, true);

            Assert.AreEqual(60, transformed.Count);
        }
    }
}
