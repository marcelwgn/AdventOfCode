namespace AdventOfCode.Year2023.Tests.Solutions;

[TestClass]
public class Day19Tests
{
    private static readonly string[] data = [
        "px{a<2006:qkq,m>2090:A,rfg}",
        "pv{a>1716:R,A}",
        "lnx{m>1548:A,A}",
        "rfg{s<537:gd,x>2440:R,A}",
        "qs{s>3448:A,lnx}",
        "qkq{x<1416:A,crn}",
        "crn{x>2662:A,R}",
        "in{s<1351:px,qqz}",
        "qqz{s>2770:qs,m<1801:hdj,R}",
        "gd{a>3333:R,R}",
        "hdj{m>838:A,pv}",
        "",
        "{x=787,m=2655,a=1222,s=2876}",
        "{x=1679,m=44,a=2067,s=496}",
        "{x=2036,m=264,a=79,s=2244}",
        "{x=2461,m=1339,a=466,s=291}",
        "{x=2127,m=1623,a=2188,s=1013}"
    ];

    [TestMethod]
    public void VerifyConvert()
    {
        var parseResult = Day19.Convert(data);

        Assert.HasCount(11, parseResult.Rules);
        Assert.HasCount(3, parseResult.Rules["px"].Conditions);
        Assert.HasCount(5, parseResult.Presents);
        Assert.AreEqual(new Present(787, 2655, 1222, 2876), parseResult.Presents[0]);
    }

    [TestMethod]
    public void VerifyFirstProblem()
    {
        var parseResult = Day19.Convert(data);

        Assert.AreEqual(19114, Day19.FirstProblem(parseResult));
    }

    [TestMethod]
    public void VerifySecondProblem()
    {
        var parseResult = Day19.Convert(data);

        Assert.AreEqual(167409079868000, Day19.SecondProblem(parseResult));
    }
}
