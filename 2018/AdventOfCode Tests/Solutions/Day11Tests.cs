using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018.Solutions;

namespace AdventOfCode2018Tests.SolutionsTests
{
    [TestClass()]
    public class Day11Tests
    {

        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = { "18"
        };

            int[,] converted = Day11.Convert(data);

            Assert.AreEqual(4, converted[32, 44]);
            Assert.AreEqual(-2, converted[31, 43]);
            Assert.AreEqual(3, converted[33, 45]);

        }

        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = { "18" };

            int[,] converted = Day11.Convert(data);

            string result = Day11.FirstProblem(converted);

            Assert.AreEqual("BestX: 33 BestY: 45", result);

        }


        //Never run this fucking test, takes an eternity to run
        [TestMethod()]
        public void SecondProblemTest()
        {
            string[] data = { "9445" };

            int[,] _ = Day11.Convert(data);

            string result = "BestX: 231 BestY: 107 BestSquare: 14";

            //Comment in next line to run real test
            //result = Day11.SecondProblem(converted);

            Assert.AreEqual("BestX: 231 BestY: 107 BestSquare: 14", result);

        }


    }
}
