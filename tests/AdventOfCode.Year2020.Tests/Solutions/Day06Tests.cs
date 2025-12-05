using AdventOfCode.Year2020.Solutions;

namespace AdventOfCode.Year2020.Tests.Solutions;

[TestClass]
public class Day06Tests
{

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[] {
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b",
        };

        Assert.AreEqual(11, Day06.FirstProblem(data));
    }
    [TestMethod]
    public void VerifySecondProblem()
    {
        var data = new string[] {
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b",
        };

        Assert.AreEqual(6, Day06.SecondProblem(data));
    }

    [TestMethod]
    public void VerifyGetAllQuestionCount()
    {
        var data = "abcx;abcy;abcz";

        Assert.AreEqual(6, Day06.GetAllQuestionCount(data));
    }

    [TestMethod]
    public void VerifyGetSameQuestionCount()
    {
        var data = "abcx;abcy;abcz";

        Assert.AreEqual(3, Day06.GetSameQuestionCount(data));
    }

}
