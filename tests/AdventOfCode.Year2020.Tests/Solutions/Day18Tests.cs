using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day18Tests
    {

        [TestMethod]
        [DataRow("1 + 2 * 3 + 4 * 5 + 6", "71")]
        [DataRow("2 * 3 + (4 * 5)", "26")]
        [DataRow("1 + (2 * 3) + (4 * 11)", "51")]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", "12240")]
        public void VerifyTransformNormal(string data, string expected)
        {
            Assert.AreEqual(expected, Day18.ProcessString(data, false));
        }

        [TestMethod]
        [DataRow("1 + 2 * 3 + 4 * 5 + 6", "231")]
        [DataRow("2 * 3 + (4 * 5)", "46")]
        [DataRow("1 + (2 * 3) + (4 * 11)", "51")]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", "669060")]
        public void VerifyTransformPlusHasPrecedence(string data, string expected)
        {
            Assert.AreEqual(expected, Day18.ProcessString(data, true));
        }

        [TestMethod]
        public void VerifyFirstProblem()
        {
            var data = new string[]
            {
                "1 + 2 * 3 + 4 * 5 + 6",
                "2 * 3 + (4 * 5)",
                "1 + (2 * 3) + (4 * 11)",
                "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",
            };

            Assert.AreEqual(12388L, Day18.CalculateSolution(data, false));
        }

        [TestMethod]
        public void VerifySecondProblem()
        {
            var data = new string[]
            {
                "1 + 2 * 3 + 4 * 5 + 6",
                "2 * 3 + (4 * 5)",
                "1 + (2 * 3) + (4 * 11)",
                "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",
            };

            Assert.AreEqual(669388L, Day18.CalculateSolution(data, true));
        }
    }
}
