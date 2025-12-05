using AdventOfCode.Year2020.Solutions;

namespace AdventOfCode.Year2020.Tests.Solutions;

[TestClass]
public class Day16Tests
{

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[]
        {
            "class: 1-3 or 5-7",
            "row: 6-11 or 33-44",
            "seat: 13-40 or 45-50",
            "",
            "your ticket:",
            "7,1,14",
            "",
            "nearby tickets:",
            "7,3,47",
            "40,4,50",
            "55,2,20",
            "38,6,12"
        };

        Assert.AreEqual(71, Day16.FirstProblem(data));
    }

    [TestMethod]
    public void VerifyGetValidNumbersDictionary()
    {
        var data = new string[]
        {
            "class: 1-3 or 5-7",
            "row: 6-11 or 33-44",
            "seat: 13-40 or 45-50"
        };

        var validNumbers = Day16.GetValidNumbers(data);

        var notValids = new int[]
        {
            0,4,12,51,52,53,54,55,56,57,58,59
        };

        for (var i = 0; i < 60; i++)
        {
            Assert.AreEqual(!notValids.Contains(i), validNumbers.Contains(i), $"Missmatch for {i}");
        }
    }

    [TestMethod]
    public void VerifyGetValidTicketMapCase1()
    {
        var data = new string[]
        {
            "class: 1-3 or 5-7",
            "row: 6-11 or 33-44",
            "seat: 13-40 or 45-50",
            "",
            "your ticket:",
            "7,1,14",
            "",
            "nearby tickets:",
            "7,3,47",
            "40,4,50",
            "55,2,20",
            "38,6,12"
        };

        var expected = new string[]
        {
            "row","class","seat"
        };
        var map = Day16.GetCategoryMap(data);

        CollectionAssert.AreEqual(expected, map);
    }

    [TestMethod]
    public void VerifyGetValidTicketMapCase2()
    {
        var data = new string[]
        {
            "class: 0-1 or 4-19",
            "row: 0-5 or 8-19",
            "seat: 0-13 or 16-19",
            "",
            "your ticket:",
            "11,12,13",
            "",
            "nearby tickets:",
            "3,9,18",
            "15,1,5",
            "5,14,9"
        };

        var expected = new string[]
        {
            "row","class","seat"
        };
        var map = Day16.GetCategoryMap(data);

        CollectionAssert.AreEqual(expected, map);
    }
}
