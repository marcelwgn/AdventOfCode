using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day18Tests
    {
        [TestMethod]
        public void ConvertTest()
        {
            CollectionAssert.AreEqual(new bool[] { true, false, false }, Day18.Convert(new string[] { "^.." }));
        }

        [TestMethod]
        [DataRow(new bool[] { false, false, true, true, false }, new bool[] { false, true, true, true, true })]
        [DataRow(new bool[] { false, true, true, true, true }, new bool[] { true, true, false, false, true })]
        public void GenerateNextStepTest(bool[] input, bool[] expected)
        {
            CollectionAssert.AreEqual(expected, Day18.GenerateNextRow(input));
        }

        [TestMethod]
        public void CountSaveTilesTest()
        {
            var initialData = Day18.Convert(new string[] { ".^^.^.^^^^" });
            Assert.AreEqual(38, Day18.CountSaveTiles(initialData, 9));
        }

        [TestMethod]
        [DataRow(new byte[] { 1, 0, 0, 0 }, new byte[] { 0, 1 })]
        [DataRow(new byte[] { 0, 1 }, new byte[] { 0 })]
        [DataRow(new byte[] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }, new byte[] { 1, 1, 0, 1, 1 })]
        public void CollectPatternTest(byte[] input, byte[] expected)
        {
            CollectionAssert.AreEqual(expected, Day16.CalculatePattern(input));
        }

        [TestMethod]
        public void FirstProblemTest()
        {
            Assert.AreEqual(1913, Day18.FirstProblem(Day18.Convert(new string[] { "^.^^^..^^...^.^..^^^^^.....^...^^^..^^^^.^^.^^^^^^^^.^^.^^^^...^^...^^^^.^.^..^^..^..^.^^.^.^......." })));
        }

        [TestMethod]
        public void SecondProblemTest()
        {
            Assert.AreEqual(19993564, Day18.SecondProblem(Day18.Convert(new string[] { "^.^^^..^^...^.^..^^^^^.....^...^^^..^^^^.^^.^^^^^^^^.^^.^^^^...^^...^^^^.^.^..^^..^..^.^^.^.^......." })));
        }

    }
}
