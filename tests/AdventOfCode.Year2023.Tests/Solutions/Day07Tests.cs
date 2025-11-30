using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day07Tests
	{

		private readonly static string[] data = [
			"32T3K 765",
			"T55J5 684",
			"KK677 28",
			"KTJJT 220",
			"QQQJA 483"
		];

		[TestMethod]
		public void VerifyConvert()
		{
			var parsed = Day07.Convert(data).ToArray();

			Assert.HasCount(5, parsed);

			Assert.AreEqual(5, parsed[0].ScoreNormal);
			Assert.AreEqual(7, parsed[1].ScoreNormal);
			Assert.AreEqual(6, parsed[2].ScoreNormal);
			Assert.AreEqual(6, parsed[3].ScoreNormal);
			Assert.AreEqual(7, parsed[4].ScoreNormal);

			Assert.AreEqual(5, parsed[0].ScoreJokerRules);
			Assert.AreEqual(9, parsed[1].ScoreJokerRules);
			Assert.AreEqual(6, parsed[2].ScoreJokerRules);
			Assert.AreEqual(9, parsed[3].ScoreJokerRules);
			Assert.AreEqual(9, parsed[4].ScoreJokerRules);
		}

		[TestMethod]
		public void VerifyHandOrderingNormalRules()
		{
			var parsed = Day07.Convert(data).OrderDescending(new CamelHandNormalRulesComperator()).ToArray();

			Assert.AreEqual(483, parsed[0].Bid);
			Assert.AreEqual(684, parsed[1].Bid);
			Assert.AreEqual(28, parsed[2].Bid);
			Assert.AreEqual(220, parsed[3].Bid);
			Assert.AreEqual(765, parsed[4].Bid);
		}
		
		[TestMethod]
		public void VerifyHandOrderingJokerRules()
		{
			var parsed = Day07.Convert(data).OrderDescending(new CamelHandJokerRulesComperator()).ToArray();

			Assert.AreEqual(220, parsed[0].Bid);
			Assert.AreEqual(483, parsed[1].Bid);
			Assert.AreEqual(684, parsed[2].Bid);
			Assert.AreEqual(28, parsed[3].Bid);
			Assert.AreEqual(765, parsed[4].Bid);
		}

		[TestMethod]
		public void VerifyFirstProblem()
		{
			var parsed = Day07.Convert(data);

			Assert.AreEqual(6440, Day07.FirstProblem(parsed));
		}
		
		[TestMethod]
		public void VerifySecondProblem()
		{
			var parsed = Day07.Convert(data);

			Assert.AreEqual(5905, Day07.SecondProblem(parsed));
		}
	}
}
