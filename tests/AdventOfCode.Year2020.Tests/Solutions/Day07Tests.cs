using AdventOfCode.Year2020.Solutions;

namespace AdventOfCode.Year2020.Tests.Solutions;

[TestClass]
public class Day07Tests
{

    [TestMethod]
    public void VerifyConvertingBehavior()
    {
        var data = new string[]
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        var dict = Day07.ConvertData(data);

        Assert.HasCount(9, dict);
        Assert.IsTrue(dict["light red"].CanHoldGoldBag());
        Assert.IsTrue(dict["dark orange"].CanHoldGoldBag());
        Assert.IsTrue(dict["bright white"].CanHoldGoldBag());
        Assert.IsTrue(dict["muted yellow"].CanHoldGoldBag());
        Assert.IsFalse(dict["shiny gold"].CanHoldGoldBag());
        Assert.IsFalse(dict["dark olive"].CanHoldGoldBag());
        Assert.IsFalse(dict["vibrant plum"].CanHoldGoldBag());
        Assert.IsFalse(dict["faded blue"].CanHoldGoldBag());
        Assert.IsFalse(dict["dotted black"].CanHoldGoldBag());
    }

    [TestMethod]
    public void VerifyBagCount()
    {
        var data = new string[]
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        var dict = Day07.ConvertData(data);

        Assert.AreEqual(187, dict["light red"].GetBagCount());
        Assert.AreEqual(407, dict["dark orange"].GetBagCount());
        Assert.AreEqual(34, dict["bright white"].GetBagCount());
        Assert.AreEqual(76, dict["muted yellow"].GetBagCount());
        Assert.AreEqual(33, dict["shiny gold"].GetBagCount());
        Assert.AreEqual(8, dict["dark olive"].GetBagCount());
        Assert.AreEqual(12, dict["vibrant plum"].GetBagCount());
        Assert.AreEqual(1, dict["faded blue"].GetBagCount());
        Assert.AreEqual(1, dict["dotted black"].GetBagCount());
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var data = new string[]
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        Assert.AreEqual(4, Day07.FirstProblem(data));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {

        var data = new string[]
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        Assert.AreEqual(32, Day07.SecondProblem(data));
    }
}
