namespace AdventOfCode.Year2023.Tests.Solutions;

[TestClass]
public class Day03Tests
{
    private readonly int[] numbersToFind = [467, 114, 35, 633, 617, 58, 592, 755, 664, 598];

    // Write as string array instead of using split
    private readonly string[] data = [
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        ".592......",
        "......755",
        "...$.*....",
        ".664.598.."];
    [TestMethod]
    public void VerifyConvert()
    {

        var convertResult = Day03.Convert(data);

        Assert.IsNotNull(convertResult);
        Assert.HasCount(10, convertResult.Numbers);
        Assert.IsTrue(convertResult.Numbers.Any(number => number.Value == 35 && number.X == 2 && number.Y == 2 && number.XEnd == 3));
        Assert.IsTrue(numbersToFind.All(number => convertResult.Numbers.Any(numberPosition => numberPosition.Value == number)));

        Assert.HasCount(6, convertResult.Parts);
        Assert.IsTrue(convertResult.Parts.Any(part => part.X == 3 && part.Y == 1));
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var converted = Day03.Convert(data);

        Assert.AreEqual(3769, Day03.FirstProblem(converted));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var converted = Day03.Convert(data);

        Assert.AreEqual(467835, Day03.SecondProblem(converted));
    }
}
