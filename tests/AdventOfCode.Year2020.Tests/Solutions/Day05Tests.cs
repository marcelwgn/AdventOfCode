using AdventOfCode.Year2020.Solutions;

namespace AdventOfCode.Year2020.Tests.Solutions;

[TestClass]
public class Day05Tests
{
    [TestMethod]
    [DataRow("BFFFBBFRRR", 567)]
    [DataRow("FFFBBBFRRR", 119)]
    [DataRow("BBFFBBFRLL", 820)]
    public void VerifyPassID(string data, int id)
    {
        Assert.AreEqual(id, Day05.GetBoardingPassID(data));
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[]
        {
            "BFFFBBFRRR",
            "FFFBBBFRRR",
            "BBFFBBFRLL"
        };

        Assert.AreEqual(820, Day05.FirstProblem(data));
    }
}
