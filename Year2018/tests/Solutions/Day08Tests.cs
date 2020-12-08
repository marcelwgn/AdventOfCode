using AdventOfCode.Year2018.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AdventOfCode.Year2018.Solutions;
using System.Collections.Generic;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day08Tests
    {

        [TestMethod()]
        public void FindMetaStartTestNoChild()
        {
            int[] data = { 0, 3, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void FindMetaStartTestSingleChild()
        {
            int[] data = { 1, 3, 0, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(5, result);
        }
        [TestMethod()]
        public void FindMetaStartTestTowAdjacentChildren()
        {
            int[] data = { 2, 3, 0, 1, 1, 0, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void FindMetaStartTestSingleSingleChildren()
        {
            int[] data = { 1, 3, 1, 1, 0, 1, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void FindMetaStartTestTowAdjacentChildrenOneIsDeep()
        {
            int[] data = { 2, 3, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 2, 3 };
            int result = Day08.FindMetaData(data, 0);
            Assert.AreEqual(11, result);
        }

        [TestMethod()]
        public void GetNodeTestNoChildren()
        {
            int[] data = { 0, 3, 1, 2, 3 };

            Node<List<int>> result = Day08.GetNode(data, 0);
            result.Data.Sort();

            int[] metaExpected = { 1, 2, 3 };

            int[] metaFromCalculation = result.Data.ToArray();

            Assert.AreEqual(0, result.Children.Count);

            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }
        }

        [TestMethod()]
        public void GetNodeTestSingleChild()
        {
            int[] data = { 1, 3, 0, 1, 1, 1, 2, 3 };

            Node<List<int>> result = Day08.GetNode(data, 0);
            result.Data.Sort();

            int[] metaExpected = { 1, 2, 3 };

            int[] metaFromCalculation = result.Data.ToArray();

            Assert.AreEqual(1, result.Children.Count);

            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }

            Assert.AreEqual(1, result.Children[0].Data[0]);
        }

        [TestMethod()]
        public void GetNodeTestTwoChildren()
        {
            int[] data = { 2, 3, 0, 1, 8, 0, 1, 9, 1, 2, 3 };

            Node<List<int>> result = Day08.GetNode(data, 0);
            result.Data.Sort();

            int[] metaExpected = { 1, 2, 3 };
            int[] metaFromCalculation = result.Data.ToArray();
            Assert.AreEqual(2, result.Children.Count);
            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }
            Assert.AreEqual(8, result.Children[0].Data[0]);
            Assert.AreEqual(9, result.Children[1].Data[0]);
        }

        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = { "2 3 0 1 8 0 1 9 1 2 3" };

            Node<List<int>> result = Day08.Convert(data);
            result.Data.Sort();

            int[] metaExpected = { 1, 2, 3 };
            int[] metaFromCalculation = result.Data.ToArray();
            Assert.AreEqual(2, result.Children.Count);
            for (int i = 0; i < Math.Max(metaExpected.Length, metaFromCalculation.Length); i++)
            {
                Assert.AreEqual(metaExpected[i], metaFromCalculation[i]);
            }
            Assert.AreEqual(8, result.Children[0].Data[0]);
            Assert.AreEqual(9, result.Children[1].Data[0]);
        }

        [TestMethod()]
        public void FirstProblemTestSingleNode()
        {
            int[] data = { 0, 3, 1, 2, 3 };
            Node<List<int>> converted = Day08.GetNode(data, 0);

            int result = Day08.FirstProblem(converted);

            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void FirstProblemTestSingleChild()
        {
            int[] data = { 1, 3, 0, 1, 9, 1, 2, 3 };
            Node<List<int>> converted = Day08.GetNode(data, 0);

            int result = Day08.FirstProblem(converted);

            Assert.AreEqual(15, result);
        }
        [TestMethod()]
        public void FirstProblemTestTwoChildren()
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
