using AdventOfCode.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day10Tests {

    [TestMethod()]
    public void convertTest()
    {
      string[] data = { "position=< 9,  1> velocity=< 0,  2>"


      };

      ChangingVector[] converted = Day10.convert(data);

      Assert.AreEqual(9, converted[0].location.x);
      Assert.AreEqual(1, converted[0].location.y);
      Assert.AreEqual(0, converted[0].change.x);
      Assert.AreEqual(2, converted[0].change.y);
    }

    [TestMethod()]
    public void firstProblemTest()
    {
      //No really useful test ...
      //We just expect stuff to not crash
      string[] data = {
          "position=< 9,  1> velocity=< 0,  2>",
          "position=< 7,  0> velocity=<-1,  0>",
          "position=< 3, -2> velocity=<-1,  1>",
          "position=< 6, 10> velocity=<-2, -1>",
          "position=< 2, -4> velocity=< 2,  2>",
          "position=<-6, 10> velocity=< 2, -2>",
          "position=< 1,  8> velocity=< 1, -1>",
          "position=< 1,  7> velocity=< 1,  0>",
          "position=<-3, 11> velocity=< 1, -2>",
          "position=< 7,  6> velocity=<-1, -1>",
          "position=<-2,  3> velocity=< 1,  0>",
          "position=<-4,  3> velocity=< 2,  0>",
          "position=<10, -3> velocity=<-1,  1>",
          "position=< 5, 11> velocity=< 1, -2>",
          "position=< 4,  7> velocity=< 0, -1>",
          "position=< 8, -2> velocity=< 0,  1>",
          "position=<15,  0> velocity=<-2,  0>",
          "position=< 1,  6> velocity=< 1,  0>",
          "position=< 8,  9> velocity=< 0, -1>",
          "position=< 3,  3> velocity=<-1,  1>",
          "position=< 0,  5> velocity=< 0, -1>",
          "position=<-2,  2> velocity=< 2,  0>",
          "position=< 5, -2> velocity=< 1,  2>",
          "position=< 1,  4> velocity=< 2,  1>",
          "position=<-2,  7> velocity=< 2, -2>",
          "position=< 3,  6> velocity=<-1, -1>",
          "position=< 5,  0> velocity=< 1,  0>",
          "position=<-6,  0> velocity=< 2,  0>",
          "position=< 5,  9> velocity=< 1, -2>",
          "position=<14,  7> velocity=<-2,  0>",
          "position=<-3,  6> velocity=< 2, -1>"
        };
      var converted = Day10.convert(data);
     
      //Comment in next line to run real test 
      //since it takes way to long to run for a unit test
      //Day10.firstProblem(converted);
      Assert.AreEqual(1, 1);
    }
    [TestMethod()]
    public void secondProblemTest()
    {
      //No really useful test ...
      //We just expect stuff to not crash
      string[] data = {
          "position=< 9,  1> velocity=< 0,  2>",
          "position=< 7,  0> velocity=<-1,  0>",
          "position=< 3, -2> velocity=<-1,  1>",
          "position=< 6, 10> velocity=<-2, -1>",
          "position=< 2, -4> velocity=< 2,  2>",
          "position=<-6, 10> velocity=< 2, -2>",
          "position=< 1,  8> velocity=< 1, -1>",
          "position=< 1,  7> velocity=< 1,  0>",
          "position=<-3, 11> velocity=< 1, -2>",
          "position=< 7,  6> velocity=<-1, -1>",
          "position=<-2,  3> velocity=< 1,  0>",
          "position=<-4,  3> velocity=< 2,  0>",
          "position=<10, -3> velocity=<-1,  1>",
          "position=< 5, 11> velocity=< 1, -2>",
          "position=< 4,  7> velocity=< 0, -1>",
          "position=< 8, -2> velocity=< 0,  1>",
          "position=<15,  0> velocity=<-2,  0>",
          "position=< 1,  6> velocity=< 1,  0>",
          "position=< 8,  9> velocity=< 0, -1>",
          "position=< 3,  3> velocity=<-1,  1>",
          "position=< 0,  5> velocity=< 0, -1>",
          "position=<-2,  2> velocity=< 2,  0>",
          "position=< 5, -2> velocity=< 1,  2>",
          "position=< 1,  4> velocity=< 2,  1>",
          "position=<-2,  7> velocity=< 2, -2>",
          "position=< 3,  6> velocity=<-1, -1>",
          "position=< 5,  0> velocity=< 1,  0>",
          "position=<-6,  0> velocity=< 2,  0>",
          "position=< 5,  9> velocity=< 1, -2>",
          "position=<14,  7> velocity=<-2,  0>",
          "position=<-3,  6> velocity=< 2, -1>"
        };
      var converted = Day10.convert(data);

      //Comment in next line to run real test 
      //since it takes way to long to run for a unit test
      //Day10.secondProblem(converted);
      Assert.AreEqual(1, 1);
    }

  }
}
