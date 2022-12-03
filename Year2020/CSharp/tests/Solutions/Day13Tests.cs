using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void VerifyFirstProblemWithWaitingTime()
        {
            var minutes = 939;
            var busLines = "7,13,x,x,59,x,31,19";

            Assert.AreEqual(295, Day13.FirstProblem(minutes, busLines));
        }

        [TestMethod]
        public void VerifyFirstProblemWithNoWaitingTime()
        {
            var minutes = 950;
            var busLines = "7,13,x,x,95,x,31,19";

            Assert.AreEqual(0, Day13.FirstProblem(minutes, busLines));
        }

        [TestMethod]
        public void VerifySecondProblemCase1()
        {
            var busLines = "7,13,x,x,59,x,31,19";

            Assert.AreEqual(1068781, Day13.SecondProblem(busLines));
        }

        [TestMethod]
        public void VerifySecondProblemCase2()
        {
            var busLines = "67,7,59,61";

            Assert.AreEqual(754018, Day13.SecondProblem(busLines));
        }

        [TestMethod]
        public void VerifySecondProblemCase3()
        {
            var busLines = "67,x,7,59,61";

            Assert.AreEqual(779210, Day13.SecondProblem(busLines));
        }

        [TestMethod]
        public void VerifySecondProblemCase4()
        {
            var busLines = "67,7,x,59,61";

            Assert.AreEqual(1261476, Day13.SecondProblem(busLines));
        }

        [TestMethod]
        public void VerifySecondProblemCase5()
        {
            var busLines = "1789,37,47,1889";

            Assert.AreEqual(1202161486, Day13.SecondProblem(busLines));
        }
    }
}
