using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day17Tests
	{
		private static readonly string[] field = [
			"2413432311323",
			"3215453535623",
			"3255245654254",
			"3446585845452",
			"4546657867536",
			"1438598798454",
			"4457876987766",
			"3637877979653",
			"4654967986887",
			"4564679986453",
			"1224686865563",
			"2546548887735",
			"4322674655533",
		];

		private static readonly string[] fieldSecondProblem = [
				"111111111111",
				"999999999991",
				"999999999991",
				"999999999991",
				"999999999991",
			];

		[TestMethod]
		public void VerifyFirstProblem()
		{
			Assert.AreEqual(102, Day17.FirstProblem(field));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			Assert.AreEqual(94, Day17.SecondProblem(field));
		}

		[TestMethod]
		public void VerifySecondProblemSecondField()
		{
			Assert.AreEqual(63, Day17.SecondProblem(fieldSecondProblem));
		}
	}
}
