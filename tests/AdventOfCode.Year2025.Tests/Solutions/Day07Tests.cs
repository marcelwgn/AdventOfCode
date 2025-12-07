namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day07Tests
{
    string[] sampleInput = [
        ".......S.......",
        "...............",
        ".......^.......",
        "...............",
        "......^.^......",
        "...............",
        ".....^.^.^.....",
        "...............",
        "....^.^...^....",
        "...............",
        "...^.^...^.^...",
        "...............",
        "..^...^.....^..",
        "...............",
        ".^.^.^.^.^...^.",
        "..............."
    ];

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var result = Year2025.Solutions.Day07.FirstProblem(sampleInput);

        Assert.AreEqual("21", result);
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var result = Year2025.Solutions.Day07.SecondProblem(sampleInput);

        Assert.AreEqual("40", result);
    }
}
