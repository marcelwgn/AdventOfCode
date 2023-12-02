namespace AdventOfCode.Year2023.Solutions
{
	public static class Day01
	{
		private static readonly (int Digit, string Name)[] NUMBERS = [
			(1, "one"),
			(2, "two"),
			(3, "three"),
			(4, "four"),
			(5, "five"),
			(6, "six"),
			(7, "seven"),
			(8, "eight"),
			(9, "nine")
		];

		public static int FirstProblem(string[] input)
		{
			return input.Select(GetNumberForRowUsingDigits).Sum();
		}

		public static int SecondProblem(string[] input)
		{
			return input.Select(GetNumberForRowUsingDigitAndName).Sum();
		}

		private static int GetNumberForRowUsingDigits(string input)
		{
			var firstNumber = input.First(char.IsNumber);
			var secondNumber = input.Last(char.IsNumber);
			// Subtracting 48 since they are chars and the 0 digit in ASCII is 48.
			return (firstNumber - 48) * 10 + secondNumber - 48;
		}

		private static int GetNumberForRowUsingDigitAndName(string input)
		{
			// Subtracting 48 since they are chars and the 0 digit in ASCII is 48.
			var result = FindFirstNumber() * 10 + FindFirstNumber(true);
			return result;

			int FindFirstNumber(bool fromEnd = false)
			{
				for (int i = 0; i < input.Length; i++)
				{
					var positionInString = fromEnd == false ? i : input.Length - i - 1;
					if (char.IsNumber(input[positionInString]))
					{
						return input[positionInString] - 48;
					}

					var currentStringToEnd = input[positionInString..];
					var (Digit, Name) = NUMBERS.Where(x => currentStringToEnd.StartsWith(x.Name, StringComparison.InvariantCulture)).FirstOrDefault((Digit: -1, Name: ""));
					if (Digit != -1)
					{
						return Digit;
					}
				}
				return -1;
			}
		}
	}
}
