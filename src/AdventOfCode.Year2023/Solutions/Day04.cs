namespace AdventOfCode.Year2023.Solutions
{
	public record Day04Raffle(int Id, IEnumerable<int> WinningNumbers, IEnumerable<int> DrawnNumbers);

	public static class Day04
	{
		public static Day04Raffle[] Convert(string[] data)
		{
			return data.Select(ConvertToRaffle).ToArray();

			static Day04Raffle ConvertToRaffle(string game)
			{
				var split = game.Split(" ").Where(x => x.Length > 0).ToArray();
				var barEntry = Array.IndexOf(split, "|");
				return new Day04Raffle(int.Parse(split[1][..^1]), split[2..barEntry].Select(int.Parse).ToHashSet(), split[(barEntry + 1)..].Select(int.Parse));
			}
		}

		public static int FirstProblem(Day04Raffle[] raffles)
		{
			return raffles.Select(x => (int)Math.Pow(2, GetMatchingNumberCount(x) - 1)).Sum();

		}

		public static int SecondProblem(Day04Raffle[] raffles)
		{
			var copyCount = new Dictionary<int, int>();
			for (int i = 0; i < raffles.Length; i++)
			{
				var score = GetMatchingNumberCount(raffles[i]);
				var currentCopyCount = copyCount.GetValueOrDefault(i) + 1;
				for (int j = 1; j <= score && j + i < raffles.Length; j++)
				{
					copyCount[i + j] = copyCount.GetValueOrDefault(i + j) + currentCopyCount;
				}
			}
			return copyCount.Values.Sum() + raffles.Length;
		}

		private static int GetMatchingNumberCount(Day04Raffle raffle)
		{
			return raffle.DrawnNumbers.Where(dn => raffle.WinningNumbers.Contains(dn)).Count();
		}
	}
}
