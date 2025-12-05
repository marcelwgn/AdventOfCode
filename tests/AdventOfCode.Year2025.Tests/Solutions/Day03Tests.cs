namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day03Tests
{
    string[] sampleInput = [
        "987654321111111",
        "811111111111119",
        "234234234234278",
        "818181911112111",
    ];

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var result = Year2025.Solutions.Day03.FirstProblem(sampleInput);

        Assert.AreEqual("357", result);
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var result = Year2025.Solutions.Day03.SecondProblem(sampleInput);

        Assert.AreEqual("3121910778619", result);
    }
}
