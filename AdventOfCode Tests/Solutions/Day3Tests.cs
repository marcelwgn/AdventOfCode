using AdventOfCode.Model;
using AdventOfCode.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day3Tests {
    [TestMethod()]
    public void convertTest() {
      //#1 @ 236,827: 24x17
      string[] data = { "#1 @ 236,827: 24x17" };

      Rectangle[] rects = Day3.convert(data);

      Assert.AreEqual(rects[0].x, 236);
      Assert.AreEqual(rects[0].y, 827);
      Assert.AreEqual(rects[0].width, 24);
      Assert.AreEqual(rects[0].height, 17);
      Assert.AreEqual(rects[0].rootData, data[0]);
    }

    [TestMethod()]
    public void firstProblemTest() {
      string[] data = {
                     "#1 @ 1,3: 4x4",
                     "#2 @ 3,1: 4x4",
                     "#3 @ 5,5: 2x2"};
      Rectangle[] converted = Day3.convert(data);

      int result = Day3.firstProblem(converted);

      Assert.AreEqual(4, result);
    }

    [TestMethod()]
    public void secondProblemTest() {
      string[] data = {
                     "#1 @ 1,3: 4x4",
                     "#2 @ 3,1: 4x4",
                     "#3 @ 5,5: 2x2"};
      Rectangle[] converted = Day3.convert(data);

      int result = Day3.secondProblem(converted);

      Assert.AreEqual(3, result);
    }

  }
}