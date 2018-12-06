using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day6Tests {

    [TestMethod()]
    public void firstProblemTest() {
      string[] data = {
                      "1, 1",
                      "1, 6",
                      "8, 3",
                      "3, 4",
                      "5, 5",
                      "8, 9"
                      };
      var converted = Day6.convert(data);
      int value = Day6.firstProblem(converted);

      Assert.AreEqual(17, value);

    }
    [TestMethod()]
    public void secondProblemTest() {
      string[] data = {
                      "1, 1",
                      "1, 6",
                      "8, 3",
                      "3, 4",
                      "5, 5",
                      "8, 9"
                      };
      var converted = Day6.convert(data);
      int value = Day6.secondProblem(converted);

      Assert.AreEqual(160000, value);

    }
  }
}
