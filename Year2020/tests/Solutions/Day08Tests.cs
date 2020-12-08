using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day08Tests
    {
        [DataTestMethod]
        [DataRow("nop +0", 0, 1)]
        [DataRow("acc +1", 1, 1)]
        [DataRow("jmp +4", 0, 4)]
        [DataRow("acc +3", 3, 1)]
        [DataRow("jmp -3", 0, -3)]
        [DataRow("acc -99", -99, 1)]
        [DataRow("acc +1", 1, 1)]
        [DataRow("jmp -4", 0, -4)]
        [DataRow("acc +6", 6, 1)]
        public void VerifyLineProcessing(string line, int expectedValue, int expectedNextpos)
        {
            int value = 0;
            int nextPos = 0;

            Day08.ProcessLine(line, ref value, ref nextPos);

            Assert.AreEqual(expectedValue, value);
            Assert.AreEqual(expectedNextpos, nextPos);
        }

        [TestMethod]
        public void VerifyFirstProblem()
        {
            var data = new string[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            Assert.AreEqual(5, Day08.FirstProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblem()
        {
            var data = new string[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            Assert.AreEqual(8, Day08.SecondProblem(data));
        }
    }
}
