using AdventOfCode2018.Model;
using AdventOfCode2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018Tests.SolutionsTests
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

            Assert.AreEqual(rects[0].x, 236);
            Assert.AreEqual(rects[0].y, 827);
            Assert.AreEqual(rects[0].width, 24);
            Assert.AreEqual(rects[0].height, 17);
            Assert.AreEqual(rects[0].rootData, data[0]);
        }

        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = {
                     "#1 @ 1,3: 4x4",
                     "#2 @ 3,1: 4x4",
                     "#3 @ 5,5: 2x2"};
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
                     "#3 @ 5,5: 2x2"};
            Rectangle[] converted = Day03.Convert(data);

            int result = Day03.SecondProblem(converted);

            Assert.AreEqual(3, result);
        }

    }
}