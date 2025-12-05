using AdventOfCode.Year2019.Solutions;

namespace AdventOfCode.Year2019.Tests.Solutions;

[TestClass]
public class Day01Tests
{
    [TestMethod]
    [DataRow(12, 2)]
    [DataRow(14, 2)]
    [DataRow(1969, 654)]
    [DataRow(100756, 33583)]
    public void VerifyFuelCalculationFirstProblem(int mass, int expectedFuel)
    {
        Assert.AreEqual(expectedFuel, Day01.CalculateFuelFirstProblem(mass));
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new int[]
        {
            12,
            14,
            1969,
            100756
        };

        Assert.AreEqual(34241, Day01.FirstProblem(data));
    }

    [TestMethod]
    [DataRow(12, 2)]
    [DataRow(14, 2)]
    [DataRow(1969, 966)]
    [DataRow(100756, 50346)]
    public void VerifyFuelCalculationSecondProblem(int mass, int expectedFuel)
    {
        Assert.AreEqual(expectedFuel, Day01.CalculateFuelSecondProblem(mass));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var data = new int[]
        {
            12,
            14,
            1969,
            100756
        };

        Assert.AreEqual(51316, Day01.SecondProblem(data));
    }
}
