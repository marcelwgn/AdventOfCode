using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
    [TestClass]
	public class Day01Tests
	{
		[TestMethod]
		public void VerifyFirstProblem()
		{
			var testData = "1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet".Split("\r\n");

			Assert.AreEqual(142, Day01.FirstProblem(testData));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var testData = "two1nine\r\neightwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen".Split("\r\n");

			Assert.AreEqual(281, Day01.SecondProblem(testData));
		}
	}
}
