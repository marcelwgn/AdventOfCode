using AdventOfCode.Year2020.Solutions;

namespace AdventOfCode.Year2020.Tests.Solutions;

[TestClass]
public class Day01Tests
{

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var numbers = new long[]
        {
            1721,
            979 ,
            366 ,
            299 ,
            675 ,
            1456
        };

        Assert.AreEqual(514579, Day01.FirstProblem(numbers));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var numbers = new long[]
        {
            1721,
            979 ,
            366 ,
            299 ,
            675 ,
            1456
        };

        Assert.AreEqual(241861950, Day01.SecondProblem(numbers));
    }

}
