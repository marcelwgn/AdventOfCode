using System.Linq;
using AdventOfCode.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Utils.Tests {
  [TestClass()]
  public class DataConverterTests {
    [TestMethod()]
    public void getNumbersTest() {
      string[] data = { "1", "-2", "+3" };

      int[] result = ConverterUtils.getNumbers(data);

      int[] expected = { 1, -2, 3 };

      for (int i = 0; i < data.Length; i++) {
        if (!result.Contains(expected[i])){
          Assert.Fail();
        }
      }
    }
  }
}