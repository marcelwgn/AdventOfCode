using AdventOfCode2018.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AdventOfCode2018.Solutions;
using System.Collections.Generic;

namespace AdventOfCode2018Tests.SolutionsTests
{
    [TestClass()]
    public class Day08Tests
    {

        [TestMethod()]
        public void FindMetaStartTest_NoChild()
        {
            int[] data = { 0, 3, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void FindMetaStartTest_SingleChild()
        {
            int[] data = { 1, 3, 0, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(5, result);
        }
        [TestMethod()]
        public void FindMetaStartTest_TowAdjacentChildren()
        {
            int[] data = { 2, 3, 0, 1, 1, 0, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void FindMetaStartTest_SingleSingleChildren()
        {
            int[] data = { 1, 3, 1, 1, 0, 1, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(8, result);

        }
        [TestMethod()]
        public void FindMetaStartTest_TowAdjacentChildren_OneIsDeep()
        {
            int[] data = { 2, 3, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(11, result);
        }




        [TestMethod()]
        public void GetNodeTest_NoChildren()
        {
            int[] data = { 0, 3, 1, 2, 3 };

            Node<List<int>> result = Day08.GetNode(data, 0);
            result.data.Sort();

            int[] metaExpected = { 1, 2, 3 };

            int[] metaFromCalculation = result.data.ToArray();

            Assert.AreEqual(0, result.children.Count);

            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }

        }
        [TestMethod()]
        public void GetNodeTest_SingleChild()
        {
            int[] data = { 1, 3, 0, 1, 1, 1, 2, 3 };

            Node<List<int>> result = Day08.GetNode(data, 0);
            result.data.Sort();

            int[] metaExpected = { 1, 2, 3 };


            int[] metaFromCalculation = result.data.ToArray();

            Assert.AreEqual(1, result.children.Count);

            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }

            Assert.AreEqual(1, result.children[0].data[0]);

        }
        [TestMethod()]
        public void GetNodeTest_TwoChildren()
        {
            int[] data = { 2, 3, 0, 1, 8, 0, 1, 9, 1, 2, 3 };


            Node<List<int>> result = Day08.GetNode(data, 0);
            result.data.Sort();

            int[] metaExpected = { 1, 2, 3 };


            int[] metaFromCalculation = result.data.ToArray();

            Assert.AreEqual(2, result.children.Count);

            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }
            Assert.AreEqual(8, result.children[0].data[0]);
            Assert.AreEqual(9, result.children[1].data[0]);

        }

        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = { "2 3 0 1 8 0 1 9 1 2 3" };

            Node<List<int>> result = Day08.Convert(data);
            result.data.Sort();

            int[] metaExpected = { 1, 2, 3 };


            int[] metaFromCalculation = result.data.ToArray();

            Assert.AreEqual(2, result.children.Count);

            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }
            Assert.AreEqual(8, result.children[0].data[0]);
            Assert.AreEqual(9, result.children[1].data[0]);

        }


        [TestMethod()]
        public void FirstProblemTest_SingleNode()
        {
            int[] data = { 0, 3, 1, 2, 3 };
            Node<List<int>> converted = Day08.GetNode(data, 0);

            int result = Day08.FirstProblem(converted);

            Assert.AreEqual(6, result);
        }
        [TestMethod()]
        public void FirstProblemTest_SingleChild()
        {
            int[] data = { 1, 3, 0, 1, 9, 1, 2, 3 };
            Node<List<int>> converted = Day08.GetNode(data, 0);

            int result = Day08.FirstProblem(converted);

            Assert.AreEqual(15, result);
        }
        [TestMethod()]
        public void FirstProblemTest_TwoChildren()
        {
            int[] data = { 2, 3, 0, 1, 9, 0, 1, 9, 1, 2, 3 };
            Node<List<int>> converted = Day08.GetNode(data, 0);

            int result = Day08.FirstProblem(converted);

            Assert.AreEqual(24, result);
        }

        [TestMethod()]
        public void SecondProblemTest()
        {
            string[] data = { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2" };
            Node<List<int>> converted = Day08.Convert(data);

            int result = Day08.SecondProblem(converted);

            Assert.AreEqual(66, result);
        }
    }
}
