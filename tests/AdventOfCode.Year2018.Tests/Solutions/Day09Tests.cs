using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day09Tests
    {

        [TestMethod()]
        public void ConverTest()
        {
            string[] data = ["10 players; last marble is worth 1618 points"];

            var converted = Day09.Convert(data);

            Assert.AreEqual(10, converted.Item1.Length);
            Assert.AreEqual(1618, converted.Item2);
        }

        [TestMethod()]
        public void FirstProblem9P32Max()
        {
            string[] data = ["9 players; last marble is worth 25 points"];
            var converted = Day09.Convert(data);

            var result = Day09.FirstProblem(converted);

            Assert.AreEqual(32, result);
        }

        [TestMethod()]
        public void FirstProblem10P1618Max()
        {
            string[] data = ["10 players; last marble is worth 1618 points"];
            var converted = Day09.Convert(data);

            var result = Day09.FirstProblem(converted);

            Assert.AreEqual(8317, result);
        }

        [TestMethod()]
        public void FirstProblem13P7999Max()
        {
            string[] data = ["13 players; last marble is worth 7999 points"];
            var converted = Day09.Convert(data);

            var result = Day09.FirstProblem(converted);

            Assert.AreEqual(146373, result);
        }

        [TestMethod()]
        public void FirstProblem17P1104Max()
        {
            string[] data = ["17 players; last marble is worth 1104 points"];
            var converted = Day09.Convert(data);

            var result = Day09.FirstProblem(converted);

            Assert.AreEqual(2764, result);
        }

        [TestMethod()]
        public void FirstProblem21P6111Max()
        {
            string[] data = ["21 players; last marble is worth 6111 points"];
            var converted = Day09.Convert(data);

            var result = Day09.FirstProblem(converted);

            Assert.AreEqual(54718, result);
        }

        [TestMethod()]
        public void FirstProblem30P5807Max()
        {
            string[] data = ["30 players; last marble is worth 5807 points"];
            var converted = Day09.Convert(data);

            var result = Day09.FirstProblem(converted);

            Assert.AreEqual(37305, result);
        }
    }
}
