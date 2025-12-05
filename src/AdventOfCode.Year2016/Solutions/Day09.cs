namespace AdventOfCode.Year2016.Solutions;

public static class Day09
{
    public static long FirstProblem(string[] data)
    {
        return Uncompress(data[0], false);
    }

    public static long SecondProblem(string[] data)
    {
        return Uncompress(data[0], true);
    }

    public static long Uncompress(string input, bool recursive)
    {
        var result = 0L;
        for (var i = 0; i < input.Length; i++)
        {
            var currentChar = input[i];
            if (currentChar == '(')
            {
                var endPosition = i + input[i..].IndexOf(')');
                var split = i + input[i..].IndexOf('x');

                var stringLength = int.Parse(input[(i + 1)..split]);
                var repeatCount = int.Parse(input[(split + 1)..endPosition]);

                var repeatedString = input[(endPosition + 1)..(endPosition + stringLength + 1)];
                result += recursive ? Uncompress(input[(endPosition + 1)..(endPosition + stringLength + 1)], true) * repeatCount : repeatCount * repeatedString.Length;
                i = endPosition + stringLength;
            }
            else
            {
                result++;
            }
        }
        return result;
    }
}
