using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2023.Solutions
{
	public class Raffle
	{
		public int Id { get; set; }
		public IEnumerable<int> WinningNumbers { get; set; }
		public IEnumerable<int> DrawnNumbers { get; set; }
	}

	public static class Day04
	{
		public static Raffle[] Convert(string[] data)
		{
			return data.Select(ConvertToRaffle).ToArray();

			static Raffle ConvertToRaffle(string game)
			{
				var split = game.Split(" ").Where(x => x.Length > 0).ToArray();
				var barEntry = Array.IndexOf(split, "|");
				return new Raffle()
				{
					Id = int.Parse(split[1][..^1]),
					WinningNumbers = split[2..barEntry].Select(int.Parse).ToHashSet(),
					DrawnNumbers = split[(barEntry + 1)..].Select(int.Parse)
				};
			}
		}

		public static int FirstProblem(Raffle[] raffles)
		{
			return raffles.Select(x => (int)Math.Pow(2, GetMatchingNumberCount(x) - 1)).Sum();

		}

		public static int SecondProblem(Raffle[] raffles)
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

		private static int GetMatchingNumberCount(Raffle raffle)
		{
			return raffle.DrawnNumbers.Where(dn => raffle.WinningNumbers.Contains(dn)).Count();
		}
	}
}
