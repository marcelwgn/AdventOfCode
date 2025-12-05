namespace AdventOfCode.Year2022.Solutions;

public static class Day10
{

    public static long FirstProblem(string[] data)
    {
        var xHistory = SimulateCPUInstructions(data);
        return xHistory[19] * 20 + xHistory[59] * 60 + xHistory[99] * 100 + xHistory[139] * 140 + xHistory[179] * 180 + xHistory[219] * 220;
    }

    public static string SecondProblem(string[] data)
    {
        var xHistory = SimulateCPUInstructions(data);
        var screen = "";

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                var historyIndex = i * 40 + j;
                if (Math.Abs(xHistory[historyIndex] - j) < 2)
                {
                    screen += "#";
                }
                else
                {
                    screen += ".";
                }
            }
            screen += Environment.NewLine;
        }

        return screen;
    }

    private static int[] SimulateCPUInstructions(string[] data)
    {
        var instructionPointer = 0;
        var xRegister = 1;
        var xHistory = new int[240];

        for (int i = 0; i < xHistory.Length; i++)
        {
            xHistory[i] = xRegister;
            if (data[instructionPointer] != "noop")
            {
                var split = data[instructionPointer].Split();
                var increment = int.Parse(split[1]);
                i++;
                xHistory[i] = xRegister;
                xRegister += increment;
            }
            instructionPointer = (instructionPointer + 1) % data.Length;
        }

        return xHistory;
    }

}
