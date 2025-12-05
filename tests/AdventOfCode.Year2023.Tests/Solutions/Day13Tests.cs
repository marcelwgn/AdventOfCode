namespace AdventOfCode.Year2023.Tests.Solutions;

[TestClass]
public class Day13Tests
{

    private readonly string[] firstEntry = [
        "#.##..##.",
        "..#.##.#.",
        "##......#",
        "##......#",
        "..#.##.#.",
        "..##..##.",
        "#.#.##.#.",
    ];

    private readonly string[] secondEntry = [
        "#...##..#",
        "#....#..#",
        "..##..###",
        "#####.##.",
        "#####.##.",
        "..##..###",
        "#....#..#",
    ];

    [TestMethod]
    [DataRow("#.##..##.", new int[] { 5, 7 })]
    [DataRow("#.#.##.#.", new int[] { 5 })]
    [DataRow("##......#", new int[] { 1, 5 })]
    [DataRow("..#.##.#.", new int[] { 1, 5 })]
    [DataRow("..##..##.", new int[] { 1, 3, 5, 7 })]
    public void VerifyGetSymmetrieIndex(string data, int[] expectedEntries)
    {
        var result = Day13.GetSymmetryIndices(data.ToCharArray(), 0).ToArray();
        CollectionAssert.AreEquivalent(expectedEntries, result);
    }

    [TestMethod]
    [DataRow("#.##..##.", new int[] { 1, 2, 3, 8 })]
    [DataRow("#.#.##.#.", new int[] { 1, 4, 6, 8 })]
    [DataRow("##......#", new int[] { 6, 7, 8 })]
    [DataRow("..#.##.#.", new int[] { 2, 6, 8 })]
    [DataRow("..##..##.", new int[] { 8 })]
    public void VerifyGetSymmetrieIndexWithOneError(string data, int[] expectedEntries)
    {
        var result = Day13.GetSymmetryIndices(data.ToCharArray(), 1).ToArray();
        CollectionAssert.AreEquivalent(expectedEntries, result);
    }

    [TestMethod]
    public void VerifyCalculateValueForFirstFieldNoModifications()
    {
        Assert.AreEqual(5, Day13.CalculateValueForField(firstEntry));
    }

    [TestMethod]
    public void VerifyCalculateValueForFirstFieldSingleModification()
    {
        Assert.AreEqual(300, Day13.CalculateValueForField(firstEntry, true));
    }

    [TestMethod]
    public void VerifyCalculateValueForSecondFieldNoModifications()
    {
        Assert.AreEqual(400, Day13.CalculateValueForField(secondEntry));
    }

    [TestMethod]
    public void VerifyCalculateValueForSecondFieldSingleModification()
    {
        Assert.AreEqual(100, Day13.CalculateValueForField(secondEntry, true));
    }

    [TestMethod]
    public void VerifyConvert()
    {
        string[] input = [.. firstEntry, "", .. secondEntry];

        var parsed = Day13.Convert(input).ToArray();

        Assert.HasCount(2, parsed);
        CollectionAssert.AreEqual(firstEntry, parsed.First());
        CollectionAssert.AreEqual(secondEntry, parsed.Last());
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        IEnumerable<string[]> input = [firstEntry, secondEntry];

        Assert.AreEqual(405, Day13.FirstProblem(input));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        IEnumerable<string[]> input = [firstEntry, secondEntry];

        Assert.AreEqual(400, Day13.SecondProblem(input));
    }
}
