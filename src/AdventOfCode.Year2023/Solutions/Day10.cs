using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2023.Solutions;

public static class Day10
{

    public static int FirstProblem(string[] data)
    {
        return CalculatePath(data).Count / 2;
    }

    public static long SecondProblem(string[] data)
    {
        // General idea: Supersample the path so we can squeeze between walls

        var path = CalculatePath(data);
        var nextPositions = new Queue<Coordinate>();
        var superSampled = new char[data.Length * 3][];
        var visited = new HashSet<Coordinate>();

        // Create char array clone so we can write individual cells
        for (int i = 0; i < superSampled.Length; i++)
        {
            superSampled[i] = new char[data[0].Length * 3];
        }

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                FillArray(j, i);
            }
        }

        for (int i = 0; i < superSampled.Length; i++)
        {
            EnqueueIfNotOnPath(new Coordinate(0, i));
            EnqueueIfNotOnPath(new Coordinate(superSampled[0].Length - 1, i));
        }
        for (int i = 1; i < superSampled.Length; i++)
        {
            EnqueueIfNotOnPath(new Coordinate(i, 0));
            EnqueueIfNotOnPath(new Coordinate(i, superSampled.Length - 1));
        }

        while (nextPositions.Count > 0)
        {
            var currentCoordinate = nextPositions.Dequeue();

            if (visited.Contains(currentCoordinate) || !currentCoordinate.IsInGrid(superSampled))
            {
                continue;
            }

            visited.Add(currentCoordinate);

            // Ignoring anything that would be a path
            if (superSampled.Get(currentCoordinate) == 'X')
            {
                continue;
            }

            superSampled.Set(currentCoordinate, '0');

            var nextSteps = FindNeighbors(currentCoordinate);
            foreach (var nextStep in nextSteps)
            {
                // If not in grid, ignore
                if (!nextStep.IsInGrid(superSampled)) continue;
                if (visited.Contains(nextStep)) continue;

                nextPositions.Enqueue(nextStep);
            }
        }

        var count = 0;
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var newJ = j * 3 + 1;
                var newI = i * 3 + 1;
                if (superSampled[newI][newJ] == '.')
                {
                    count++;
                }
            }
        }
        return count;


        void EnqueueIfNotOnPath(Coordinate coordinate)
        {
            if (path!.Contains(coordinate)) return;
            nextPositions!.Enqueue(coordinate);
        }

        void FillArray(int x, int y)
        {
            var coordinate = new Coordinate(x, y);
            var actualXStart = x * 3;
            var actualYStart = y * 3;
            if (!path!.Contains(coordinate))
            {

                WriteToPosition(actualXStart, actualYStart, ["...", "...", "..."]);
                return;
            }

            var wallPiece = data[y][x];
            switch (wallPiece)
            {
                case '-':
                    WriteToPosition(actualXStart, actualYStart, ["...", "XXX", "..."]);
                    break;
                case '|':
                    WriteToPosition(actualXStart, actualYStart, [".X.", ".X.", ".X."]);
                    break;
                case 'L':
                    WriteToPosition(actualXStart, actualYStart, [".X.", ".XX", "..."]);
                    break;
                case 'J':
                    WriteToPosition(actualXStart, actualYStart, [".X.", "XX.", "..."]);
                    break;
                case '7':
                    WriteToPosition(actualXStart, actualYStart, ["...", "XX.", ".X."]);
                    break;
                case 'F':
                    WriteToPosition(actualXStart, actualYStart, ["...", ".XX", ".X."]);
                    break;
                case 'S':
                    WriteToPosition(actualXStart, actualYStart, [".X.", "XXX", ".X."]);
                    break;
            }

        }

        void WriteToPosition(int x, int y, string[] pattern)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    superSampled[y + i][x + j] = pattern[i][j];
                }
            }
        }
    }

    private static HashSet<Coordinate> CalculatePath(string[] data)
    {
        var start = FindStartPosition(data);

        // Idea: Perform BFS until we reached all entries we could reach
        var queue = new Queue<Coordinate>();
        queue.Enqueue(start);
        var visited = new HashSet<Coordinate>();
        // Walk until we can't no more
        while (queue.Count > 0)
        {
            var currentCoordinate = queue.Dequeue();
            if (visited.Contains(currentCoordinate)) continue;
            visited.Add(currentCoordinate);

            var nextSteps = FindNextSteps(currentCoordinate, data).Where(isValidNextStep);
            foreach (var nextStep in nextSteps)
            {
                queue.Enqueue(nextStep);
            }
        }

        return visited;

        bool isValidNextStep(Coordinate nextStep)
        {
            return !visited!.Contains(nextStep) && nextStep.IsInGrid(data);
        }
    }

    private static Coordinate FindStartPosition(string[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (data[i][j] == 'S') return new(j, i);
            }
        }
        return new(-1, -1);
    }

    private static Coordinate[] FindNextSteps(Coordinate currentCoordinate, string[] data)
    {
        var character = data.Get(currentCoordinate);
        Coordinate north = new(currentCoordinate.X, currentCoordinate.Y - 1);
        Coordinate east = new(currentCoordinate.X + 1, currentCoordinate.Y);
        Coordinate south = new(currentCoordinate.X, currentCoordinate.Y + 1);
        Coordinate west = new(currentCoordinate.X - 1, currentCoordinate.Y);
        // Convert to regular switch case
        switch (character)
        {
            case '.': return [];
            case '|': return [north, south];
            case '-': return [west, east];
            case 'L': return [north, east];
            case 'J': return [north, west];
            case '7': return [south, west];
            case 'F': return [south, east];
            case 'S':
                Coordinate[] allEntries = [north, east, south, west];
                var actualEntries = new List<Coordinate>();
                foreach (var entry in allEntries)
                {
                    if (entry.IsInGrid(data) && FindNextSteps(entry, data).Contains(currentCoordinate))
                    {
                        actualEntries.Add(entry);
                    }
                }
                return [.. actualEntries];
        }
        return [];
    }

    private static Coordinate[] FindNeighbors(Coordinate coordinate)
    {
        return [
            new Coordinate(coordinate.X + 1, coordinate.Y),
            new Coordinate(coordinate.X - 1, coordinate.Y),
            new Coordinate(coordinate.X, coordinate.Y + 1),
            new Coordinate(coordinate.X, coordinate.Y - 1),
        ];
    }
}
