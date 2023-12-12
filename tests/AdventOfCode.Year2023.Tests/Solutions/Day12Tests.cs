using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day12Tests
	{
		[TestMethod]
		public void VerifySatisfiesCriteriaPositiveCase()
		{
			Assert.IsTrue(Day12.SatisfiesCriteria(".###.##.#...", [3, 2, 1]));
			Assert.IsTrue(Day12.SatisfiesCriteria(".###.##..#..", [3, 2, 1]));
			Assert.IsTrue(Day12.SatisfiesCriteria(".###....##.#", [3, 2, 1]));
			Assert.IsTrue(Day12.SatisfiesCriteria(".#.#.#.#.#", [1, 1, 1, 1, 1]));
		}

		[TestMethod]
		public void VerifySatisfiesCriteriaNegativeCase()
		{
			Assert.IsFalse(Day12.SatisfiesCriteria(".#####.#...", [3, 2, 1]));
			Assert.IsFalse(Day12.SatisfiesCriteria(".###.##..#.#", [3, 2, 1]));
			Assert.IsFalse(Day12.SatisfiesCriteria(".#.#.#.#.#", [1, 1, 1, 1]));
		}

		[TestMethod]
		public void VerifyGeneratePermutationsOneVariable()
		{
			var permutations = Day12.GeneratePermutations("?.#.#.#.#.#", 1000);
			Assert.AreEqual(2, permutations.Count());
			Assert.IsTrue(permutations.Contains("..#.#.#.#.#"));
			Assert.IsTrue(permutations.Contains("#.#.#.#.#.#"));
		}

		[TestMethod]
		public void VerifyGeneratePermutationsTwoVariables()
		{
			var permutations = Day12.GeneratePermutations("?.?#.#.#.#.#", 1000);
			Assert.AreEqual(4, permutations.Count());
			Assert.IsTrue(permutations.Contains("...#.#.#.#.#"));
			Assert.IsTrue(permutations.Contains("..##.#.#.#.#"));
			Assert.IsTrue(permutations.Contains("#..#.#.#.#.#"));
			Assert.IsTrue(permutations.Contains("#.##.#.#.#.#"));
		}

		[TestMethod]
		public void VerifyGeneratePermutationsTwoVariablesOnlyOneSpring()
		{
			var permutations = Day12.GeneratePermutations("?.?#.#.#.#.#", 1);
			Assert.AreEqual(2, permutations.Count());
			Assert.IsTrue(permutations.Contains("..##.#.#.#.#"));
			Assert.IsTrue(permutations.Contains("#..#.#.#.#.#"));
		}

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
	}
}
