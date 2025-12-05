using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Common.Tests.Extensions;

[TestClass()]
public class StringUtilsTests
{
    [TestMethod()]
    public void LetterIsInTwiceTestContainsALetterTwice()
    {
        var test = "bababc";

        var result = test.ContainsLetterExactlyTwice();

        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void LetterIsInTwiceTestContainsALetterTwiceAtEnd()
    {
        var test = "bacc";

        var result = test.ContainsLetterExactlyTwice();

        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void LetterIsInTwiceTestContainsNoLetterTwice()
    {
        var test = "abcdef";

        var result = test.ContainsLetterExactlyTwice();

        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void LetterIsInTwiceTestContainsALetterThrice()
    {
        var test = "aaabcdef";

        var result = test.ContainsLetterExactlyTwice();

        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void LetterIsInThriceTestContainsALetterTwice()
    {
        var test = "abcefhiklmnnopqqrstuvwxyzz";

        var result = test.ContainsLetterExactlyThrice();

        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void LetterIsInThriceTestContainsALetterThriceAtEnd()
    {
        var test = "abcefhiklmnnopqqrstuvwxyzzz";

        var result = test.ContainsLetterExactlyThrice();

        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void LetterIsInThriceTestContainsNoLetterTwice()
    {
        var test = "abcdef";

        var result = test.ContainsLetterExactlyThrice();

        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void LetterIsInThriceTestContainsALetterThrice()
    {
        var test = "aaabcdef";

        var result = test.ContainsLetterExactlyThrice();

        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void NumberOfLettersDifferentTestTwoLettersDifferent()
    {
        var first = "abcde";
        var second = "axcye";

        var result = first.NumberOfLettersDifferent(second);

        Assert.AreEqual(2, result);
    }

    [TestMethod()]
    public void NumberOfLettersDifferentTestOneLetterDifferent()
    {
        var first = "fghij";
        var second = "fguij";

        var result = first.NumberOfLettersDifferent(second);

        Assert.AreEqual(1, result);
    }

    [TestMethod()]
    public void GetCommonLettersTest()
    {
        var first = "fghij";
        var second = "fguij";

        var result = first.GetCommonLetters(second);

        Assert.AreEqual("fgij", result);
    }
}