using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2018.Solutions;

public static class Day02
{

    public static string[] Convert(string[] args)
    {
        return args;
    }

    public static int FirstProblem(string[] data)
    {
        var sumLettersTwice = 0;
        var sumLettersThrice = 0;
        for (var i = 0; i < data.Length; i++)
        {
            if (data[i].ContainsLetterExactlyTwice())
            {
                sumLettersTwice++;
            }
            if (data[i].ContainsLetterExactlyThrice())
            {
                sumLettersThrice++;
            }
        }

        return sumLettersTwice * sumLettersThrice;
    }

    public static string SecondProblem(string[] data)
    {
        var first = data[0];
        var second = data[1];
        var difference = first.NumberOfLettersDifferent(second);
        for (var i = 0; i < data.Length - 1; i++)
        {
            for (var j = i + 1; j < data.Length; j++)
            {
                if (data[i].NumberOfLettersDifferent(data[j]) < difference)
                {
                    first = data[i];
                    second = data[j];

                    difference = first.NumberOfLettersDifferent(second);

                }
            }
        }

        return first.GetCommonLetters(second);
    }

}
