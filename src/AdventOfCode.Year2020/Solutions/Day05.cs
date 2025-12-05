namespace AdventOfCode.Year2020.Solutions;

public static class Day05
{
    public static int FirstProblem(string[] data)
    {
        return data.Max(GetBoardingPassID);
    }

    public static int SecondProblem(string[] data)
    {
        var seatIDs = data.Select(GetBoardingPassID).ToList();
        seatIDs.Sort();
        for (var i = 0; i < seatIDs.Count - 1; i++)
        {
            if (seatIDs[i] == seatIDs[i + 1] - 2)
            {
                return seatIDs[i] + 1;
            }
        }
        return 0;
    }

    public static int GetBoardingPassID(string data)
    {
        var row = 0;
        var rowModifier = 64;

        for (var i = 0; i < 7; i++)
        {
            if (data[i] == 'B')
            {
                row += rowModifier;
            }
            rowModifier /= 2;
        }

        var column = 0;
        var columnModifier = 4;
        for (var i = 7; i < 10; i++)
        {
            if (data[i] == 'R')
            {
                column += columnModifier;
            }
            columnModifier /= 2;
        }

        return row * 8 + column;
    }
}
