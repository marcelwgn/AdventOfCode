using AdventOfCode.Year2022.Solutions;

namespace AdventOfCode.Year2022.Tests.Solutions;

[TestClass]
public class Day04Tests
{
    [TestMethod]
    public void VerifyFirstProblem()
    {
        var ranges = new string[]
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
        };
        var converted = Day04.Convert(ranges);

        Assert.AreEqual(2, Day04.FirstProblem(converted));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var ranges = new string[]
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
        };
        var converted = Day04.Convert(ranges);

        Assert.AreEqual(4, Day04.SecondProblem(converted));
    }
}
