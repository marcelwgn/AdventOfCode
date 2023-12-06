namespace AdventOfCode.Year2023.Solutions
{
	public class RGBSampleResult
	{
		public int Red { get; set; }
		public int Green { get; set; }
		public int Blue { get; set; }
	}
	public class CubeGameState
	{
		public int Id { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
		public List<RGBSampleResult> Samples { get; } = [];
	}

	public static class Day02
	{
		public static CubeGameState[] Convert(string[] data)
		{
			var cubeGameStates = new CubeGameState[data.Length];

			for (int i = 0; i < data.Length; i++)
			{
				var endOfNumber = data[i].IndexOf(':', StringComparison.InvariantCulture);
				var gameId = int.Parse(data[i][5..endOfNumber]);
				var cubeGameState = new CubeGameState
				{
					Id = gameId
				};

				var samples = data[i][(endOfNumber + 2)..].Replace(",", "").Split("; ");
				foreach (var sample in samples)
				{
					var sampleResult = new RGBSampleResult();
					var split = sample.Split(" ");
					for (int splitIndex = 0; splitIndex < split.Length; splitIndex += 2)
					{
						var number = int.Parse(split[splitIndex]);
						switch (split[splitIndex + 1])
						{
							case "red":
								sampleResult.Red += number;
								break;
							case "green":
								sampleResult.Green += number;
								break;
							case "blue":
								sampleResult.Blue += number;
								break;
						}
					}
					cubeGameState.Samples.Add(sampleResult);
				}
				cubeGameStates[i] = cubeGameState;
			}
			return cubeGameStates;
		}

		public static int FirstProblem(CubeGameState[] cubeGameStates)
		{
			return cubeGameStates.Where(x => x.Samples.All(sample => sample.Red <= 12 && sample.Green <= 13 && sample.Blue <= 14)).Sum(x => x.Id);
		}

		public static int SecondProblem(CubeGameState[] cubeGameStates)
		{
			return cubeGameStates.Sum(GetPowerOfMinimalSet);

			static int GetPowerOfMinimalSet(CubeGameState cubeGameState)
			{

				var minRed = cubeGameState.Samples.Max(x => x.Red);
				var minGreen = cubeGameState.Samples.Max(x => x.Green);
				var minBlue = cubeGameState.Samples.Max(x => x.Blue);

				return minRed * minGreen * minBlue;
			}
		}
	}
}
