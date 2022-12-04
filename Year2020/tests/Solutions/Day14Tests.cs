using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day14Tests
    {

        [TestMethod]
        public void VerifyFirstProblem()
        {
            var data = new string[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11                                ",
                "mem[7] = 101                               ",
                "mem[8] = 0                                 "
            };

            Assert.AreEqual(165L, Day14.FirstProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblem()
        {
            var data = new string[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100                              ",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1                                "
            };

            Assert.AreEqual(208L, Day14.SecondProblem(data));
        }

    }
}
