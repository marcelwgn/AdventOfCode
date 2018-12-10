using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day02Tests {
    [TestMethod()]
    public void convertTest() {
      string[] data = { "Test", "test", "TeSt" };
      string[] dataConverted = Day02.convert(data);

      Assert.AreSame(data, dataConverted);
    }

    [TestMethod()]
    public void firstProblemTest() {
      string[] data = {
                        "abcdef",
                        "bababc ",
                        "abbcde ",
                        "abcccd ",
                        "aabcdd ",
                        "abcdee ",
                        "ababab " };
      int checksum = Day02.firstProblem(data);

      Assert.AreEqual(12, checksum);

    }

    [TestMethod()]
    public void secondProblemTest() {
      string[] data = {
                        "abcde",
                        "fghij",
                        "klmno",
                        "pqrst",
                        "fguij",
                        "axcye",
                        "wvxyz"
                        };

      string result = Day02.secondProblem(data);

      Assert.AreEqual("fgij", result);

    }
  }
}