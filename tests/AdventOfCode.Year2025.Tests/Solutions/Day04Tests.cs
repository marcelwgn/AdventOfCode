namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day04Tests
{
	string[] sampleInput = [
		"..@@.@@@@.",
		"@@@.@.@.@@",
		"@@@@@.@.@@",
		"@.@@@@..@.",
		"@@.@@@@.@@",
		".@@@@@@@.@",
		".@.@.@.@@@",
		"@.@@@.@@@@",
		".@@@@@@@@.",
		"@.@.@@@.@.",
	];

	[TestMethod]
	public void VerifyFirstProblem()
	{
		var result = Year2025.Solutions.Day04.FirstProblem(Year2025.Solutions.Day04.Convert(sampleInput));

		Assert.AreEqual("13", result);
	}

	[TestMethod]
	public void VerifySecondProblem()
	{
		var result = Year2025.Solutions.Day04.SecondProblem(Year2025.Solutions.Day04.Convert(sampleInput));

		Assert.AreEqual("43", result);
	}
}
