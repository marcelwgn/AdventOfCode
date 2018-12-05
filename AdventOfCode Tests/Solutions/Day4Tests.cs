using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day4Tests {
    [TestMethod()]
    public void convertTest() {
      string[] data = {"[1518-11-01 00:00] Guard #10 begins shift",
                        "[1518-11-01 00:05] falls asleep",
                        "[1518-11-01 00:25] wakes up",
                        "[1518-11-01 00:30] falls asleep",
                        "[1518-11-01 00:55] wakes up",
                        "[1518-11-01 23:58] Guard #99 begins shift",
                        "[1518-11-02 00:40] falls asleep",
                        "[1518-11-02 00:50] wakes up",
                        "[1518-11-03 00:05] Guard #10 begins shift",
                        "[1518-11-03 00:24] falls asleep",
                        "[1518-11-03 00:29] wakes up",
                        "[1518-11-04 00:02] Guard #99 begins shift",
                        "[1518-11-04 00:36] falls asleep",
                        "[1518-11-04 00:46] wakes up",
                        "[1518-11-05 00:03] Guard #99 begins shift",
                        "[1518-11-05 00:45] falls asleep",
                        "[1518-11-05 00:55] wakes up" };

      List<Guard> converted = Day4.convert(data);

      Assert.AreEqual(2, converted.Count);
      Guard first = converted[0];
      Guard second = converted[1];

      Assert.AreEqual(10, first.id);
      Assert.AreEqual(50, first.minutesSlept);

      Assert.AreEqual(99, second.id);
      Assert.AreEqual(30, second.minutesSlept);

    }

    [TestMethod()]
    public void firstProblemTest() {
      List<Guard> data = new List<Guard>();
      Guard first = new Guard(10) {
        minutesSlept = 50,
        sleepingMinutes = new int[]{
          0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,

        }
      };

      Guard second = new Guard(99) {
        minutesSlept = 24,
        sleepingMinutes = new int[]{
          0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,3,2,2,2,2,1,1,1,1,1,0,0,0,0,0,

        }
      };

      data.Add(first);
      data.Add(second);


      int result = Day4.firstProblem(data);

      Assert.AreEqual(240, result);

    }

    [TestMethod()]
    public void secondProblemTest() {
      List<Guard> data = new List<Guard>();
      Guard first = new Guard(10) {
        minutesSlept = 50,
        sleepingMinutes = new int[]{
          0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,

        }
      };

      Guard second = new Guard(99) {
        minutesSlept = 24,
        sleepingMinutes = new int[]{
          0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,3,2,2,2,2,1,1,1,1,1,0,0,0,0,0,

        }
      };

      data.Add(first);
      data.Add(second);


      int result = Day4.secondProblem(data);

      Assert.AreEqual(4455, result);
    }
  }
}