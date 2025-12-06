namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day06Tests
{
    string[] sampleInput = [
        "123 328  51 64 ",
        " 45 64  387 23 ",
        "  6 98  215 314",
        "*   +   *   +",
    ];

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var result = Year2025.Solutions.Day06.FirstProblem(sampleInput);

        Assert.AreEqual("4277556", result);
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var result = Year2025.Solutions.Day06.SecondProblem(sampleInput);

        Assert.AreEqual("3263827", result);
    }
}
