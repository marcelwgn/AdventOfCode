namespace AdventOfCode.Year2023.Solutions
{
	public static class Day12
	{
		public static int FirstProblem(string[] data)
		{
			var totalSum = 0;
			foreach (var item in data)
			{
				var split = item.Split(" ");
				var criteria = split[1].Split(',').Select(int.Parse).ToArray();
				totalSum += CalculateArrangements(split[0], criteria);
			}
			return totalSum;
		}

		public static long SecondProblem(string[] data)
		{
			var totalSum = 0;
			foreach (var item in data)
			{
				var split = item.Split(" ");
				var sequenceTimesFive = string.Concat(Enumerable.Repeat(split[0], 5));
				var criteriaTimesFive = string.Concat(Enumerable.Repeat(split[1], 5));
				var criteria = criteriaTimesFive.Split(',').Select(int.Parse).ToArray();
				totalSum += CalculateArrangements(sequenceTimesFive, criteria);
			}
			return totalSum;
		}

		public static bool SatisfiesCriteria(string data, int[] criteria)
		{
			var split = data.Split('.').Where(x => x.Length > 0).ToArray();
			if (split.Length != criteria.Length)
			{
				return false;
			}

			for (var i = 0; i < split.Length; i++)
			{
				if (split[i].Length != criteria[i])
				{
					return false;
				}
			}
			return true;
		}

		private static readonly HashSet<string> emptyHashset = [];

		public static HashSet<string> GeneratePermutations(string data, int maxSprings)
		{
			var firstIndex = data.IndexOf('?');
			if (firstIndex == -1)
			{
				if (maxSprings == 0)
				{
					return [data];
				}
				else
				{
					return emptyHashset;
				}
			}
			if (maxSprings == 0)
			{
				return [data.Replace('?', '.')];
			}
			return new HashSet<string>(GeneratePermutations(string.Concat(data.AsSpan(0, firstIndex), ".", data.AsSpan(firstIndex + 1)), maxSprings - 1)
				.Concat(GeneratePermutations(string.Concat(data.AsSpan(0, firstIndex), "#", data.AsSpan(firstIndex + 1)), maxSprings - 1)));
		}

		private static int CalculateArrangements(string sequence, int[] criteria)
		{
			var permutations = GeneratePermutations(sequence, criteria.Sum());
			return permutations.Count(x => SatisfiesCriteria(x, criteria));
		}
	}
}
