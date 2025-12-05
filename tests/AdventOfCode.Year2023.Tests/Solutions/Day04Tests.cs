namespace AdventOfCode.Year2023.Tests.Solutions;

[TestClass]
public class Day04Tests
{

    private static readonly string[] data = [
        "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
        "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
        "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        ];

    [TestMethod]
    public void VerifyConvert()
    {
        var parsed = Day04.Convert(data);
        var entryOne = parsed.Where(x => x.Id == 1).First();

        Assert.HasCount(6, parsed);
        Assert.AreEqual(5, entryOne.WinningNumbers.Count());
        Assert.IsTrue(entryOne.WinningNumbers.Contains(83));
        Assert.AreEqual(8, entryOne.DrawnNumbers.Count());
        Assert.IsTrue(entryOne.DrawnNumbers.Contains(83));
        Assert.IsTrue(entryOne.DrawnNumbers.Contains(53));
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var parsed = Day04.Convert(data);

        Assert.AreEqual(13, Day04.FirstProblem(parsed));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var parsed = Day04.Convert(data);

        Assert.AreEqual(30, Day04.SecondProblem(parsed));
    }
}
