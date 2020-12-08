using AdventOfCode.Year2018.Model;
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

            Rectangle[] rects = Day03.Convert(data);

            Assert.AreEqual(rects[0].X, 236);
            Assert.AreEqual(rects[0].Y, 827);
            Assert.AreEqual(rects[0].Width, 24);
            Assert.AreEqual(rects[0].Height, 17);
            Assert.AreEqual(rects[0].RootData, data[0]);
        }

        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
            Rectangle[] converted = Day03.Convert(data);

            int result = Day03.FirstProblem(converted);

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
            Rectangle[] converted = Day03.Convert(data);

            int result = Day03.SecondProblem(converted);

            Assert.AreEqual(3, result);
        }
    }
}