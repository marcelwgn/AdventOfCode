using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day07Tests {

    [TestMethod()]
    public void convertTest()
    {
      string[] data = {
                        "Step C must be finished before step A can begin.",
                        "Step C must be finished before step F can begin.",
                        "Step A must be finished before step B can begin.",
                        "Step A must be finished before step D can begin.",
                        "Step B must be finished before step E can begin.",
                        "Step D must be finished before step E can begin.",
                        "Step F must be finished before step E can begin."
                        };

      var converted = Day07.convert(data);
      converted.sort();
      Assert.AreEqual(6, converted.Count);

      for (int i = 0; i < 6; i++)
      {
        Assert.AreEqual(65 + i, converted[i].name[0]);

      }
    }


    [TestMethod()]
    public void firstProblemTest()
    {
      string[] data = {
                        "Step C must be finished before step A can begin.",
                        "Step C must be finished before step F can begin.",
                        "Step A must be finished before step B can begin.",
                        "Step A must be finished before step D can begin.",
                        "Step B must be finished before step E can begin.",
                        "Step D must be finished before step E can begin.",
                        "Step F must be finished before step E can begin."
                        };
      var converted = Day07.convert(data);
      string value = Day07.firstProblem(converted);

      Assert.AreEqual("CABDFE", value);

    }
    [TestMethod()]
    public void secondProblemTest()
    {
      string[] data = {
                        "Step C must be finished before step A can begin.",
                        "Step C must be finished before step F can begin.",
                        "Step A must be finished before step B can begin.",
                        "Step A must be finished before step D can begin.",
                        "Step B must be finished before step E can begin.",
                        "Step D must be finished before step E can begin.",
                        "Step F must be finished before step E can begin."
                        };
      var converted = Day07.convert(data);
      int value = Day07.secondProblem(converted);

      Assert.AreEqual(253, value);

    }
  }
}
