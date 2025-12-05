using AdventOfCode.Year2016.Solutions;

namespace AdventOfCode.Year2016.Tests.Solutions;

[TestClass]
public class Day23Tests
{
    [TestMethod]
    [DataRow('i', false, 'd')]
    [DataRow('d', false, 'i')]
    [DataRow('m', true, 'j')]
    [DataRow('j', true, 'c')]
    public void ToggleInstructionTest(char instructionInitial, bool hasTwoParams, char expected)
    {
        Assert.AreEqual(expected, Day23.ToggleInstruction(instructionInitial, hasTwoParams));
    }

    [TestMethod]
    public void FirstProblemTest()
    {
        var data = new string[]
        {
            "cpy 2 a",
            "tgl a",
            "tgl a",
            "tgl a",
            "cpy 1 a",
            "dec a",
            "dec a",
        };

        Assert.AreEqual(3, Day23.FirstProblem(data));
    }

    [TestMethod]
    public void SecondProblemTest()
    {
        var data = new string[]
        {
            "cpy 2 a",
            "tgl a",
            "tgl a",
            "tgl a",
            "cpy 1 a",
            "dec a",
            "dec a",
        };

        Assert.AreEqual(3, Day23.SecondProblem(data));
    }
}
