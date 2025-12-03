namespace AdventOfCode.Year2025.Solutions;

public static class Day02
{
    public static string[] Convert(string[] data)
    {
        return data[0].Split(",");
    }

    public static string FirstProblem(string[] input)
    {
        return StCoreAlgorithm(input, true);
    }

    public static string SecondProblem(string[] input)
    {
        return StCoreAlgorithm(input, false);
    }

    private static string StCoreAlgorithm(string[] data, bool fOnlyCheckMiddleSplit)
    {
        long cAccumulatedInvalid = 0;
        HashSet<long> setInvalids = new HashSet<long>();
        foreach (var st in data)
        {
            var rgstSplit = st.Split("-");
            var (iStart, iEnd) = (long.Parse(rgstSplit[0]), long.Parse(rgstSplit[1]));
            for (long iCur = iStart; iCur <= iEnd; iCur++)
            {
                // If iCur is made of two repeated sequences, it is invalid
                var sCur = iCur.ToString();
                var cMaxIterations = fOnlyCheckMiddleSplit ? 2 : sCur.Length;
                for (int iRepetitions = 2; iRepetitions <= cMaxIterations; iRepetitions++)
                {
                    if (FIsRepeatingSequence(sCur, iRepetitions) && setInvalids.Add(iCur))
                    {
                        cAccumulatedInvalid += iCur;
                    }
                }
                setInvalids.Clear();
            }
        }

        return cAccumulatedInvalid.ToString();
    }

    private static bool FIsRepeatingSequence(string stText, int cRepetitions)
    {
        if (stText.Length % cRepetitions != 0) return false;

        var sPart = stText.Substring(0, stText.Length / cRepetitions);
        for (int i = 1; i < cRepetitions; i++)
        {
            var sNextPart = stText.Substring(i * sPart.Length, sPart.Length);
            if (sNextPart != sPart)
            {
                return false;
            }
        }
        return true;
    }
}
