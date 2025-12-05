namespace AdventOfCode.Year2023.Tests.Solutions;

[TestClass]
public class Day15Tests
{
    [TestMethod]
    public void VerifyCalculateNumber()
    {
        Assert.AreEqual(52, Day15.CalculateHash("HASH"));
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[] { "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7" };

        Assert.AreEqual(1320, Day15.FirstProblem(data));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var data = new string[] { "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7" };

        Assert.AreEqual(145, Day15.SecondProblem(data));
    }
}
