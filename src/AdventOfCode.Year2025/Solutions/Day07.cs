using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2025.Solutions;

public static class Day07
{
    public static string FirstProblem(string[] input)
    {
        long cSplits = 0;
        HashSet<int> hsiBeams = new();

        hsiBeams.Add(input[0].IndexOf('S'));

        for (int iRow = 1; iRow < input.Length; iRow++)
        {
            HashSet<int> newBeams = new();
            foreach (var iBeam in hsiBeams)
            {
                if (input[iRow][iBeam] == '^')
                {
                    cSplits++;
                    newBeams.Add(iBeam - 1);
                    newBeams.Add(iBeam + 1);
                }
                else
                {
                    newBeams.Add(iBeam);
                }
            }
            hsiBeams = newBeams;
        }

        return cSplits.ToString();
    }

    public static string SecondProblem(string[] input)
    {
        Dictionary<int, long> mpi_cOccurence = new();

        mpi_cOccurence.Add(input[0].IndexOf('S'), 1);

        for (int iRow = 1; iRow < input.Length; iRow++)
        {
            Dictionary<int, long> mpi_cOccurenceCurIteration = new();
            foreach (var (iBeam, count) in mpi_cOccurence)
            {
                if (input[iRow][iBeam] == '^')
                {
                    Add(mpi_cOccurenceCurIteration, iBeam - 1, count);
                    Add(mpi_cOccurenceCurIteration, iBeam + 1, count);
                }
                else
                {
                    Add(mpi_cOccurenceCurIteration, iBeam, count);
                }
            }

            mpi_cOccurence = mpi_cOccurenceCurIteration;
        }

        return mpi_cOccurence.Sum(kvp => kvp.Value).ToString();

        static void Add(Dictionary<int, long> dict, int key, long cTimes)
        {
            if (dict.TryGetValue(key, out long value))
            {
                dict[key] = value + cTimes;
            }
            else
            {
                dict[key] = cTimes;
            }
        }
    }
}
