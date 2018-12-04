using AdventOfCode.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Utils.Tests {
  [TestClass()]
  public class StringUtilsTests {
    [TestMethod()]
    public void letterIsInTwiceTest_ContainsALetterTwice() {
      string test = "bababc";

      bool result = test.containsLetterExactlyTwice();

      Assert.IsTrue(result);
    }

    [TestMethod()]
    public void letterIsInTwiceTest_ContainsNoLetterTwice() {
      string test = "abcdef";

      bool result = test.containsLetterExactlyTwice();

      Assert.IsFalse(result);
    }

    [TestMethod()]
    public void letterIsInTwiceTest_ContainsALetterThrice() {
      string test = "aaabcdef";

      bool result = test.containsLetterExactlyTwice();

      Assert.IsFalse(result);
    }

    [TestMethod()]
    public void letterIsInThriceTest_ContainsALetterTwice() {
      string test = "abcefhiklmnnopqqrstuvwxyzz";

      bool result = test.containsLetterExactlyThrice();

      Assert.IsFalse(result);
    }

    [TestMethod()]
    public void letterIsInThriceTest_ContainsNoLetterTwice() {
      string test = "abcdef";

      bool result = test.containsLetterExactlyThrice();

      Assert.IsFalse(result);
    }

    [TestMethod()]
    public void letterIsInThriceTest_ContainsALetterThrice() {
      string test = "aaabcdef";

      bool result = test.containsLetterExactlyThrice();

      Assert.IsTrue(result);
    }

    [TestMethod()]
    public void numberOfLettersDifferentTest_TwoLettersDifferent() {
      string first = "abcde";
      string second = "axcye";

      int result = first.numberOfLettersDifferent(second);

      Assert.AreEqual(2, result);
    }

    [TestMethod()]
    public void numberOfLettersDifferentTest_OneLetterDifferent() {
      string first = "fghij";
      string second = "fguij";

      int result = first.numberOfLettersDifferent(second);

      Assert.AreEqual(1, result);
    }

    [TestMethod()]
    public void getCommonLettersTest() {
      string first = "fghij";
      string second = "fguij";

      string result = first.getCommonLetters(second);

      Assert.AreEqual("fgij", result);
    }
  }
}