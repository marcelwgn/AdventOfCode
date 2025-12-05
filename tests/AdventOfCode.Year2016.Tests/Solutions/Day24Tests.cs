using AdventOfCode.Common.DataStructures;
using AdventOfCode.Year2016.Solutions;

namespace AdventOfCode.Year2016.Tests.Solutions;

[TestClass]
public class Day24Tests
{

    private readonly string[] demoMaze =
    [
        "###########",
        "#0.1.....2#",
        "#.#######.#",
        "#4.......3#",
        "###########",
    ];

    [TestMethod]
    public void ConvertTest()
    {
        var expectedCharArray = new char[][]
        {
            ['#','#','#','#','#','#','#','#','#','#','#'],
            ['#','0','.','1','.','.','.','.','.','2','#'],
            ['#','.','#','#','#','#','#','#','#','.','#'],
            ['#','4','.','.','.','.','.','.','.','3','#'],
            ['#','#','#','#','#','#','#','#','#','#','#']
        };

        var actual = Day24.Convert(demoMaze);
        for (var i = 0; i < expectedCharArray.Length; i++)
        {
            CollectionAssert.AreEqual(expectedCharArray[i], actual[i]);
        }
    }

    [TestMethod]
    public void GetNumbersTest()
    {
        var expectedPositions = new Coordinate[]
        {
            new(1,1),new(1,3),new(1,9),new(3,9),new(3,1)
        };

        CollectionAssert.AreEqual(expectedPositions, Day24.GetNumberPositions(Day24.Convert(demoMaze)));
    }

    [TestMethod]
    public void FirstProblemTest()
    {
        var charData = Day24.Convert(demoMaze);

        Assert.AreEqual(14, Day24.FirstProblem(charData));
    }

    [TestMethod]
    public void SecondProblemTest()
    {
        var charData = Day24.Convert(demoMaze);

        Assert.AreEqual(20, Day24.SecondProblem(charData));
    }
}
