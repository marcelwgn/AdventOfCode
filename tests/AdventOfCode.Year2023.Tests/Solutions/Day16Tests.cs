using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day16Tests
	{
		private static readonly string[] field = [
			".|...\\....",
			"|.-.\\.....",
			".....|-...",
			"........|.",
			"..........",
			".........\\",
			"..../.\\\\..",
			".-.-/..|..",
			".|....-|.\\",
			"..//.|....",
		];

		[TestMethod]
		public void VerifyFirstProblem()
		{
			Assert.AreEqual(46, Day16.FirstProblem(field));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			Assert.AreEqual(51, Day16.SecondProblem(field));
		}
	}
}
