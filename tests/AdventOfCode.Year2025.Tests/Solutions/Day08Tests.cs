namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day08Tests
{
	string[] sampleInput = [
		"162,817,812",
		"57,618,57",
		"906,360,560",
		"592,479,940",
		"352,342,300",
		"466,668,158",
		"542,29,236",
		"431,825,988",
		"739,650,466",
		"52,470,668",
		"216,146,977",
		"819,987,18",
		"117,168,530",
		"805,96,715",
		"346,949,466",
		"970,615,88",
		"941,993,340",
		"862,61,35",
		"984,92,344",
		"425,690,689"
    ];

	[TestMethod]
	public void VerifyFirstProblem()
	{
		Year2025.Solutions.Day08.cConnections = 10;
        var result = Year2025.Solutions.Day08.FirstProblem(sampleInput);

		Assert.AreEqual("40", result);
	}

	[TestMethod]
	public void VerifySecondProblem()
	{
		var result = Year2025.Solutions.Day08.SecondProblem(sampleInput);

		Assert.AreEqual("25272", result);
	}
}
