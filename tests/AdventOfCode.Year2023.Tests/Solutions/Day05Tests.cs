using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
    [TestClass]
	public class Day05Tests
	{

		private readonly string[] data = [
			"seeds: 79 14 55 13",
			"",
			"seed-to-soil map:",
			"50 98 2",
			"52 50 48",
			"",
			"soil-to-fertilizer map:",
			"0 15 37",
			"37 52 2",
			"39 0 15",
			"",
			"fertilizer-to-water map:",
			"49 53 8",
			"0 11 42",
			"42 0 7",
			"57 7 4",
			"",
			"water-to-light map:",
			"88 18 7",
			"18 25 70",
			"",
			"light-to-temperature map:",
			"45 77 23",
			"81 45 19",
			"68 64 13",
			"",
			"temperature-to-humidity map:",
			"0 69 1",
			"1 0 69",
			"",
			"humidity-to-location map:",
			"60 56 37",
			"56 93 4",
		];

		[TestMethod]
		public void VerifyConvert()
		{
			long[] expectedSeeds = [79, 14, 55, 13];

			var converted = Day05.Convert(data);

			CollectionAssert.AreEqual(expectedSeeds, converted.Seeds);
			
			Assert.HasCount(7, converted.Mappers);
			Assert.AreEqual(50, converted.Mappers[0].GetMapped(98));
			Assert.AreEqual(51, converted.Mappers[0].GetMapped(99));
			Assert.AreEqual(100, converted.Mappers[0].GetMapped(100));
		}

		[TestMethod]
		public void VerifyFirstProblem()
		{
			var converted = Day05.Convert(data);

			Assert.AreEqual(35, Day05.FirstProblem(converted));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var converted = Day05.Convert(data);

			Assert.AreEqual(46, Day05.SecondProblem(converted));
		}
	}
}
