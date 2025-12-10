namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day10Tests
{
	string[] sampleInput = [
		"[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}",
		"[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}",
		"[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}",
	];

	[TestMethod]
	public void VerifyFirstProblem()
	{
		var result = Year2025.Solutions.Day10.FirstProblem(sampleInput);

		Assert.AreEqual("7", result);
	}

	[TestMethod]
	public void VerifySecondProblem()
	{
		var result = Year2025.Solutions.Day10.SecondProblem(sampleInput);

		Assert.AreEqual("33", result);
	}
}
