using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void ConvertTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0 }, Day16.Convert(new string[] { "100" }));
        }

        [TestMethod]
        [DataRow(new byte[] { 1 }, 3, new byte[] { 1, 0, 0 })]
        [DataRow(new byte[] { 0 }, 3, new byte[] { 0, 0, 1 })]
        [DataRow(new byte[] { 1, 1, 1, 1, 1 }, 11, new byte[] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 })]
        [DataRow(new byte[] { 1, 0, 0, 0, 0 }, 20, new byte[] { 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1 })]
        public void FillDragonCurveTests(byte[] input, int length, byte[] expected)
        {
            CollectionAssert.AreEqual(expected, Day16.FillWithDragonCurve(input, length));
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
            Assert.AreEqual("10100011010101011", Day16.FirstProblem(Day16.Convert(new string[] { "11100010111110100" })));
        }

        [TestMethod]
        public void SecondProblemTest()
        {
            Assert.AreEqual("01010001101011001", Day16.SecondProblem(Day16.Convert(new string[] { "11100010111110100" })));
        }

    }
}
