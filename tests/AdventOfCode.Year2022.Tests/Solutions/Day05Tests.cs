using AdventOfCode.Year2022.Solutions;

namespace AdventOfCode.Year2022.Tests.Solutions;

[TestClass]
public class Day05Tests
{
    [TestMethod]
    public void VerifyStacksCreation()
    {
        var data = new string[]
        {
            "    [D]",
            "[N] [C]",
            "[Z] [M] [P]",
            " 1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2",
        };

        var stacks = Day05.CreateStack(data);
        Assert.AreEqual('N', stacks[0]);
        Assert.AreEqual('D', stacks[1]);
        Assert.AreEqual('P', stacks[2]);
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[]
        {
            "    [D]",
            "[N] [C]",
            "[Z] [M] [P]",
            " 1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2",
        };
        var result = Day05.FirstProblem(data);

        Assert.AreEqual("CMZ", result);
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var data = new string[]
        {
            "    [D]",
            "[N] [C]",
            "[Z] [M] [P]",
            " 1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2",
        };
        var result = Day05.SecondProblem(data);

        Assert.AreEqual("MCD", result);
    }
}
