namespace AdventOfCode.Year2020.Solutions;

public static class Day10
{
    public static int FirstProblem(int[] data)
    {
        Array.Sort(data);

        var prevIndex = 0;
        var oneJumps = 0;
        var threeJumps = 1;
        for (var i = 0; i < data.Length; i++)
        {
            if (data[i] - prevIndex == 3)
            {
                threeJumps++;
            }
            else if (data[i] - prevIndex == 1)
            {
                oneJumps++;
            }
            prevIndex = data[i];
        }

        return oneJumps * threeJumps;
    }

    public static long SecondProblem(int[] data)
    {
        Array.Sort(data);

        return GetPathsToZero(data, data.Length - 1, new long[data.Length]);
    }

    public static long GetPathsToZero(int[] data, int index, long[]? cacheArray)
    {
        var predecessors = GetValidPredecessorsIndices(data, index);
        var pathsCount = 0L;
        if (cacheArray != null && index >= 0 && index <= cacheArray.Length && cacheArray[index] > 0)
        {
            return cacheArray[index];
        }
        for (var i = 0; i < predecessors.Length; i++)
        {
            if (predecessors[i] == -1)
            {
                pathsCount++;
            }
            else
            {
                pathsCount += GetPathsToZero(data, predecessors[i], cacheArray);
            }
        }
        if (cacheArray != null && index >= 0 && index <= cacheArray.Length)
        {
            cacheArray[index] = pathsCount;
        }
        return pathsCount;
    }

    public static int[] GetValidPredecessorsIndices(int[] data, int index)
    {
        var currentValue = data[index];
        if (index < 3)
        {
            if (index == 0 && data[index] < 3)
            {
                return [-1];
            }
            else if (index == 1)
            {
                if (data[index] <= 3)
                {
                    return [-1, 0];
                }
                else if (data[index] - data[index - 1] <= 3)
                {
                    return [0];
                }
            }
            else if (index == 2)
            {
                if (data[index] <= 3)
                {
                    return [-1, 0, 1];
                }
                else if (data[index] - data[index - 2] <= 3)
                {
                    return [0, 1];
                }
                else if (data[index] - data[index - 1] <= 3)
                {
                    return [1];
                }
            }
        }
        else
        {
            if (currentValue - data[index - 3] <= 3)
            {
                return [index - 3, index - 2, index - 1];
            }
            else if (currentValue - data[index - 2] <= 3)
            {
                return [index - 2, index - 1];
            }
            else if (currentValue - data[index - 1] <= 3)
            {
                return [index - 1];
            }
        }
        return [];
    }
}
