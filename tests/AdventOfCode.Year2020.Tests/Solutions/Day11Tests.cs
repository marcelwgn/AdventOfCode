using AdventOfCode.Common;
using AdventOfCode.Year2020.Solutions;

namespace AdventOfCode.Year2020.Tests.Solutions;

[TestClass]
public class Day11Tests
{

    [TestMethod]
    public void VerifyTransformFirstProblem()
    {
        var firstData = new string[]
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        }.ToCharArray();

        var secondData = new string[]
        {
            "#.##.##.##",
            "#######.##",
            "#.#.#..#..",
            "####.##.##",
            "#.##.##.##",
            "#.#####.##",
            "..#.#.....",
            "##########",
            "#.######.#",
            "#.#####.##"
        }.ToCharArray();

        var thirdData = new string[]
        {
            "#.LL.L#.##",
            "#LLLLLL.L#",
            "L.L.L..L..",
            "#LLL.LL.L#",
            "#.LL.LL.LL",
            "#.LLLL#.##",
            "..L.L.....",
            "#LLLLLLLL#",
            "#.LLLLLL.L",
            "#.#LLLL.##",
        }.ToCharArray();

        var fourthData = new string[]
        {
            "#.##.L#.##",
            "#L###LL.L#",
            "L.#.#..#..",
            "#L##.##.L#",
            "#.##.LL.LL",
            "#.###L#.##",
            "..#.#.....",
            "#L######L#",
            "#.LL###L.L",
            "#.#L###.##"
        }.ToCharArray();

        var fifthData = new string[]
        {
            "#.#L.L#.##",
            "#LLL#LL.L#",
            "L.L.L..#..",
            "#LLL.##.L#",
            "#.LL.LL.LL",
            "#.LL#L#.##",
            "..L.L.....",
            "#L#LLLL#L#",
            "#.LLLLLL.L",
            "#.#L#L#.##"
        }.ToCharArray();

        var expectedData = new char[][][]
        {
            secondData, thirdData, fourthData, fifthData
        };

        for (var i = 0; i < 4; i++)
        {
            Assert.IsTrue(Day11.TransformFirstProblem(firstData));
            for (var j = 0; j < expectedData[i].Length; j++)
            {
                CollectionAssert.AreEqual(expectedData[i][j], firstData[j]);
            }
        }

    }
    [TestMethod]
    public void VerifyTransformSecondProblem()
    {
        var firstData = new string[]
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        }.ToCharArray();

        var secondData = new string[]
        {
            "#.##.##.##",
            "#######.##",
            "#.#.#..#..",
            "####.##.##",
            "#.##.##.##",
            "#.#####.##",
            "..#.#.....",
            "##########",
            "#.######.#",
            "#.#####.##"
        }.ToCharArray();

        var thirdData = new string[]
        {
            "#.LL.LL.L#",
            "#LLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLL#",
            "#.LLLLLL.L",
            "#.LLLLL.L#"
        }.ToCharArray();

        var fourthData = new string[]
        {
            "#.L#.##.L#",
            "#L#####.LL",
            "L.#.#..#..",
            "##L#.##.##",
            "#.##.#L.##",
            "#.#####.#L",
            "..#.#.....",
            "LLL####LL#",
            "#.L#####.L",
            "#.L####.L#"
        }.ToCharArray();

        var fifthData = new string[]
        {
            "#.L#.L#.L#",
            "#LLLLLL.LL",
            "L.L.L..#..",
            "##LL.LL.L#",
            "L.LL.LL.L#",
            "#.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLL#",
            "#.LLLLL#.L",
            "#.L#LL#.L#"
        }.ToCharArray();

        var expectedData = new char[][][]
        {
            secondData, thirdData, fourthData, fifthData
        };

        for (var i = 0; i < 4; i++)
        {
            Assert.IsTrue(Day11.TransformSecondProblem(firstData));
            for (var j = 0; j < expectedData[i].Length; j++)
            {
                CollectionAssert.AreEqual(expectedData[i][j], firstData[j]);
            }
        }

    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[]
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        }.ToCharArray();

        Assert.AreEqual(37, Day11.FirstProblem(data));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var data = new string[]
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        }.ToCharArray();

        Assert.AreEqual(26, Day11.SecondProblem(data));
    }
}
