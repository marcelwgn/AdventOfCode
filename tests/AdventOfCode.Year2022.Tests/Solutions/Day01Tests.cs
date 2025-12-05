using AdventOfCode.Year2022.Solutions;

namespace AdventOfCode.Year2022.Tests.Solutions;

[TestClass]
public class Day01Tests
{

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var numbers = new string[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };

        Assert.AreEqual(24000, Day01.FirstProblem(numbers));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var numbers = new string[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };

        Assert.AreEqual(45000, Day01.SecondProblem(numbers));
    }

}
