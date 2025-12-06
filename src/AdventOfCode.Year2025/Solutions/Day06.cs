namespace AdventOfCode.Year2025.Solutions;

public static class Day06
{
    public static string FirstProblem(string[] input)
    {
        string[][] matrix = input.Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToArray();

        return StProcessOperations(matrix, ProcessRow);

        IEnumerable<long> ProcessRow(long iCol)
        {
            for (int iRow = 0; iRow < matrix.Length - 1; iRow++)
            {
                yield return long.Parse(matrix[iRow][iCol]);
            }
        }
    }

    public static string SecondProblem(string[] input)
    {
        string[][] matrix = new string[input.Length][];
        matrix[^1] = input[^1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int iRow = 0; iRow < matrix.Length - 1; iRow++)
        {
            matrix[iRow] = new string[matrix[^1].Length];
            int iColStart = 0;
            for (int iCol = 0; iCol < matrix[iRow].Length; iCol++)
            {
                // Find the next index of a non space in input[^1] after iColStart
                int iColEnd = input[^1].IndexOfAny(['+', '*'], iColStart + 1) - 1;
                if (iColEnd < 0) iColEnd = input[iRow].Length;
                matrix[iRow][iCol] = input[iRow].Substring(iColStart, iColEnd - iColStart);
                iColStart = iColEnd + 1;
            }
        }

        return StProcessOperations(matrix, ProcessRow);

        IEnumerable<long> ProcessRow(long iCol)
        {
            for (int ichCol = matrix[0][iCol].Length - 1; ichCol >= 0; ichCol--)
            {
                string stCur = "";
                for (int iRow = 0; iRow < matrix.Length - 1; iRow++)
                {
                    stCur += matrix[iRow][iCol][ichCol];
                }
                yield return long.Parse(stCur);
            }
        }
    }

    private static string StProcessOperations(string[][] matrix, Func<long, IEnumerable<long>> funcProcessColumn)
    {
        long cTotal = 0;

        long cCurrent = 0;
        for (int iCol = 0; iCol < matrix[0].Length; iCol++)
        {
            char chOperator = matrix[^1][iCol][0];
            if (chOperator == '*') cCurrent = 1;
            else cCurrent = 0;

            foreach (long nValue in funcProcessColumn(iCol))
            {
                if (chOperator == '+')
                {
                    cCurrent += nValue;
                }
                else
                {
                    cCurrent *= nValue;
                }
            }

            cTotal += cCurrent;
        }

        return cTotal.ToString();
    }
}
