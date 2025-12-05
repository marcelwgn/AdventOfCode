namespace AdventOfCode.Year2023.Solutions;

public static class Day12
{
    public static long FirstProblem(string[] data)
    {
        var totalSum = 0L;
        foreach (var item in data)
        {
            var split = item.Split(" ");
            var criteria = split[1].Split(',').Select(int.Parse).ToArray();
            var sum = CalculateArrangements(split[0], criteria);
            totalSum += sum;
        }
        return totalSum;
    }

    public static long SecondProblem(string[] data)
    {
        var totalSum = 0L;
        foreach (var item in data)
        {
            var split = item.Split(" ");
            var sequenceTimesFive = string.Join("?", Enumerable.Repeat(split[0], 5));
            var criteriaTimesFive = Enumerable.Repeat(split[1].Split(',').Select(int.Parse), 5).SelectMany(x => x).ToArray();
            totalSum += CalculateArrangements(sequenceTimesFive, criteriaTimesFive);
        }
        return totalSum;
    }


    private static readonly Dictionary<string, long> cache = [];
    private static long CalculateArrangements(string sequence, int[] criteria)
    {
        var key = sequence + ":" + string.Join(',', criteria);
        if (cache.TryGetValue(key, out var value))
        {
            return value;
        }

        var computed = CalculateCombinationCount(sequence, criteria);
        cache.Add(key, computed);
        return computed;
    }

    private static long CalculateCombinationCount(string sequence, int[] criteria)
    {
        switch (sequence.FirstOrDefault())
        {
            case '.': return CalculateArrangements(sequence[1..], criteria);
            case '?': return CalculateArrangements('#' + sequence[1..], criteria) + CalculateArrangements('.' + sequence[1..], criteria);
            case '#':
                // Should not happen but we need to guard against empty array
                if (criteria.Length == 0) return 0;

                var expectedSpringCount = criteria[0];
                var maximumNumberOfPossibleSpringsInSection = sequence.TakeWhile(s => s == '#' || s == '?').Count();

                if (maximumNumberOfPossibleSpringsInSection < expectedSpringCount)
                {
                    return 0;
                }
                else if (sequence.Length == expectedSpringCount)
                {
                    return CalculateArrangements("", criteria[1..]);
                }
                else if (sequence[expectedSpringCount] == '#')
                {
                    return 0; // dead spring follows the range -> not good
                }
                else
                {
                    return CalculateArrangements(sequence[(expectedSpringCount + 1)..], criteria[1..]);
                }
            default:
                return criteria.Length == 0 ? 1 : 0;
        }
    }
}
