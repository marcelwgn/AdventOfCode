using AdventOfCode.Year2016.Model;

namespace AdventOfCode.Year2016.Solutions;

public static class Day13
{
    public static MazeGraph Generate(int specialNum, int size)
    {
        var chars = new char[size][];
        for (var i = 0; i < size; i++)
        {
            chars[i] = new char[size];
            for (var j = 0; j < size; j++)
            {
                chars[i][j] = GetChar(i, j);
            }
        }
        return new MazeGraph(chars);

        char GetChar(int x, int y)
        {
            var oneBitCount = Convert.ToString(x * x + 3 * x + 2 * x * y + y + y * y + specialNum, 2).ToCharArray().Where(x => x == '1').Count();
            return oneBitCount % 2 == 0 ? '.' : '#';
        }
    }

    public static long FirstProblem(string[] data)
    {
        var luckyNumber = int.Parse(data[0]);
        var xCoord = int.Parse(data[1]);
        var yCoord = int.Parse(data[2]);
        return Generate(luckyNumber, Math.Max(xCoord, yCoord) * 5).CalculateDistance(new(1, 1), new(xCoord, yCoord));
    }

    public static long SecondProblem(string[] data)
    {
        var luckyNumber = int.Parse(data[0]);
        var graph = Generate(luckyNumber, 50);
        var inReachCount = 0;
        for (var i = 0; i < 50; i++)
        {
            for (var j = 0; j < 50; j++)
            {
                var dist = graph.CalculateDistance(new(1, 1), new(i, j));
                if (dist >= 0 && dist <= 50)
                {
                    inReachCount++;
                }
            }
        }
        return inReachCount;
    }
}
