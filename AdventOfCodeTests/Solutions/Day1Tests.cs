using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day1Tests {
    [TestMethod()]
    public void convertTest() {
      string[] data = { "1", "-2", "3" };

      int[] dataConverted = Day1.convert(data);

      Assert.AreEqual(1, dataConverted[0]);
      Assert.AreEqual(-2, dataConverted[1]);
      Assert.AreEqual(3, dataConverted[2]);

    }
    [TestMethod()]
    public void firstProblemTest_AllPositive() {
      int[] data = { 1, 1, 1 };

      int result = Day1.firstProblem(data);

      Assert.AreEqual(3, result);

    }
    [TestMethod()]
    public void firstProblemTest_PositiveAndNegative() {
      int[] data = { 1, 1, -2 };

      int result = Day1.firstProblem(data);

      Assert.AreEqual(0, result);

    }
    [TestMethod()]
    public void firstProblemTest_AllNegative() {
      int[] data = { -1, -2, -3 };

      int result = Day1.firstProblem(data);

      Assert.AreEqual(-6, result);

    }

    [TestMethod()]
    public void secondProblemTest_First() {
      int[] data = { 1, -2, 3, 1 };

      int result = Day1.secondProblem(data);


      Assert.AreEqual(2, result);
    }
    [TestMethod()]
    public void secondProblemTest_PlusAndMinusOne() {
      int[] data = { 1, -1 };

      int result = Day1.secondProblem(data);


      Assert.AreEqual(0, result);
    }
    [TestMethod()]
    public void secondProblemTest_Third() {
      int[] data = { 3, 3, 4, -2, -4 };

      int result = Day1.secondProblem(data);


      Assert.AreEqual(10, result);
    }
    [TestMethod()]
    public void secondProblemTest_Fourth() {
      int[] data = { -6, 3, 8, 5, -6 };

      int result = Day1.secondProblem(data);


      Assert.AreEqual(5, result);
    }
    [TestMethod()]
    public void secondProblemTest_Fifth() {
      int[] data = { 7, 7, -2, -7, -4 };

      int result = Day1.secondProblem(data);


      Assert.AreEqual(14, result);
    }
  }
}