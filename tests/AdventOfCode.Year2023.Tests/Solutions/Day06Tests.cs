using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
    [TestClass]
	public class Day06Tests
	{
		private readonly string[] data = ["Time:      7  15   30", "Distance:  9  40  200"];


		[TestMethod]
		public void VerifyConvert()
		{
			var parsed = Day06.Convert(data);

			Assert.HasCount(3, parsed.Times);
			Assert.HasCount(3, parsed.Distances);
			Assert.AreEqual(7, parsed.Times[0]);
			Assert.AreEqual(9, parsed.Distances[0]);
		}

		[TestMethod]
		public void VerifyFirstProblem()
		{
			var parsed = Day06.Convert(data);

			Assert.AreEqual(288, Day06.FirstProblem(parsed));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var parsed = Day06.Convert(data);

			Assert.AreEqual(71503, Day06.SecondProblem(parsed));
		}
	}
}
