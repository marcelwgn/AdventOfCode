using AdventOfCode.Year2022.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2022.Tests.Solutions
{
    [TestClass]
    public class Day09Tests
    {

        private static readonly string[] DATA_SMALL = new string[]
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2",
        };

        private static readonly string[] DATA_LARGE = new string[]
        {
            "R 5",
            "U 8",
            "L 8",
            "D 3",
            "R 17",
            "D 10",
            "L 25",
            "U 20",
        };

        [TestMethod]
        public void VerifyFirstProblem()
        {
            Assert.AreEqual(13, Day09.FirstProblem(DATA_SMALL));
        }

        [TestMethod]
        public void VerifySecondProblem()
        {
            Assert.AreEqual(1, Day09.SecondProblem(DATA_SMALL));
            Assert.AreEqual(36, Day09.SecondProblem(DATA_LARGE));
        }
    }
}
