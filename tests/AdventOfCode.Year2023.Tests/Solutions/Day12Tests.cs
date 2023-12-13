using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day12Tests
	{
		[TestMethod]
		public void VerifyFirstProblem()
		{
			string[] data = [
				"???.### 1,1,3",
				".??..??...?##. 1,1,3",
				"?#?#?#?#?#?#?#? 1,3,1,6",
				"????.#...#... 4,1,1",
				"????.######..#####. 1,6,5",
				"?###???????? 3,2,1",
			];

			Assert.AreEqual(21, Day12.FirstProblem(data));
		}
		
		[TestMethod]
		public void VerifySecondProblem()
		{
			string[] data = [
				"???.### 1,1,3",
				".??..??...?##. 1,1,3",
				"?#?#?#?#?#?#?#? 1,3,1,6",
				"????.#...#... 4,1,1",
				"????.######..#####. 1,6,5",
				"?###???????? 3,2,1",
			];

			Assert.AreEqual(525152, Day12.SecondProblem(data));
		}
	}
}
