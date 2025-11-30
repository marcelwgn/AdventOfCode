using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day03Tests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            //#1 @ 236,827: 24x17
            string[] data = { "#1 @ 236,827: 24x17" };

            var rects = Day03.Convert(data);

            Assert.AreEqual(236, rects[0].X);
            Assert.AreEqual(827, rects[0].Y);
            Assert.AreEqual(24, rects[0].Width);
            Assert.AreEqual(17, rects[0].Height);
            Assert.AreEqual(data[0], rects[0].RootData);
        }

        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
            var converted = Day03.Convert(data);

            var result = Day03.FirstProblem(converted);

            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void SecondProblemTest()
        {
            string[] data = {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
            var converted = Day03.Convert(data);

            var result = Day03.SecondProblem(converted);

            Assert.AreEqual(3, result);
        }
    }
}