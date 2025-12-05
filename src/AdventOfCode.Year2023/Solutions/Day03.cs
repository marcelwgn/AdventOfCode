namespace AdventOfCode.Year2023.Solutions;

public record NumberPosition(int X, int Y, int XEnd, int Value);

public record PartPosition(int X, int Y, bool IsGear);

public record PartNumberList(IList<NumberPosition> Numbers, IList<PartPosition> Parts);

public static class Day03
{
    public static PartNumberList Convert(string[] data)
    {
        var symbolPositions = new List<PartPosition>();
        var numberPositions = new List<NumberPosition>();

        for (int i = 0; i < data.Length; i++)
        {
            var lastNumberStart = 0;
            var numberLength = 0;
            for (int j = 0; j < data[i].Length; j++)
            {
                var curChar = data[i][j];
                if (char.IsNumber(curChar))
                {
                    if (numberLength == 0)
                    {
                        lastNumberStart = j;
                    }
                    numberLength++;
                }
                else
                {
                    if (numberLength != 0)
                    {
                        numberPositions.Add(new NumberPosition(lastNumberStart, i, lastNumberStart + numberLength - 1, int.Parse(data[i].Substring(lastNumberStart, numberLength))));

                        numberLength = 0;
                    }
                    if (curChar != '.' && !char.IsNumber(curChar))
                    {
                        symbolPositions.Add(new PartPosition(j, i, curChar == '*'));
                    }
                }
            }

            if (numberLength != 0)
            {
                numberPositions.Add(new NumberPosition(
                    lastNumberStart, i, lastNumberStart + numberLength - 1, int.Parse(data[i].Substring(lastNumberStart, numberLength))));
            }
        }
        var totalNumberCount = data.Select(x => string.Join(",", x.Split('.').Where(y => y.All(c => char.IsNumber(c)) && y.Length > 0).ToArray()));
        var otherCount = numberPositions.GroupBy(x => x.Y).Select(x => string.Join(",", x.Select(y => y.Value).ToArray()));
        return new PartNumberList(numberPositions, symbolPositions);
    }

    public static int FirstProblem(PartNumberList parseResult)
    {
        return parseResult.Numbers.Where(n => parseResult.Parts.Any(p => IsAdjacent(n, p))).Sum(x => x.Value);
    }

    public static int SecondProblem(PartNumberList parseResult)
    {
        var gears = parseResult.Parts.Where(p => p.IsGear);
        var totalResult = 0;
        foreach (var gear in gears)
        {
            var adjacentItems = parseResult.Numbers.Where(n => IsAdjacent(n, gear)).ToArray();
            if (adjacentItems.Length == 2)
            {
                totalResult += adjacentItems[0].Value * adjacentItems[1].Value;
            }
        }
        return totalResult;
    }

    private static bool IsAdjacent(NumberPosition number, PartPosition part)
    {
        var yDistance = Math.Abs(part.Y - number.Y);
        var xDistance = 0;
        if (part.X <= number.X)
        {
            xDistance = Math.Abs(number.X - part.X);
        }
        else if (part.X >= number.XEnd)
        {
            xDistance = Math.Abs(part.X - number.XEnd);
        }
        return xDistance <= 1 && yDistance <= 1;
    }
}
