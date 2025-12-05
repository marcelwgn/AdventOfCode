namespace AdventOfCode.Year2023.Solutions;

public static class Day13
{
    public static IEnumerable<string[]> Convert(string[] data)
    {
        var lastIndex = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Length == 0)
            {
                var lastIndexCopy = lastIndex;
                lastIndex = i + 1;
                yield return data[lastIndexCopy..i];
            }
        }
        yield return data[lastIndex..];
    }

    public static int FirstProblem(IEnumerable<string[]> data)
    {
        return data.Select(x => CalculateValueForField(x, false)).Sum();
    }

    public static long SecondProblem(IEnumerable<string[]> data)
    {
        return data.Select(x => CalculateValueForField(x, true)).Sum();
    }

    private static IEnumerable<char[]> GetColumns(string[] data)
    {
        for (int i = 0; i < data[0].Length; i++)
        {
            yield return data.Select(x => x[i]).ToArray();
        }
    }

    public static int CalculateValueForField(string[] data, bool allowSingleError = false)
    {
        var columns = GetColumns(data).ToArray();
        var rows = data.Select(x => x.ToCharArray()).ToArray();

        var verticalSymmetryResult = CalculateSymmetryValues(rows);
        var horizontalSymmetryResult = CalculateSymmetryValues(columns);

        var actualVertical = allowSingleError == false ? verticalSymmetryResult.Item1 : verticalSymmetryResult.Item2;
        var actualHorizontal = allowSingleError == false ? horizontalSymmetryResult.Item1 : horizontalSymmetryResult.Item2;

        if (actualVertical != null) return actualVertical.Value;
        if (actualHorizontal != null) return actualHorizontal.Value * 100;

        return -1;
    }

    private static (int?, int?) CalculateSymmetryValues(char[][] entries)
    {
        var normalSymmetries = entries.Select(x => GetSymmetryIndices(x, 0)).ToArray();
        var symmetriesWithOneError = entries.Select(x => GetSymmetryIndices(x, 1)).ToArray();

        var normalIntersections = Intersection(normalSymmetries).ToArray();
        int? normalIntersection = normalIntersections.Length > 0 ? normalIntersections[0] : null;

        int? modifiedIntersection = null;

        for (int i = 0; i < normalSymmetries.Length; i++)
        {
            IEnumerable<int>[] newData = [
                .. normalSymmetries[0..i],
                symmetriesWithOneError[i],
                ..normalSymmetries[(i + 1)..]
            ];

            var newIntersections = Intersection(newData).Where(x => x != normalIntersection).ToArray();

            if (newIntersections.Length > 0)
            {
                modifiedIntersection = newIntersections[0];
            }
        }

        return (normalIntersection, modifiedIntersection);

        static IEnumerable<int> Intersection(IEnumerable<int>[] entries)
        {
            return entries.Aggregate(entries.First(), (a, b) => a.Intersect(b));
        }
    }


    public static IEnumerable<int> GetSymmetryIndices(char[] firstList, int wantedErrors)
    {
        for (int i = 0; i < firstList.Length - 1; i++)
        {
            var foundErrors = 0;
            var startBackward = i;
            var startForward = i + 1;

            var maximumSteps = Math.Min(firstList.Length - startForward - 1, startBackward);
            for (int j = 0; j <= maximumSteps; j++)
            {
                if (firstList[startForward + j] != firstList[startBackward - j])
                {
                    foundErrors++;
                }
            }
            if (foundErrors == wantedErrors)
            {
                yield return i + 1;
            }
        }
    }
}
