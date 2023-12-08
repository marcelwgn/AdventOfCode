using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day08Tests
	{
		private readonly static string[] dataFirstProblemNonRepeating = [
			"RL",
			"",
			"AAA = (BBB, CCC)",
			"BBB = (DDD, EEE)",
			"CCC = (ZZZ, GGG)",
			"DDD = (DDD, DDD)",
			"EEE = (EEE, EEE)",
			"GGG = (GGG, GGG)",
			"ZZZ = (ZZZ, ZZZ)",
		];

		private readonly static string[] dateFirstProblemRepeating = [
			"LLR",
			"",
			"AAA = (BBB, BBB)",
			"BBB = (AAA, ZZZ)",
			"ZZZ = (ZZZ, ZZZ)",
		];

		private readonly static string[] dataSecondProblem = [
			"LR",
			"",
			"11A = (11B, XXX)",
			"11B = (XXX, 11Z)",
			"11Z = (11B, XXX)",
			"22A = (22B, XXX)",
			"22B = (22C, 22C)",
			"22C = (22Z, 22Z)",
			"22Z = (22B, 22B)",
			"XXX = (XXX, XXX)",
		];

		[TestMethod]
		public void VerifyConvert()
		{
			var parsed = Day08.Convert(dataFirstProblemNonRepeating);

			Assert.AreEqual("RL", parsed.Instructions);
			Assert.AreEqual("AAA", parsed.FirstNode);
			Assert.AreEqual("BBB", parsed.Nodes["AAA"].Left);
			Assert.AreEqual("CCC", parsed.Nodes["AAA"].Right);
		}

		[TestMethod]
		public void VerifyFirstProblemNonRepeating()
		{
			var parsed = Day08.Convert(dataFirstProblemNonRepeating);

			Assert.AreEqual(2, Day08.FirstProblem(parsed));
		}

		[TestMethod]
		public void VerifyFirstProblemRepeating()
		{
			var parsed = Day08.Convert(dateFirstProblemRepeating);

			Assert.AreEqual(6, Day08.FirstProblem(parsed));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var parsed = Day08.Convert(dataSecondProblem);

			Assert.AreEqual(6, Day08.SecondProblem(parsed));
		}
	}
}
