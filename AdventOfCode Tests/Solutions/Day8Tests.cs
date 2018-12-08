using AdventOfCode.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day8Tests {

    [TestMethod()]
    public void findMetaStartTest_NoChild()
    {
      int[] data = { 0, 3, 1, 2, 3 };
      int result = Day8.findMetaData(data, 0);
      Assert.AreEqual(2, result);
    }

    [TestMethod()]
    public void findMetaStartTest_SingleChild()
    {
      int[] data = { 1, 3, 0, 1, 1, 1, 2, 3 };
      int result = Day8.findMetaData(data, 0);
      Assert.AreEqual(5, result);
    }
    [TestMethod()]
    public void findMetaStartTest_TowAdjacentChildren()
    {
      int[] data = { 2, 3, 0, 1, 1, 0, 1, 1, 1, 2, 3 };
      int result = Day8.findMetaData(data, 0);
      Assert.AreEqual(8, result);
    }

    [TestMethod()]
    public void findMetaStartTest_SingleSingleChildren()
    {
      int[] data = { 1, 3, 1, 1, 0, 1, 1, 1, 1, 2, 3 };
      int result = Day8.findMetaData(data, 0);
      Assert.AreEqual(8, result);

    }
    [TestMethod()]
    public void findMetaStartTest_TowAdjacentChildren_OneIsDeep()
    {
      int[] data = { 2, 3, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 2, 3 };
      int result = Day8.findMetaData(data, 0);
      Assert.AreEqual(11, result);
    }




    [TestMethod()]
    public void getNodeTest_NoChildren()
    {
      int[] data = { 0, 3, 1, 2, 3 };

      Node<List<int>> result = Day8.getNode(data, 0);
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
    public void getNodeTest_SingleChild()
    {
      int[] data = { 1, 3, 0, 1, 1, 1, 2, 3 };

      Node<List<int>> result = Day8.getNode(data, 0);
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
    public void getNodeTest_TwoChildren()
    {
      int[] data = { 2, 3, 0, 1, 8, 0, 1, 9, 1, 2, 3 };


      Node<List<int>> result = Day8.getNode(data, 0);
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
    public void convertTest()
    {
      String[] data = { "2 3 0 1 8 0 1 9 1 2 3" };

      Node<List<int>> result = Day8.convert(data);
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
    public void firstProblemTest_SingleNode()
    {
      int[] data = { 0, 3, 1, 2, 3 };
      Node<List<int>> converted = Day8.getNode(data, 0);

      int result = Day8.firstProblem(converted);

      Assert.AreEqual(6, result);
    }
    [TestMethod()]
    public void firstProblemTest_SingleChild()
    {
      int[] data = { 1, 3, 0, 1, 9, 1, 2, 3 };
      Node<List<int>> converted = Day8.getNode(data, 0);

      int result = Day8.firstProblem(converted);

      Assert.AreEqual(15, result);
    }
    [TestMethod()]
    public void firstProblemTest_TwoChildren()
    {
      int[] data = { 2, 3, 0, 1, 9, 0, 1, 9, 1, 2, 3 };
      Node<List<int>> converted = Day8.getNode(data, 0);

      int result = Day8.firstProblem(converted);

      Assert.AreEqual(24, result);
    }

    [TestMethod()]
    public void secondProblemTest(){
      String[] data = { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2" };
      var converted = Day8.convert(data);

      int result = Day8.secondProblem(converted);

      Assert.AreEqual(66,result);
    }
  }
}
