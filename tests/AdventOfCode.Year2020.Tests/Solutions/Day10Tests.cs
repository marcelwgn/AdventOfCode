using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void VerifyFirstProblemShortExample()
        {
            var data = new int[]
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            Assert.AreEqual(7 * 5, Day10.FirstProblem(data));
        }

        [TestMethod]
        public void VerifyFirstProblemLongerExample()
        {
            var data = new int[]
            {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };

            Assert.AreEqual(22 * 10, Day10.FirstProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblemSimpleExample()
        {
            var data = new int[]
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            Assert.AreEqual(8L, Day10.SecondProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblemLongerExample()
        {
            var data = new int[]
            {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };

            Assert.AreEqual(19208L, Day10.SecondProblem(data));
        }

        [TestMethod]
        [DataRow(0, new int[] { -1 })]
        [DataRow(1, new int[] { -1, 0 })]
        [DataRow(2, new int[] { 0, 1 })]
        [DataRow(3, new int[] { 1, 2 })]
        [DataRow(4, new int[] { 2, 3 })]
        [DataRow(5, new int[] { 4 })]
        [DataRow(6, new int[] { 5 })]
        [DataRow(7, new int[] { 6 })]
        [DataRow(8, new int[] { 6, 7 })]
        [DataRow(9, new int[] { 6, 7, 8 })]
        public void VerifyPredecessorValids(int index, int[] expectedData)
        {
            var data = new int[]
            {
                1,2,4,5,7,9,12,13,14,15
            };
            var result = Day10.GetValidPredecessorsIndices(data, index);
            CollectionAssert.AreEqual(expectedData, result);
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 3)]
        [DataRow(3, 5)]
        [DataRow(4, 5)]
        [DataRow(5, 0)]
        public void VerifyPathsToZeroCountValidWithoutCache(int index, int expectedCount)
        {
            var data = new int[]
            {
                1,2,4,5,8,15
            };
            var result = Day10.GetPathsToZero(data, index, null);
            Assert.AreEqual(expectedCount, result);
        }
        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 3)]
        [DataRow(3, 5)]
        [DataRow(4, 5)]
        [DataRow(5, 0)]
        public void VerifyPathsToZeroCountValidWithCache(int index, int expectedCount)
        {
            var data = new int[]
            {
                1,2,4,5,8,15
            };

            var cache = new long[data.Length];

            var result = Day10.GetPathsToZero(data, index, cache);
            Assert.AreEqual(expectedCount, result);
        }

    }
}
