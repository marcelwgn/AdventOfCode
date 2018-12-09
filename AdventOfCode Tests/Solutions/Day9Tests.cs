using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day9Tests {

    [TestMethod()]
    public void converTest()
    {
      string[] data = { "10 players; last marble is worth 1618 points" };

      Tuple<long[], int> converted = Day9.convert(data);

      Assert.AreEqual(10, converted.Item1.Length);
      Assert.AreEqual(1618, converted.Item2);
    }

    [TestMethod()]
    public void firstProblem_9P_32Max()
    {
      string[] data = { "9 players; last marble is worth 25 points" };
      Tuple<long[], int> converted = Day9.convert(data);

      long result = Day9.firstProblem(converted);


      Assert.AreEqual(32, result);
    }

    [TestMethod()]
    public void firstProblem_10P_1618Max()
    {
      string[] data = { "10 players; last marble is worth 1618 points" };
      Tuple<long[], int> converted = Day9.convert(data);

      long result = Day9.firstProblem(converted);


      Assert.AreEqual(8317, result);
    }

    [TestMethod()]
    public void firstProblem_13P_7999Max()
    {
      string[] data = { "13 players; last marble is worth 7999 points" };
      Tuple<long[], int> converted = Day9.convert(data);

      long result = Day9.firstProblem(converted);


      Assert.AreEqual(146373, result);
    }

    [TestMethod()]
    public void firstProblem_17P_1104Max()
    {
      string[] data = { "17 players; last marble is worth 1104 points" };
      Tuple<long[], int> converted = Day9.convert(data);

      long result = Day9.firstProblem(converted);


      Assert.AreEqual(2764, result);
    }

    [TestMethod()]
    public void firstProblem_21P_6111Max()
    {
      string[] data = { "21 players; last marble is worth 6111 points" };
      Tuple<long[], int> converted = Day9.convert(data);

      long result = Day9.firstProblem(converted);


      Assert.AreEqual(54718, result);
    }

    [TestMethod()]
    public void firstProblem_30P_5807Max()
    {
      string[] data = { "30 players; last marble is worth 5807 points" };
      Tuple<long[], int> converted = Day9.convert(data);

      long result = Day9.firstProblem(converted);


      Assert.AreEqual(37305, result);
    }

  }
}
