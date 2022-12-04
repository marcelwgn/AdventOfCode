using System;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day08
    {
        public static int FirstProblem(string[] data)
        {
            int value = 0;
            int nextPos = 0;
            while (data[nextPos].Length > 0)
            {
                int curPos = nextPos;
                ProcessLine(data[nextPos], ref value, ref nextPos);
                data[curPos] = string.Empty;
            }
            return value;
        }

        public static int SecondProblem(string[] data)
        {
            var copied = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                // Just iterate over all the possible switch positions and check if we reach the end
                // Not the best solution but it works and is not over engineered.
                if (GotValidPermutation(i))
                {
                    int value = 0;
                    int nextPos = 0;
                    while (nextPos < data.Length && copied[nextPos].Length > 0)
                    {
                        int curPos = nextPos;
                        ProcessLine(copied[nextPos], ref value, ref nextPos);
                        copied[curPos] = string.Empty;
                    }
                    if (nextPos == data.Length)
                    {
                        return value;
                    }
                }
            }
            return 0;

            bool GotValidPermutation(int pos)
            {
                if (data[pos][0..3] == "nop" || data[pos][0..3] == "jmp")
                {
                    Array.Copy(data, copied, data.Length);
                    if (copied[pos][0..3] == "nop")
                    {
                        copied[pos] = "jmp" + copied[pos][3..];
                    }
                    else if (copied[pos][0..3] == "jmp")
                    {
                        copied[pos] = "nop" + copied[pos][3..];
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void ProcessLine(string line, ref int value, ref int nextPos)
        {
            var param = int.Parse(line.Split(" ")[1].Replace("+", ""));
            switch (line[0..3])
            {
                case "nop":
                    nextPos += 1;
                    return;
                case "jmp":
                    nextPos += param;
                    return;
                case "acc":
                    nextPos += 1;
                    value += param;
                    return;
            }
        }
    }
}
