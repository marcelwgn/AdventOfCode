using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2023.Solutions;

public record GalaxyParsingResult(Coordinate[] Coordinates, long[] XGaps, long[] YGaps);

public static class Day11
{

    public static GalaxyParsingResult Convert(string[] data)
    {
        var xGaps = Enumerable.Range(0, data[0].Length).Where(index => data.All(x => x[index] == '.')).Select(x => (long)x);
        var yGaps = Enumerable.Range(0, data.Length).Where(index => data[index].All(x => x == '.')).Select(x => (long)x);

        var coordinates = new HashSet<Coordinate>();

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var coordinate = new Coordinate(j, i);
                if (data.Get(coordinate) == '#')
                {
                    coordinates.Add(coordinate);
                }
            }
        }

        return new GalaxyParsingResult(coordinates.ToArray(), xGaps.ToArray(), yGaps.ToArray());
    }

    public static long FirstProblem(GalaxyParsingResult result)
    {
        return CoreAlgorithm(result, 2);
    }

    public static long SecondProblem(GalaxyParsingResult result)
    {
        return CoreAlgorithm(result, 1_000_000);
    }

    public static Coordinate[] SpaceOut(GalaxyParsingResult result, long factor)
    {
        var actualFactor = factor - 1; // Reducing by one since it is already applied once
        var newCoordinates = new Coordinate[result.Coordinates.Length];
        for (int i = 0; i < result.Coordinates.Length; i++)
        {
            var coordinate = result.Coordinates[i];
            var xGapsApplicable = result.XGaps.Count(x => coordinate.X > x);
            var yGapsApplicable = result.YGaps.Count(y => coordinate.Y > y);
            newCoordinates[i] = new Coordinate(coordinate.X + actualFactor * xGapsApplicable, coordinate.Y + actualFactor * yGapsApplicable);
        }
        return newCoordinates;
    }

    public static long CoreAlgorithm(GalaxyParsingResult result, long scalingFactor)
    {
        var coordinates = SpaceOut(result, scalingFactor);

        var sum = 0L;
        for (int i = 0; i < coordinates.Length; i++)
        {
            var current = coordinates[i];
            for (int j = 0; j < i; j++)
            {
                var target = coordinates[j];
                sum += Math.Abs(current.X - target.X) + Math.Abs(current.Y - target.Y);
            }
        }
        return sum;
    }
}
