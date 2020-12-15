namespace AdventOfCode.Year2020.Solutions
{
    public static class Day01
    {
        public static long FirstProblem(long[] numbers)
        {
            // Not best algorithm but works fine
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        return numbers[i] * numbers[j];
                    }
                }
            }
            return 0;
        }

        public static long SecondProblem(long[] numbers)
        {
            // Not best algorithm but works fine
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    for (int l = 0; l < numbers.Length; l++)
                    {
                        if (numbers[i] + numbers[j] + numbers[l] == 2020)
                        {
                            return numbers[i] * numbers[j] * numbers[l];
                        }
                    }
                }
            }
            return 0;
        }
    }
}
