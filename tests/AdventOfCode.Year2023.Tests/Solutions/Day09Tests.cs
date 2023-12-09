using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day09Tests
	{
		private readonly string[] data =
		[
			"0 3 6 9 12 15",
			"1 3 6 10 15 21",
			"10 13 16 21 30 45"
		];



		[TestMethod]
		public void VerifyConvert()
		{
			var expected = new int[][]
			{
				[0, 3, 6, 9, 12, 15],
				[1, 3, 6, 10, 15, 21],
				[10, 13, 16, 21, 30, 45]
			};

			var actual = Day09.Convert(data);

			Assert.AreEqual(expected.Length, actual.Length);
			for(int i = 0; i < expected.Length; i++)
			{
				CollectionAssert.AreEqual(expected[i], actual[i]);
			}
		}

		[TestMethod]
		public void VerifyFirstProblem()
		{
			var parsed = Day09.Convert(data);

			Assert.AreEqual(114, Day09.FirstProblem(parsed));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var parsed = Day09.Convert(data);

			Assert.AreEqual(2, Day09.SecondProblem(parsed));
		}
	}
}
