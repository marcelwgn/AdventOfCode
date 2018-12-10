using AdventOfCode.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day10Tests {

    [TestMethod()]
    public void converTest()
    {
      string[] data = { "position=< 9,  1> velocity=< 0,  2>" 


      };

      ChangingVector[] converted = Day10.convert(data);

      Assert.AreEqual(9, converted[0].location.x);
      Assert.AreEqual(1, converted[0].location.y);
      Assert.AreEqual(0, converted[0].change.x);
      Assert.AreEqual(2, converted[0].change.y);
    }


  }
}
