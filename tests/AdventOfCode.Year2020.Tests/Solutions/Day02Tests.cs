using AdventOfCode.Year2020.Solutions;

namespace AdventOfCode.Year2020.Tests.Solutions;

[TestClass]
public class Day02Tests
{
    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[]
        {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc"
        };

        Assert.AreEqual(2, Day02.FirstProblem(data));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var data = new string[]
        {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc"
        };

        Assert.AreEqual(1, Day02.SecondProblem(data));
    }
}
