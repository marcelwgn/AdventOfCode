using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2022.Solutions;

public static class Day09
{

    public static long FirstProblem(string[] data)
    {
        return CoreAlgorithm(data, 2);
    }
    public static long SecondProblem(string[] data)
    {
        return CoreAlgorithm(data, 10);
    }

    private static long CoreAlgorithm(string[] data, int ropeLength)
    {
        var xPositions = new int[ropeLength];
        var yPositions = new int[ropeLength];

        var positions = new HashSet<Coordinate>() { new(0, 0) };
        foreach (var item in data)
        {
            var split = item.Split(" ");
            var direction = split[0];
            var distance = int.Parse(split[1]);
            for (int i = 0; i < distance; i++)
            {
                var deltas = direction switch
                {
                    "U" => (0, 1),
                    "D" => (0, -1),
                    "L" => (-1, 0),
                    "R" => (1, 0),
                    _ => (0, 0)
                };
                ProcessHeadMovement(deltas.Item1, deltas.Item2);
            }
        }
        return positions.Count;

        void ProcessHeadMovement(int xDelta, int yDelta)
        {
            xPositions[0] += xDelta;
            yPositions[0] += yDelta;

            for (int i = 1; i < xPositions.Length; i++)
            {
                ProcessSuccessorMovement(i);
            }
            positions!.Add(new(xPositions[^1], yPositions[^1]));

            void ProcessSuccessorMovement(int entry)
            {
                var xDelta = Math.Abs(xPositions![entry - 1] - xPositions[entry]);
                var yDelta = Math.Abs(yPositions![entry - 1] - yPositions[entry]);

                if (xDelta >= 2 || yDelta >= 2)
                {
                    xPositions[entry] += Math.Sign(xPositions![entry - 1] - xPositions[entry]) * Math.Min(1, xDelta);
                    yPositions[entry] += Math.Sign(yPositions![entry - 1] - yPositions[entry]) * Math.Min(1, yDelta);
                }
            }
        }
    }
}
