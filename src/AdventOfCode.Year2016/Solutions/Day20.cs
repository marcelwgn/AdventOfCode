namespace AdventOfCode.Year2016.Solutions;

public static class Day20
{
    public static (uint Start, uint Finish)[] Convert(string[] data) => data.Select(x => (uint.Parse(x.Split("-")[0]), uint.Parse(x.Split("-")[1]))).ToArray();

    /// <summary>
    /// This is the Josephus problem, we are using the algorithm for it.
    /// </summary>
    public static long FirstProblem((uint Start, uint Finish)[] data)
    {
        var intervals = GetUniqueIntervals([.. data.OrderBy(x => x.Start)]);
        return intervals[0].Finish + 1;
    }

    public static long SecondProblem((uint Start, uint Finish)[] data)
    {
        var intervals = GetUniqueIntervals([.. data.OrderBy(x => x.Start)]);
        long freeIPCount = 0;
        for (var i = 0; i < intervals.Count - 1; i++)
        {
            freeIPCount += intervals[i + 1].Start - intervals[i].Finish - 1;
        }
        freeIPCount += (uint)Math.Max(0, uint.MaxValue - intervals[^1].Finish - 1);
        return freeIPCount;
    }

    public static IList<(long Start, long Finish)> GetUniqueIntervals((uint Start, uint Finish)[] data)
    {
        var intervals = new List<(long Start, long Finish)>();
        var index = 0;
        long intervalStart = data[0].Start;
        long curMaxValue = data[0].Finish;
        while (index < data.Length - 1)
        {
            // Overlapping, move to next element
            curMaxValue = Math.Max(curMaxValue, data[index].Finish);
            if (curMaxValue + 1 < data[index + 1].Start)
            {
                intervals.Add((intervalStart, curMaxValue));
                curMaxValue = data[index + 1].Finish;
                intervalStart = data[index + 1].Start;
            }
            index++;
        }
        var last = data.Max(x => x.Finish);
        intervals.Add((intervalStart, last));
        return intervals;
    }
}
