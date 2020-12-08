using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day02Tests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = { "Test", "test", "TeSt" };
            string[] dataConverted = Day02.Convert(data);

            Assert.AreSame(data, dataConverted);
        }

        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = {
                "abcdef",
                "bababc ",
                "abbcde ",
                "abcccd ",
                "aabcdd ",
                "abcdee ",
                "ababab "
            };
            int checksum = Day02.FirstProblem(data);

            Assert.AreEqual(12, checksum);
        }

        [TestMethod()]
        public void SecondProblemTest()
        {
            string[] data = {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };

            string result = Day02.SecondProblem(data);

            Assert.AreEqual("fgij", result);
        }
    }
}