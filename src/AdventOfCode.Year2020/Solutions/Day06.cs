namespace AdventOfCode.Year2020.Solutions;

public static class Day06
{

    public static int FirstProblem(string[] data)
    {
        var entries = string.Join(';', data).Split(";;");
        var sum = 0;
        foreach (var group in entries)
        {
            sum += GetAllQuestionCount(group);
        }
        return sum;
    }

    public static int SecondProblem(string[] data)
    {
        var entries = string.Join(';', data).Split(";;");
        var sum = 0;
        foreach (var group in entries)
        {
            sum += GetSameQuestionCount(group);
        }
        return sum;
    }

    public static int GetAllQuestionCount(string data)
    {
        var cleaned = data.Replace(";", "");
        return cleaned.Distinct().Count();
    }

    public static int GetSameQuestionCount(string data)
    {
        var rows = data.Split(";");
        var dict = new Dictionary<char, int>();

        foreach (var item in rows)
        {
            foreach (var character in item)
            {
                if (dict.TryGetValue(character, out var value))
                {
                    dict[character] = ++value;
                }
                else
                {
                    dict.Add(character, 1);
                }
            }
        }

        return dict.Keys.Count(key =>
        {
            return dict[key] == rows.Length;
        });
    }

}
