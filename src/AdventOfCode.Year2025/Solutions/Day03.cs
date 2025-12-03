namespace AdventOfCode.Year2025.Solutions;

public static class Day03
{
    public static string FirstProblem(string[] input)
    {
        return input.Sum(static st => Day03.UMaxToFind(st, 2)).ToString();
    }

    public static string SecondProblem(string[] input)
    {
        return input.Sum(static st => Day03.UMaxToFind(st, 12)).ToString();
    }

    private static long UMaxToFind(string stInput, short cDigits)
    {
        int[] rgdigits = new int[cDigits];
        int ichStart = 0;

        for (int iDigit = 0; iDigit < cDigits; iDigit++)
        {
            int uMax = 0;
            for (int ich = ichStart; ich < stInput.Length - (cDigits - iDigit - 1); ich++)
            {
                var uValue = stInput[ich] - '0';
                if (uValue > uMax)
                {
                    uMax = uValue;
                    ichStart = ich + 1;
                }
                if (uMax == 9)
                {
                    break;
                }
            }
            rgdigits[iDigit] = uMax;
        }


        long uValueFinal = 0;
        for (int iDigit = 0; iDigit < cDigits; iDigit++)
        {
            uValueFinal = uValueFinal * 10 + rgdigits[iDigit];
        }
        return uValueFinal;
    }
}
