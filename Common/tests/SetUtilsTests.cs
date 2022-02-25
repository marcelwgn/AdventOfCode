using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AdventOfCode.Common.Tests
{
    [TestClass]
    public class SetUtilsTests
    {
        [TestMethod]
        public void VerifyGeneratedPowerSet()
        {
            var expected = new int[][]
            {
                Array.Empty<int>(),
                new int[]{1},
                new int[]{2},
                new int[]{3},
                new int[]{1,2},
                new int[]{1,3},
                new int[]{2,3},
                new int[]{1,2,3},
            };

            var actual = SetUtils.FastPowerSet(new int[] { 1, 2, 3 }).OrderBy(x => x.Length).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void VerifyPermutation()
        {
            var expected = new int[][]
            {
                new int[]{1,2,3},
                new int[]{1,3,2},
                new int[]{2,1,3},
                new int[]{2,3,1},
                new int[]{3,1,2},
                new int[]{3,2,1}
            };

            var actual = SetUtils.GetPermutations(new int[] { 1, 2, 3 },3).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i].ToArray());
            }
        }
    }
}
