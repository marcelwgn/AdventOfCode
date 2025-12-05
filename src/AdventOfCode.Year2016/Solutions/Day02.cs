using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2016.Solutions;


public static class Day02
{
    public static string FirstProblem(string[] data)
    {
        var lastPos = new Coordinate(1, 1);
        var result = "";
        foreach (var item in data)
        {
            lastPos = NextPosition(item, lastPos, IsValidPosition);
            result += lastPos.X + 1 + lastPos.Y * 3;
        }
        return result;

        static bool IsValidPosition(Coordinate position)
        {
            return position.X >= 0 && position.X <= 2 && position.Y >= 0 && position.Y <= 2;
        }
    }

    public static string SecondProblem(string[] data)
    {
        Dictionary<Coordinate, char> keypad = new()
        {
            { new(0, 2), '5' },
            { new(1, 1), '2' },
            { new(1, 2), '6' },
            { new(1, 3), 'A' },
            { new(2, 0), '1' },
            { new(2, 1), '3' },
            { new(2, 2), '7' },
            { new(2, 3), 'B' },
            { new(2, 4), 'D' },
            { new(3, 1), '4' },
            { new(3, 2), '8' },
            { new(3, 3), 'C' },
            { new(4, 2), '9' },
        };

        var lastPos = new Coordinate(0, 2);
        var result = "";
        foreach (var item in data)
        {
            lastPos = NextPosition(item, lastPos, IsValidPosition);
            result += keypad[lastPos];
        }
        return result;

        bool IsValidPosition(Coordinate position)
        {
            return keypad.ContainsKey(position);
        }
    }

    private static Coordinate NextPosition(string instructions, Coordinate lastPos, Func<Coordinate, bool> isValidPosition)
    {
        (var newPosX, var newPosY) = lastPos;

        foreach (var character in instructions)
        {
            switch (character)
            {
                case 'U':
                    if (!isValidPosition(new(newPosX, newPosY - 1)))
                    {
                        break;
                    }
                    newPosY--;
                    break;
                case 'L':
                    if (!isValidPosition(new(newPosX - 1, newPosY)))
                    {
                        break;
                    }
                    newPosX--;
                    break;
                case 'D':
                    if (!isValidPosition(new(newPosX, newPosY + 1)))
                    {
                        break;
                    }
                    newPosY++;
                    break;
                case 'R':
                    if (!isValidPosition(new(newPosX + 1, newPosY)))
                    {
                        break;
                    }
                    newPosX++;
                    break;
            }
        }

        return new(newPosX, newPosY);
    }
}
