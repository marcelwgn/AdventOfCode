using AdventOfCode.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day12
    {
        public static long FirstProblem(string[] data)
        {
            return RunProgram(data, 0);
        }

        public static long SecondProblem(string[] data)
        {
            return RunProgram(data, 1);
        }

        private static long RunProgram(string[] data, int initalCValue)
        {
            int instructionPointer = 0;
            var registers = new Dictionary<char, int>()
            {
                {'a',0 },
                {'b',0 },
                {'c',initalCValue },
                {'d',0 }
            };

            while (instructionPointer < data.Length)
            {
                var currentInstruction = data[instructionPointer];
                switch (currentInstruction[..3])
                {
                    case "inc":
                        registers[currentInstruction[4]] = registers[currentInstruction[4]] + 1;
                        instructionPointer++;
                        break;
                    case "dec":
                        registers[currentInstruction[4]] = registers[currentInstruction[4]] - 1;
                        instructionPointer++;
                        break;
                    case "jnz":
                        if (ResolveValue(currentInstruction[4..]) != 0)
                        {
                            instructionPointer += int.Parse(currentInstruction.Split(" ")[2]);
                        }
                        else
                        {
                            instructionPointer++;
                        }
                        break;
                    case "cpy":
                        var firstParam = currentInstruction.Split(" ")[1];
                        var register = currentInstruction.Split(" ")[2];
                        registers[register[0]] = ResolveValue(firstParam);
                        instructionPointer++;
                        break;
                }
            }

            return registers['a'];

            int ResolveValue(string value)
            {
                var number = 0;
                if (int.TryParse(value.Split(" ")[0], out number))
                {
                    return number;
                }
                else
                {
                    return registers[value[0]];
                }
            }
        }
    }
}
