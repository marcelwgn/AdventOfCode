using AdventOfCode.Common.DataStructures;
using System.Data.Common;
using System.Diagnostics;

namespace AdventOfCode.Year2023.Solutions
{
	public static class Day17
	{
		private record Path(Coordinate Position, Coordinate Direction, int TotalLoss, int StepsRun);

		public static long FirstProblem(string[] data)
		{
			return MinimumPathLength(data, 0, 3);
		}

		public static long SecondProblem(string[] data)
		{
			return MinimumPathLength(data, 4, 10);
		}

		public static long MinimumPathLength(string[] data, int minStepsInSingleDirection, int maxStepsInSingleDirection)
		{
			var paths = new HashSet<Path>();
			var firstPath = new Path(new(0, 0), Coordinate.East, 0, 1);
			var secondFirstPath = new Path(new(0, 0), Coordinate.South, 0, 1);
			paths.Add(firstPath);
			paths.Add(secondFirstPath);
			var finalPosition = new Coordinate(data[0].Length - 1, data.Length - 1);

			var visitedPositions = new Dictionary<string, int>();

			var currentLowest = int.MaxValue;
			while (paths.Count != 0)
			{
				var curPath = paths.First();
				foreach (var entry in paths)
				{
					if (entry.TotalLoss < curPath.TotalLoss)
					{
						curPath = entry;
					}
				}

				paths.Remove(curPath);

				// Check if this path will never become better
				if (CanSkipPath(curPath, visitedPositions, currentLowest, maxStepsInSingleDirection))
				{
					continue;
				}

				// Winning condition, no need to branch off
				if (curPath.Position == finalPosition && curPath.StepsRun >= minStepsInSingleDirection - 1)
				{
					currentLowest = Math.Min(currentLowest, curPath.TotalLoss);
					continue;
				}

				var possibleDirections = GetPossibleDirection(curPath, minStepsInSingleDirection, maxStepsInSingleDirection);

				foreach (var (NewDirection, StepsRan) in possibleDirections)
				{
					var newPosition = curPath.Position + NewDirection;

					// If outside, ignore
					if (!newPosition.IsInGrid(data)) continue;

					var loss = int.Parse(data.Get(newPosition).ToString()) + curPath.TotalLoss;
					var newPath = new Path(newPosition, NewDirection, loss, StepsRan);

					var visitedPositionsEntry = GetPositionKey(newPath);

					// Check if someone else with a better score visited this position
					var hasExistingLoss = visitedPositions.TryGetValue(visitedPositionsEntry, out var existingLoss);
					if (hasExistingLoss)
					{
						if (loss > existingLoss)
						{
							continue;
						}
						else
						{
							visitedPositions[visitedPositionsEntry] = loss;
						}
					}
					else
					{
						visitedPositions.Add(visitedPositionsEntry, loss);
					}
					paths.Add(newPath);
				}
			}

			return currentLowest;
		}

		private static string GetPositionKey(Path path)
		{
			return $"{path.Position.X},{path.Position.Y},{path.Direction.X},{path.Direction.Y},{path.StepsRun}";
		}

		private static List<(Coordinate NewDirection, int StepsRan)> GetPossibleDirection(Path path, int minStepsInSingleDirection, int maxStepsInSingleDirection)
		{
			var possibleDirections = new List<(Coordinate, int)>();

			// We need to move a certain number of steps before we can turn
			// So turning is not available until 
			if (path.StepsRun >= minStepsInSingleDirection)
			{
				if (path.Direction.Y != 0)
				{
					possibleDirections.Add((Coordinate.East, 1));
					possibleDirections.Add((Coordinate.West, 1));
				}
				else
				{
					possibleDirections.Add((Coordinate.North, 1));
					possibleDirections.Add((Coordinate.South, 1));
				}
			}

			if (path.StepsRun < maxStepsInSingleDirection)
			{
				possibleDirections.Add((path.Direction, path.StepsRun + 1));
			}
			return possibleDirections;
		}

		private static bool CanSkipPath(Path path, Dictionary<string, int> visitedPositions, long lowestSolution, int maxStepsInSingleDirection)
		{
			if (path.TotalLoss > lowestSolution * 2) return true;
			if (path.StepsRun > maxStepsInSingleDirection + 15) return true;

			var visitedKey = GetPositionKey(path);
			if (visitedPositions.TryGetValue(visitedKey, out var value) && path.TotalLoss > value + 5) return true;

			return false;
		}
	}
}
