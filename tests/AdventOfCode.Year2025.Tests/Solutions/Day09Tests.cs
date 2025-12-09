namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day09Tests
{
	string[] sampleInput = [
		"7,1",
		"11,1",
		"11,7",
		"9,7",
		"9,5",
		"2,5",
		"2,3",
		"7,3",
	];

	[TestMethod]
	public void VerifyFirstProblem()
	{
		var result = Year2025.Solutions.Day09.FirstProblem(sampleInput);

		Assert.AreEqual("50", result);
	}

    [TestMethod]
    public void VerifySecondProblem()
    {
        var result = Year2025.Solutions.Day09.SecondProblem(sampleInput);

        Assert.AreEqual("24", result);
    }
}
