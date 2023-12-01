using System.Globalization;

namespace AdventOfCode.Year2023.Solutions
{
	public static class Day01
	{
		private static Tuple<int, string>[] NUMBERS = [ 
			Tuple.Create(1, "one"),
			Tuple.Create(2, "two"),
			Tuple.Create(3, "three"),
			Tuple.Create(4, "four"),
			Tuple.Create(5, "five"),
			Tuple.Create(6, "six"),
			Tuple.Create(7, "seven"),
			Tuple.Create(8, "eight"),
			Tuple.Create(9, "nine")
		];

		public static int FirstProblem(string[] input)
		{
			return input.Select(x => GetNumberForRowUsingDigits(x)).Sum();
		}

		public static int SecondProblem(string[] input)
		{
			return input.Select(x => GetNumberForRowUsingDigitAndName(x)).Sum();
		}

		private static int GetNumberForRowUsingDigits(string input)
		{
			var firstNumber = input.First(char.IsNumber);
			var secondNumber = input.Last(char.IsNumber);
			// Subtracting 48 since they are chars and the 0 digit in ASCII is 48.
			return (firstNumber - 48)* 10 + secondNumber - 48;
		}

		private static int GetNumberForRowUsingDigitAndName(string input)
		{
			// Subtracting 48 since they are chars and the 0 digit in ASCII is 48.
			var result = FindFirstEntry() * 10 + FindFirstEntry(true);
			return result;

			int FindFirstEntry(bool fromEnd = false)
			{
				for (int i = 0; i < input.Length; i++)
				{
					var positionInString = fromEnd == false ? i : input.Length - i - 1;
					if (char.IsNumber(input[positionInString]))
					{
						return input[positionInString] - 48;
					}

					var currentStringToEnd = input[positionInString..];
					for (int j = 0; j < NUMBERS.Length; j++)
					{
						if (currentStringToEnd.StartsWith(NUMBERS[j].Item2))
							return NUMBERS[j].Item1;
					}
				}
				return -1;
			}
		}
	}
}
