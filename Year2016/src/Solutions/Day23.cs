using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day23
    {
        public static long FirstProblem(string[] data)
        {
            return RunProgram(data, 7);
        }

        public static long SecondProblem(string[] data)
        {
            return RunProgram(data, 12);
        }

        private static long RunProgram(string[] data, short initialAValue)
        {
            int instructionPointer = 0;
            // We are preprocessing everything to minimize CPU cost of every instruction.
            // Char comparison is a lot faster than string comparison
            var instructions = new char[data.Length];
            // Evaluate numbers once at the start
            var numParams = new int?[data.Length, 2];
            // Store registers for the instructions
            var charParams = new char?[data.Length, 2];
            for (int i = 0; i < data.Length; i++)
            {
                var split = data[i].Split(" ");
                instructions[i] = split[0][0];
                numParams[i, 0] = null;
                numParams[i, 1] = null;
                charParams[i, 0] = null;
                charParams[i, 1] = null;

                if (int.TryParse(split[1], out int numOne))
                {
                    numParams[i, 0] = numOne;
                }
                else
                {
                    // Offsetting to array index, a->0,b->1,...
                    charParams[i, 0] = (char)(split[1][0] - 97);
                };
                if (split.Length == 3)
                {
                    if (int.TryParse(split[2], out int numTwo))
                    {
                        numParams[i, 1] = numTwo;
                    }
                    else
                    {
                    // Offsetting to array index, a->0,b->1,...
                        charParams[i, 1] = (char)( split[2][0] - 97);
                    };
                }
            }
            
            // Array since accessing arrays is faster than most other ways of storing data
            var registers = new int[]
            {
                initialAValue, 0, 0, 0
            };

            while (instructionPointer < instructions.Length)
            {
                switch (instructions[instructionPointer])
                {
                    case 'i':
                        registers[charParams[instructionPointer, 0].Value] = registers[charParams[instructionPointer, 0].Value] + 1;
                        instructionPointer++;
                        break;
                    case 'd':
                        registers[charParams[instructionPointer, 0].Value] = registers[charParams[instructionPointer, 0].Value] - 1;
                        instructionPointer++;
                        break;
                    case 'j':
                        if (ResolveValue(numParams[instructionPointer, 0], charParams[instructionPointer, 0]) != 0)
                        {
                            instructionPointer += ResolveValue(numParams[instructionPointer, 1], charParams[instructionPointer, 1]);
                        }
                        else
                        {
                            instructionPointer++;
                        }
                        break;
                    case 'c':
                        var firstParam = ResolveValue(numParams[instructionPointer, 0], charParams[instructionPointer, 0]);
                        var register = charParams[instructionPointer, 1];
                        if (register.HasValue)
                        {
                            registers[register.Value] = firstParam;
                        }
                        instructionPointer++;
                        break;
                    case 't':
                        var instructionToggleLocation = instructionPointer + ResolveValue(numParams[instructionPointer, 0], charParams[instructionPointer, 0]);
                        if (0 <= instructionToggleLocation && instructionToggleLocation < data.Length)
                        {
                            instructions[instructionToggleLocation] = ToggleInstruction(instructions[instructionToggleLocation], numParams[instructionToggleLocation, 1].HasValue || charParams[instructionToggleLocation, 1].HasValue);
                        }
                        instructionPointer++;
                        break;
                }
            }

            return registers['a' - 97];

            int ResolveValue(int? numValue, char? register)
            {
                return numValue ?? registers[register.Value];
            }

        }
        public static char ToggleInstruction(char instructionInitial, bool hasSecondParam)
        {
            if (hasSecondParam)
            {
                if (instructionInitial == 'j')
                {
                    return 'c';
                }
                else
                {
                    return 'j';
                }
            }
            else
            {
                if (instructionInitial == 'i')
                {
                    return 'd';
                }
                else
                {
                    return 'i';
                }
            }
        }
    }
}
