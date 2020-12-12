using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day12Tests
    {

        [TestMethod]
        public void VerifyFirstProblemCase1()
        {
            var data = new string[]
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            };

            Assert.AreEqual(25, Day12.FirstProblem(data));
        }

        [TestMethod]
        public void VerifyFirstProblemCase2()
        {
            var data = new string[]
            {
                "F10",
                "L90",
                "F5",
                "N9",
                "E11"
            };

            Assert.AreEqual(35, Day12.FirstProblem(data));
        }

        [TestMethod]
        public void VerifyFirstProblemCase3()
        {
            var data = new string[]
            {
                "S10",
                "W3",
                "F7",
                "L90",
                "F11"
            };

            Assert.AreEqual(5, Day12.FirstProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblemCase1()
        {
            var data = new string[]
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            };

            Assert.AreEqual(286, Day12.SecondProblem(data));
        }


        [TestMethod]
        public void VerifySecondProblemCase2()
        {
            var data = new string[]
            {
                "F10",
                "L90",
                "F5",
                "N9",
                "E11"
            };

            Assert.AreEqual(155, Day12.SecondProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblemCase3()
        {
            var data = new string[]
            {
                "S10",
                "W3",
                "F7",
                "L90",
                "F11"
            };

            Assert.AreEqual(162, Day12.SecondProblem(data));
        }
    }
}
