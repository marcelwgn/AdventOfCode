namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day05Tests
{
	string[] sampleInput = [
		"3-5",
		"10-14",
		"16-20",
		"12-18",
		"",
		"1",
		"5",
		"8",
		"11",
		"17",
		"32",
    ];

	[TestMethod]
	public void VerifyFirstProblem()
	{
		var result = Year2025.Solutions.Day05.FirstProblem(sampleInput);

		Assert.AreEqual("3", result);
	}

	[TestMethod]
	public void VerifySecondProblem()
	{
		var result = Year2025.Solutions.Day05.SecondProblem(sampleInput);

		Assert.AreEqual("14", result);
	}
}
