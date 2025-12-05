using AdventOfCode.Year2016.Solutions;

namespace AdventOfCode.Year2016.Tests.Solutions;

[TestClass]
public class Day06Tests
{
    [TestMethod]
    public void FirstProblemTest()
    {
        var data = new string[]
        {
            "eedadn",
            "drvtee",
            "eandsr",
            "raavrd",
            "atevrs",
            "tsrnev",
            "sdttsa",
            "rasrtv",
            "nssdts",
            "ntnada",
            "svetve",
            "tesnvt",
            "vntsnd",
            "vrdear",
            "dvrsen",
            "enarar"
        };
        Assert.AreEqual("easter", Day06.FirstProblem(data));
    }

    [TestMethod]
    public void SecondProblemTest()
    {
        var data = new string[]
        {
            "eedadn",
            "drvtee",
            "eandsr",
            "raavrd",
            "atevrs",
            "tsrnev",
            "sdttsa",
            "rasrtv",
            "nssdts",
            "ntnada",
            "svetve",
            "tesnvt",
            "vntsnd",
            "vrdear",
            "dvrsen",
            "enarar"
        };
        Assert.AreEqual("advent", Day06.SecondProblem(data));
    }
}
