using AdventOfCode.Year2022.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2022.Tests.Solutions
{
	[TestClass]
	public class Day02Tests
	{

		[TestMethod]
		public void VerifyFirstProblem()
		{
			var numbers = new string[]
			{
                "A Y",
                "B X",
                "C Z",
			};

			Assert.AreEqual(15, Day02.FirstProblem(numbers));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var numbers = new string[]
			{
                "A Y",
                "B X",
                "C Z",
			};

			Assert.AreEqual(12, Day02.SecondProblem(numbers));
		}
	}
}
