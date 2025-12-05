using AdventOfCode.Year2016.Solutions;

namespace AdventOfCode.Year2016.Tests.Solutions;

[TestClass]
public class Day02Tests
{

    [TestMethod]
    public void FirstProblemTest()
    {
        var data = new string[]
        {
            "ULL",
            "RRDDD",
            "LURDL",
            "UUUUD",
        };
        Assert.AreEqual("1985", Day02.FirstProblem(data));
    }

    [TestMethod]
    public void SecondProblemTest()
    {
        var data = new string[]
        {
            "ULL",
            "RRDDD",
            "LURDL",
            "UUUUD",
        };
        Assert.AreEqual("5DB3", Day02.SecondProblem(data));
    }
}
