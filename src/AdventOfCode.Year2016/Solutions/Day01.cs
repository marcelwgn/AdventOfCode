using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2016.Solutions;

public static class Day01
{
    public static int FirstProblem(string[] data)
    {
        var instructions = data[0].Replace(" ", "").Split(",");
        var lastPos = (0, 0, 0);
        foreach (var instruction in instructions)
        {
            lastPos = GenerateNextPosition(instruction, lastPos).Last();
        }
        return Math.Abs(lastPos.Item1) + Math.Abs(lastPos.Item2);
    }

    public static int SecondProblem(string[] data)
    {
        var instructions = data[0].Replace(" ", "").Split(",");
        var alreadyVisitedLocations = new HashSet<Coordinate>();
        var lastPos = (0, 0, 0);

        foreach (var instruction in instructions)
        {
            var visitedPositions = GenerateNextPosition(instruction, lastPos);
            foreach (var pos in visitedPositions)
            {
                if (alreadyVisitedLocations.Contains(new(pos.Item1, pos.Item2)))
                {
                    return Math.Abs(pos.Item1) + Math.Abs(pos.Item2);
                }
                else
                {
                    alreadyVisitedLocations.Add(new(pos.Item1, pos.Item2));
                }
            }
            lastPos = visitedPositions.Last();
        }

        return Math.Abs(lastPos.Item1) + Math.Abs(lastPos.Item2);
    }

    public static (int, int, int)[] GenerateNextPosition(string instruction, (int posX, int posY, int direction) lastPos)
    {
        lastPos.direction = (lastPos.direction + (instruction[0] == 'R' ? 1 : -1) + 4) % 4;
        var increment = int.Parse(instruction[1..]);
        var data = new (int, int, int)[increment];

        for (var i = 1; i <= increment; i++)
        {
            switch (lastPos.direction)
            {
                case 0:
                    data[i - 1] = (lastPos.posX, lastPos.posY + i, lastPos.direction);
                    break;
                case 1:
                    data[i - 1] = (lastPos.posX + i, lastPos.posY, lastPos.direction);
                    break;
                case 2:
                    data[i - 1] = (lastPos.posX, lastPos.posY - i, lastPos.direction);
                    break;
                case 3:
                    data[i - 1] = (lastPos.posX - i, lastPos.posY, lastPos.direction);
                    break;
            }
        }
        return data;
    }
}
