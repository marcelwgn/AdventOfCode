using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day14Tests {

    [TestMethod()]
    public void convertTest()
    {
      string[] data = { "37", "8" };

      var converted = Day14.convert(data);

      //Killing demetes law with one line at a time
      Assert.AreEqual(3, converted.Item1.first.Value);
      Assert.AreEqual(7, converted.Item1.first.Next.Value);

      Assert.AreEqual(8, converted.Item2);
    }

    [TestMethod()]
    public void firstProblemTest_9Recipes()
    {
      string[] data = { "37", "9" };

      var converted = Day14.convert(data);

      string result = Day14.firstProblem(converted);

      Assert.AreEqual("5158916779", result);
    }

    [TestMethod()]
    public void firstProblemTest_5Recipes()
    {
      string[] data = { "37", "5" };

      var converted = Day14.convert(data);

      string result = Day14.firstProblem(converted);

      Assert.AreEqual("0124515891", result);
    }

    [TestMethod()]
    public void firstProblemTest_18Recipes()
    {
      string[] data = { "37", "18" };

      var converted = Day14.convert(data);

      string result = Day14.firstProblem(converted);

      Assert.AreEqual("9251071085", result);
    }

    [TestMethod()]
    public void firstProblemTest_2018Recipes()
    {
      string[] data = { "37", "2018" };

      var converted = Day14.convert(data);

      string result = Day14.firstProblem(converted);

      Assert.AreEqual("5941429882", result);
    }


  }
}
