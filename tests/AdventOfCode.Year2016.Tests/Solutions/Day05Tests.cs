using AdventOfCode.Year2016.Solutions;

namespace AdventOfCode.Year2016.Tests.Solutions;

[TestClass]
public class Day05Tests
{
    [TestMethod]
    public void FirstProblemTest()
    {
        Assert.AreEqual("18f47a30", Day05.FirstProblem(["abc"]));
    }

    [TestMethod]
    public void SecondProblemTest()
    {
        Assert.AreEqual("05ace8e3", Day05.SecondProblem(["abc"]));
    }
}
