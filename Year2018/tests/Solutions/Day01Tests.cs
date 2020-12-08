using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day01Tests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = { "1", "-2", "3" };

            int[] dataConverted = Day01.Convert(data);

            Assert.AreEqual(1, dataConverted[0]);
            Assert.AreEqual(-2, dataConverted[1]);
            Assert.AreEqual(3, dataConverted[2]);
        }

        [TestMethod()]
        public void FirstProblemTestAllPositive()
        {
            int[] data = { 1, 1, 1 };

            int result = Day01.FirstProblem(data);

            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void FirstProblemTestPositiveAndNegative()
        {
            int[] data = { 1, 1, -2 };

            int result = Day01.FirstProblem(data);

            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void FirstProblemTestAllNegative()
        {
            int[] data = { -1, -2, -3 };

            int result = Day01.FirstProblem(data);

            Assert.AreEqual(-6, result);
        }

        [TestMethod()]
        public void SecondProblemTestOne()
        {
            int[] data = { 1, -2, 3, 1 };

            int result = Day01.SecondProblem(data);

            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void SecondProblemTestTwo()
        {
            int[] data = { 1, -1 };

            int result = Day01.SecondProblem(data);

            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void SecondProblemTestThree()
        {
            int[] data = { 3, 3, 4, -2, -4 };

            int result = Day01.SecondProblem(data);

            Assert.AreEqual(10, result);
        }

        [TestMethod()]
        public void SecondProblemTestFour()
        {
            int[] data = { -6, 3, 8, 5, -6 };

            int result = Day01.SecondProblem(data);

            Assert.AreEqual(5, result);
        }

        [TestMethod()]
        public void SecondProblemTestFive()
        {
            int[] data = { 7, 7, -2, -7, -4 };

            int result = Day01.SecondProblem(data);

            Assert.AreEqual(14, result);
        }
    }
}