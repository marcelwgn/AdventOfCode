using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day19Tests
    {
        [TestMethod]
        [DataRow("5", 3)]
        [DataRow("7", 7)]
        [DataRow("8", 1)]
        [DataRow("9", 3)]
        [DataRow("11", 7)]
        public void FirstProblemTest(string data, int solution)
        {
            Assert.AreEqual(solution, Day19.FirstProblem([data]));
        }

        [TestMethod]
        [DataRow("5", 2)]
        [DataRow("6", 3)]
        [DataRow("7", 5)]
        [DataRow("8", 7)]
        [DataRow("9", 9)]
        [DataRow("10", 1)]
        [DataRow("11", 2)]
        [DataRow("12", 3)]
        [DataRow("13", 4)]
        public void SecondProblemTest(string data, int solution)
        {
            Assert.AreEqual(solution, Day19.SecondProblem([data]));
        }

    }
}
