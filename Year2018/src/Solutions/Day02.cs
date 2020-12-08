using AdventOfCode.SharedUtils;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day02
    {

        public static string[] Convert(string[] args)
        {
            return args;
        }

        public static int FirstProblem(string[] data)
        {
            int sumLettersTwice = 0;
            int sumLettersThrice = 0;
            for (int i = 0; i < data.Length; i++)
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
            string first = data[0];
            string second = data[1];
            int difference = first.NumberOfLettersDifferent(second);
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
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
}
