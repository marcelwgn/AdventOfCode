using AdventOfCode.Year2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020.Tests.Solutions
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public void VerifyFirstProblem()
        {
            var data = new long[30];
            for (var i = 1; i < 26; i++)
            {
                data[i - 1] = i;
            }
            data[25] = 26;
            data[26] = 40;
            data[27] = 100;
            data[28] = 30;
            data[29] = 12;

            Assert.AreEqual(100, Day09.FirstProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblemOrdered()
        {
            var data = new long[30];
            for (var i = 1; i < 26; i++)
            {
                data[i - 1] = i;
            }
            data[25] = 26;
            data[26] = 40;
            data[27] = 94;
            data[28] = 30;
            data[29] = 12;

            Assert.AreEqual(47, Day09.SecondProblem(data));
        }

        [TestMethod]
        public void VerifySecondProblemUnOrdered()
        {
            var data = new long[30];
            for (var i = 1; i < 26; i++)
            {
                data[i - 1] = i;
            }
            data[21] = 25;
            data[22] = 24;
            data[23] = 23;
            data[24] = 22;
            data[25] = 26;
            data[26] = 40;
            data[27] = 94;
            data[28] = 30;
            data[29] = 12;

            Assert.AreEqual(47, Day09.SecondProblem(data));
        }
    }
}
