using AdventOfCode.Year2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2016.Tests.Solutions
{
    [TestClass]
    public class Day04Tests
    {

        [TestMethod]
        public void ConvertTests()
        {
            var expected = ("aaaaa-bbb-z-y-x", 123, "abxyz");
            var actual = Day04.Convert(new string[] { "aaaaa-bbb-z-y-x-123[abxyz]" })[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FirstProblemTest()
        {
            var data = new (string, int, string)[]
            {
                ("aaaaa-bbb-z-y-x",123,"abxyz"),
                ("a-b-c-d-e-f-g-h",987,"abcde"),
                ("not-a-real-room",404,"oarel"),
                ("totally-real-room",200,"decoy")
            };
            Assert.AreEqual(1514, Day04.FirstProblem(data));
        }

        [TestMethod]
        public void SecondProblemTest()
        {
            var data = new (string,int, string)[]
            {
                ("ihex-hucxvm-lmhktzx-",267, ""),
                ("aaa-zixadsamtkozy-i22vhz-",213, "")
            };
            Assert.AreEqual(267, Day04.SecondProblem(data));
        }
    }
}
