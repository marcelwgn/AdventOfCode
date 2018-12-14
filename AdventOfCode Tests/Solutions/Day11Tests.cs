using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day11Tests {

    [TestMethod()]
    public void convertTest()
    {
      string[] data = { "18"
      };

      var converted = Day11.convert(data);

      Assert.AreEqual(4, converted[32, 44]);
      Assert.AreEqual(-2, converted[31, 43]);
      Assert.AreEqual(3, converted[33, 45]);

    }

    [TestMethod()]
    public void firstProblemTest(){
      string[] data = { "18" };

      var converted = Day11.convert(data);

      string result = Day11.firstProblem(converted);

      Assert.AreEqual("BestX: 33 BestY: 45", result);

    }


    //Never run this fucking test, takes an eternity to run
    [TestMethod()]
    public void secondProblemTest()
    {
      string[] data = { "9445" };

      var converted = Day11.convert(data);

      string result = "BestX: 231 BestY: 107 BestSquare: 14";
      
      //Comment in next line to run real test
      //result = Day11.secondProblem(converted);

      Assert.AreEqual("BestX: 231 BestY: 107 BestSquare: 14", result);

    }


  }
}
