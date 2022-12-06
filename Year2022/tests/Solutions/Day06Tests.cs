using AdventOfCode.Year2022.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode.Year2022.Tests.Solutions
{
	[TestClass]
	public class Day06Tests
	{
		[TestMethod]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
		public void VerifyFirstProblem(string data, int expected)
		{
			var result = Day06.FirstProblem(new string[] { data });

			Assert.AreEqual(expected, result);
		}

		[TestMethod]
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
		public void VerifySecondProblem(string data, int expected)
		{
			var result = Day06.SecondProblem(new string[] { data });

			Assert.AreEqual(expected, result);
		}
	}
}
