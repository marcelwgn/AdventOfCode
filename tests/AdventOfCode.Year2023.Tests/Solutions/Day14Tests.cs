namespace AdventOfCode.Year2023.Tests.Solutions;

[TestClass]
public class Day14Tests
{

    private static readonly string[] field = [
        "O....#....",
        "O.OO#....#",
        ".....##...",
        "OO.#O....O",
        ".O.....O#.",
        "O.#..O.#.#",
        "..O..#O..O",
        ".......O..",
        "#....###..",
        "#OO..#....",
    ];

    private static readonly string[] fieldShiftedNorth = [
        "OOOO.#.O..",
        "OO..#....#",
        "OO..O##..O",
        "O..#.OO...",
        "........#.",
        "..#....#.#",
        "..O..#.O.O",
        "..O.......",
        "#....###..",
        "#....#....",
    ];

    private static readonly string[] northFieldShiftedEast = [
        ".OOOO#...O",
        "..OO#....#",
        "..OOO##..O",
        "..O#....OO",
        "........#.",
        "..#....#.#",
        "....O#..OO",
        ".........O",
        "#....###..",
        "#....#....",
    ];

    private static readonly string[] northFieldShiftedWest = [
        "OOOO.#O...",
        "OO..#....#",
        "OOO..##O..",
        "O..#OO....",
        "........#.",
        "..#....#.#",
        "O....#OO..",
        "O.........",
        "#....###..",
        "#....#....",
    ];

    [TestMethod]
    public void VerifyShiftRocksNorth()
    {
        var charField = Day14.ToCharField(field);
        Day14.ShiftRocks(charField, false, false);

        var asStringArray = charField.Select(x => string.Join("", x)).ToArray();

        for (int i = 0; i < asStringArray.Length; i++)
        {
            Assert.AreEqual(fieldShiftedNorth[i], asStringArray[i]);
        }
    }

    [TestMethod]
    public void VerifyShiftRocksEast()
    {
        var charField = Day14.ToCharField(fieldShiftedNorth);
        Day14.ShiftRocks(charField, true, true);

        var asStringArray = charField.Select(x => string.Join("", x)).ToArray();

        for (int i = 0; i < asStringArray.Length; i++)
        {
            Assert.AreEqual(northFieldShiftedEast[i], asStringArray[i]);
        }
    }

    [TestMethod]
    public void VerifyShiftRocksWest()
    {
        var charField = Day14.ToCharField(fieldShiftedNorth);
        Day14.ShiftRocks(charField, true, false);

        var asStringArray = charField.Select(x => string.Join("", x)).ToArray();

        for (int i = 0; i < asStringArray.Length; i++)
        {
            Assert.AreEqual(northFieldShiftedWest[i], asStringArray[i]);
        }
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        Assert.AreEqual(136, Day14.FirstProblem(field));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        Assert.AreEqual(64, Day14.SecondProblem(field));
    }
}
