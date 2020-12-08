using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day06Tests
    {

        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = {
                      "1, 1",
                      "1, 6",
                      "8, 3",
                      "3, 4",
                      "5, 5",
                      "8, 9"
                      };
            System.Tuple<AdventOfCode.Year2018.Model.Vector[], string[,]> converted = Day06.Convert(data);
            int value = Day06.FirstProblem(converted);

            Assert.AreEqual(17, value);

        }
        [TestMethod()]
        public void SecondProblemTest()
        {
            string[] data = {
                      "1, 1",
                      "1, 6",
                      "8, 3",
                      "3, 4",
                      "5, 5",
                      "8, 9"
                      };
            System.Tuple<AdventOfCode.Year2018.Model.Vector[], string[,]> converted = Day06.Convert(data);
            int value = Day06.SecondProblem(converted);

            Assert.AreEqual(160000, value);

        }
    }
}
