using AdventOfCode.Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day11Tests
	{
		private readonly string[] data = [
			"...#......",
			".......#..",
			"#.........",
			"..........",
			"......#...",
			".#........",
			".........#",
			"..........",
			".......#..",
			"#...#.....",
		];

		[TestMethod]
		public void VerifyConvert()
		{
			var converted = Day11.Convert(data);

			Assert.HasCount(9, converted.Coordinates);
			CollectionAssert.AreEquivalent(new long[] { 2, 5, 8 }, converted.XGaps);
			CollectionAssert.AreEquivalent(new long[] { 3, 7 }, converted.YGaps);
		}

		[TestMethod]
		public void VerifySpaceOutFactorOne()
		{
			var result = new GalaxyParsingResult(
				[new(1, 1), new(5, 8), new(0, 0)],
				[0, 1, 2],
				[2, 5, 9]
			);

			var spacedOut = Day11.SpaceOut(result, 2);

			Assert.AreEqual(new Coordinate(2, 1), spacedOut[0]);
			Assert.AreEqual(new Coordinate(8, 10), spacedOut[1]);
			Assert.AreEqual(new Coordinate(0, 0), spacedOut[2]);
		}

		[TestMethod]
		public void VerifySpaceOutFactorMillion()
		{
			var result = new GalaxyParsingResult(
				[new(1, 1), new(5, 8), new(0, 0)],
				[0, 1, 2],
				[2, 5, 9]
			);
			var oneMillion = 1_000_000;

			var spacedOut = Day11.SpaceOut(result, oneMillion + 1);

			Assert.AreEqual(new Coordinate(oneMillion + 1, 1), spacedOut[0]);
			Assert.AreEqual(new Coordinate(3 * oneMillion + 5, 2 * oneMillion + 8), spacedOut[1]);
			Assert.AreEqual(new Coordinate(0, 0), spacedOut[2]);
		}


		[TestMethod]
		public void VerifyFirstProblem()
		{
			var converted = Day11.Convert(data);

			Assert.AreEqual(374, Day11.FirstProblem(converted));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var converted = Day11.Convert(data);

			Assert.AreEqual(82000210, Day11.SecondProblem(converted));
		}

		[TestMethod]
		public void VerifyCoreAlgorithmFactor10()
		{
			var converted = Day11.Convert(data);

			Assert.AreEqual(1030, Day11.CoreAlgorithm(converted, 10));
		}
		
		[TestMethod]
		public void VerifyCoreAlgorithmFactor100()
		{
			var converted = Day11.Convert(data);

			Assert.AreEqual(8410, Day11.CoreAlgorithm(converted, 100));
		}
	}
}
