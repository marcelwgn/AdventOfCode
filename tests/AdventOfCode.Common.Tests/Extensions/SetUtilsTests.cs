using AdventOfCode.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCode.Common.Tests.Extensions
{
    [TestClass]
    public class SetUtilsTests
    {
        private static readonly int[] seq = [1, 2, 3];
        private static readonly int[] list = [1, 2, 3];

        [TestMethod]
        public void VerifyGeneratedPowerSet()
        {
            var expected = new int[][]
            {
                [],
                [1],
                [2],
                [3],
                [1,2],
                [1,3],
                [2,3],
                [1,2,3],
            };

            var actual = SetUtils.FastPowerSet(seq).OrderBy(x => x.Length).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void VerifyPermutation()
        {
            var expected = new int[][]
            {
                [1,2,3],
                [1,3,2],
                [2,1,3],
                [2,3,1],
                [3,1,2],
                [3,2,1]
            };

            var actual = SetUtils.GetPermutations(list, 3).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i].ToArray());
            }
        }
    }
}
