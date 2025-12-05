namespace AdventOfCode.Year2023.Solutions;

public interface IPresentCondition
{
    public string? GetResult(Present present);
    public IEnumerable<IntervalledPresent> GetResults(IntervalledPresent intervalledPresent);
}

public class PresentCondition(char Condition, int Threshold, bool IsLowerThanCondition, string MatchValue) : IPresentCondition
{
    public string? GetResult(Present present)
    {
        var value = Condition switch
        {
            'x' => present.X,
            'm' => present.M,
            'a' => present.A,
            _ => present.S
        };

        if (IsLowerThanCondition)
        {
            return value < Threshold ? MatchValue : null;
        }
        else
        {
            return value > Threshold ? MatchValue : null;
        }
    }

    public IEnumerable<IntervalledPresent> GetResults(IntervalledPresent intervalledPresent)
    {
        var values = Condition switch
        {
            'x' => intervalledPresent.X,
            'm' => intervalledPresent.M,
            'a' => intervalledPresent.A,
            _ => intervalledPresent.S
        };

        if (IsLowerThanCondition)
        {
            var matchingInterval = new Interval(values.Start, Threshold - 1);
            var notMatchingInterval = new Interval(Threshold, values.End);
            return [GetUpdated(matchingInterval, MatchValue), GetUpdated(notMatchingInterval, null)];
        }
        else
        {
            var notMatchingInterval = new Interval(values.Start, Threshold);
            var matchingInterval = new Interval(Threshold + 1, values.End);
            return [GetUpdated(matchingInterval, MatchValue), GetUpdated(notMatchingInterval, null)];
        }

        IntervalledPresent GetUpdated(Interval newInterval, string? NewRule)
        {
            return new IntervalledPresent(
                Condition == 'x' ? newInterval : intervalledPresent.X,
                Condition == 'm' ? newInterval : intervalledPresent.M,
                Condition == 'a' ? newInterval : intervalledPresent.A,
                Condition == 's' ? newInterval : intervalledPresent.S,
                NewRule
            );
        }
    }
}

public class AlwaysTrueCondition(string MatchValue) : IPresentCondition
{
    public string? GetResult(Present present)
    {
        return MatchValue;
    }

    public IEnumerable<IntervalledPresent> GetResults(IntervalledPresent intervalledPresent)
    {
        return [new(intervalledPresent.X, intervalledPresent.M, intervalledPresent.A, intervalledPresent.S, MatchValue)];
    }
}

public record Present(int X, int M, int A, int S);
public record Interval(int Start, int End)
{
    public int LengthInclusive => End - Start + 1;
}
public record IntervalledPresent(Interval X, Interval M, Interval A, Interval S, string? CurrentRule);

public record Rule(string Name, IPresentCondition[] Conditions)
{
    public string? GetNextRule(Present present)
    {
        foreach (var item in Conditions)
        {
            if (item.GetResult(present) != null)
            {
                return item.GetResult(present);
            }
        }
        return null;
    }

    public IEnumerable<IntervalledPresent> GetNextPresents(IntervalledPresent intervalledPresent)
    {
        List<IntervalledPresent> presentsToSort = [intervalledPresent];
        var presentsSorted = new List<IntervalledPresent>();
        foreach (var item in Conditions)
        {
            var newlySorted = presentsToSort.Select(item.GetResults).SelectMany(x => x).ToArray();
            presentsToSort.Clear();
            foreach (var newlySortedPresent in newlySorted)
            {
                if (newlySortedPresent.CurrentRule == null)
                {
                    presentsToSort.Add(newlySortedPresent);
                }
                else
                {
                    presentsSorted.Add(newlySortedPresent);
                }
            }
        }
        return presentsSorted;
    }
}

public record RulesAndPresents(Dictionary<string, Rule> Rules, Present[] Presents);

public static class Day19
{
    public static RulesAndPresents Convert(string[] data)
    {
        var splittingIndex = Array.IndexOf(data, "");
        var rules = new Dictionary<string, Rule>();

        for (int i = 0; i < splittingIndex; i++)
        {
            var row = data[i];
            var split = row.Split("{");

            var name = split[0];

            var conditionsRaw = split[1][..^1].Split(',');

            var conditions = new List<IPresentCondition>();

            for (int conditionIndex = 0; conditionIndex < conditionsRaw.Length - 1; conditionIndex++)
            {
                var condition = conditionsRaw[conditionIndex];
                var element = condition[0];
                var isLowerThan = condition[1] == '<';

                var numberEndDigit = condition.IndexOf(':');

                var number = int.Parse(condition[2..numberEndDigit]);

                var matchCondition = condition[++numberEndDigit..];

                conditions.Add(new PresentCondition(element, number, isLowerThan, matchCondition));
            }

            conditions.Add(new AlwaysTrueCondition(conditionsRaw.Last()));

            rules.Add(name, new(name, [.. conditions]));
        }

        var presents = new List<Present>();

        for (int i = splittingIndex + 1; i < data.Length; i++)
        {
            var presentRaw = data[i];

            var values = presentRaw[1..^1].Split(",").Select(x =>
            {
                var indexOfEqual = x.IndexOf('=');
                return int.Parse(x[++indexOfEqual..]);
            }).ToArray();

            presents.Add(new(values[0], values[1], values[2], values[3]));
        }

        var firstRow = data[0];

        return new RulesAndPresents(rules, [.. presents]);
    }

    public static int FirstProblem(RulesAndPresents rulesAndPresents)
    {
        var validPresents = rulesAndPresents.Presents.Where(x => PresentMatches(rulesAndPresents, x));

        return validPresents.Select(x => x.X + x.M + x.A + x.S).Sum();
    }

    public static long SecondProblem(RulesAndPresents rulesAndPresents)
    {
        IEnumerable<IntervalledPresent> presentsToSort = [new IntervalledPresent(new(1, 4000), new(1, 4000), new(1, 4000), new(1, 4000), "in")];

        IEnumerable<IntervalledPresent> presentsSorted = [];

        while (presentsToSort.Any())
        {
            var newlySorted = presentsToSort.Select(SortOneStep).SelectMany(x => x);
            presentsSorted = presentsSorted.Union(newlySorted.Where(x => x.CurrentRule == "A"));
            presentsToSort = newlySorted.Where(x => x.CurrentRule != "R" && x.CurrentRule != "A");
        }

        return presentsSorted.Select(x => (long)x.X.LengthInclusive * x.M.LengthInclusive * x.A.LengthInclusive * x.S.LengthInclusive).Sum();

        IEnumerable<IntervalledPresent> SortOneStep(IntervalledPresent present)
        {
            if (present.CurrentRule == null) return [present];

            var rule = rulesAndPresents.Rules[present.CurrentRule];
            return rule.GetNextPresents(present);
        }
    }

    private static bool PresentMatches(RulesAndPresents rulesAndPresents, Present present)
    {
        var ruleName = "in";
        while (ruleName != "A" && ruleName != "R" && ruleName != null)
        {
            ruleName = rulesAndPresents.Rules[ruleName].GetNextRule(present);
        }
        return ruleName == "A";
    }
}
