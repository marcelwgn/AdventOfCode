using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day2Tests {
    [TestMethod()]
    public void convertTest() {
      string[] data = { "Test", "test", "TeSt" };
      string[] dataConverted = Day2.convert(data);

      Assert.AreSame(data, dataConverted);
    }
    [TestMethod()]
    public void firstProblemTest_Easy() {
      string[] data = {
                        "abcdef",
                        "bababc ",
                        "abbcde ",
                        "abcccd ",
                        "aabcdd ",
                        "abcdee ",
                        "ababab " };
      int checksum = Day2.firstProblem(data);

      Assert.AreEqual(12, checksum);

    }

    [TestMethod()]
    public void secondProblemTest_Easy() {
      string[] data = {
                        "abcde",
                        "fghij",
                        "klmno",
                        "pqrst",
                        "fguij",
                        "axcye",
                        "wvxyz"
                        };

      string result = Day2.secondProblem(data);

      Assert.AreEqual("fgij", result);

    }
  }
}