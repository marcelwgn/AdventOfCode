using AdventOfCode.Year2022.Solutions;

namespace AdventOfCode.Year2022.Tests.Solutions;

[TestClass]
public class Day08Tests
{

    private static readonly string[] DATA =
    [
        "30373",
        "25512",
        "65332",
        "33549",
        "35390",
    ];

    [TestMethod]
    public void VerifyConvert()
    {
        var field = Day08.Convert(DATA);
        Assert.HasCount(5, field);
        Assert.HasCount(5, field[0]);
        Assert.AreEqual(3, field[0][0].Height);
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var field = Day08.Convert(DATA);

        Assert.AreEqual(21, Day08.FirstProblem(field));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var field = Day08.Convert(DATA);

        Assert.AreEqual(8, Day08.SecondProblem(field));
    }
}
