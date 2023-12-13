using AdventOfCode.Common.DataStructures;
using AdventOfCode.Common.Extensions;
using AdventOfCode.Year2016.Model;
using System.Linq;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day24
    {
        public static char[][] Convert(string[] data) => data.Select(x => x.ToCharArray()).ToArray();

        public static Coordinate[] GetNumberPositions(char[][] data)
        {
            var largestNumber = data.SelectMany(x => x).Where(x => int.TryParse(x.ToString(), out var num)).Select(x => int.Parse(x.ToString())).ToArray().Max();

            var positions = new Coordinate[largestNumber + 1];

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    if (int.TryParse(data[i][j].ToString(), out var num))
                    {
                        positions[num] = new(i, j);
                    }
                }
            }
            return positions;
        }

        public static long FirstProblem(char[][] maze)
        {
            return CoreAlgorithm(maze, false);
        }

        public static long SecondProblem(char[][] maze)
        {
            return CoreAlgorithm(maze, true);
        }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "We need 2 dimensional grids")]
		private static int CoreAlgorithm(char[][] maze, bool returnToZero)
        {
            var graph = new MazeGraph(maze);

            var positions = GetNumberPositions(maze);
            var distanceMatrix = new int[positions.Length, positions.Length];

            for (var i = 0; i < positions.Length; i++)
            {
                for (var j = 0; j < positions.Length; j++)
                {
                    distanceMatrix[i, j] = graph.CalculateDistance(positions[i], positions[j]);
                }
            }

            var permutations = SetUtils.GetPermutations(Enumerable.Range(1, positions.Length - 1), positions.Length - 1).ToArray();

            var min = int.MaxValue;
            for (var i = 0; i < permutations.Length; i++)
            {
                var count = distanceMatrix[0, permutations[i].First()];
                for (var j = 0; j < permutations[i].Count() - 1; j++)
                {
                    count += distanceMatrix[permutations[i].ElementAt(j), permutations[i].ElementAt(j + 1)];
                }
                if (returnToZero)
                {
                    count += distanceMatrix[permutations[i].Last(), 0];
                }
                if (count < min)
                {
                    min = count;
                }
            }
            return min;
        }
    }
}
