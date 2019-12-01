using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018.Solutions;
using System;

namespace AdventOfCode2018Tests.SolutionsTests
{
    [TestClass()]
    public class Day09Tests
    {

        [TestMethod()]
        public void ConverTest()
        {
            string[] data = { "10 players; last marble is worth 1618 points" };

            Tuple<long[], int> converted = Day09.Convert(data);

            Assert.AreEqual(10, converted.Item1.Length);
            Assert.AreEqual(1618, converted.Item2);
        }

        [TestMethod()]
        public void FirstProblem_9P_32Max()
        {
            string[] data = { "9 players; last marble is worth 25 points" };
            Tuple<long[], int> converted = Day09.Convert(data);

            long result = Day09.FirstProblem(converted);


            Assert.AreEqual(32, result);
        }

        [TestMethod()]
        public void FirstProblem_10P_1618Max()
        {
            string[] data = { "10 players; last marble is worth 1618 points" };
            Tuple<long[], int> converted = Day09.Convert(data);

            long result = Day09.FirstProblem(converted);


            Assert.AreEqual(8317, result);
        }

        [TestMethod()]
        public void FirstProblem_13P_7999Max()
        {
            string[] data = { "13 players; last marble is worth 7999 points" };
            Tuple<long[], int> converted = Day09.Convert(data);

            long result = Day09.FirstProblem(converted);


            Assert.AreEqual(146373, result);
        }

        [TestMethod()]
        public void FirstProblem_17P_1104Max()
        {
            string[] data = { "17 players; last marble is worth 1104 points" };
            Tuple<long[], int> converted = Day09.Convert(data);

            long result = Day09.FirstProblem(converted);


            Assert.AreEqual(2764, result);
        }

        [TestMethod()]
        public void FirstProblem_21P_6111Max()
        {
            string[] data = { "21 players; last marble is worth 6111 points" };
            Tuple<long[], int> converted = Day09.Convert(data);

            long result = Day09.FirstProblem(converted);


            Assert.AreEqual(54718, result);
        }

        [TestMethod()]
        public void FirstProblem_30P_5807Max()
        {
            string[] data = { "30 players; last marble is worth 5807 points" };
            Tuple<long[], int> converted = Day09.Convert(data);

            long result = Day09.FirstProblem(converted);

            Assert.AreEqual(37305, result);
        }

    }
}
