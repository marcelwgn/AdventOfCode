using System;
using System.Linq;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day10
    {
        public static long FirstProblem(string[] data)
        {
            var bots = GenerateBots(data);
            return ProcessInput(data, bots, (61, 17)).FoundComparison;
        }

        public static long SecondProblem(string[] data)
        {
            var bots = GenerateBots(data);
            var outputs = ProcessInput(data, bots, (-1, -1)).Outputs;
            return outputs[0]!.Value * outputs[1]!.Value * outputs[2]!.Value;
        }

        private static void Insert(ref this (int?, int?) tuple, int value)
        {
            if (tuple.Item1 == null)
            {
                tuple.Item1 = value;
            }
            else
            {
                tuple.Item2 = Math.Max(tuple.Item1.Value, value);
                tuple.Item1 = Math.Min(tuple.Item1.Value, value);
            }
        }

        public static (int?, int?)[] GenerateBots(string[] input)
        {
            var maxNumberMovePartOne = input.Where(x => x[0] == 'b').Select(x => int.Parse(x.Split(' ')[6])).Max();
            var maxNumberMovePartTwo = input.Where(x => x[0] == 'b').Select(x => int.Parse(x.Split(' ')[11])).Max();
            var botValueInstructions = input.Where(x => x[0] == 'v').ToArray();
            var maxNumberBotSetValue = botValueInstructions.Select(y => int.Parse(y.Split(" ")[5])).Max() + 1;

            var size = Math.Max(maxNumberBotSetValue, Math.Max(maxNumberMovePartOne, maxNumberMovePartTwo)) + 1;
            var values = new (int?, int?)[size];
            Array.Fill(values, (null, null));
            foreach (var instruction in botValueInstructions)
            {
                var split = instruction.Split(' ');
                var value = int.Parse(split[1]);
                var bot = int.Parse(split[5]);
                values[bot].Insert(value);
            }

            return values;
        }

        public static (int FoundComparison, int?[] Outputs) ProcessInput(string[] input, (int?, int?)[] bots, (int, int) comparison)
        {
            var outputs = new int?[bots.Length];
            (int?, int?) sortedComparison = (Math.Min(comparison.Item1, comparison.Item2), Math.Max(comparison.Item1, comparison.Item2));
            Array.Fill(outputs, null);

            var moveInstructions = input.Where((x) => x[0] == 'b').ToHashSet();

            var twoEntrybot = FindTwoEntryBot(bots);
            while (twoEntrybot > -1)
            {
                var instruction = moveInstructions.Where((x) => int.Parse(x.Split(' ')[1]) == twoEntrybot).First();
                var split = instruction.Split(' ');
                if (bots[twoEntrybot] == sortedComparison)
                {
                    return (twoEntrybot, outputs);
                }
                var firstIsOutput = split[5][0] == 'o';
                var SecondIsOutput = split[10][0] == 'o';
                var firstIndex = int.Parse(split[6]);
                var secondIndex = int.Parse(split[11]);
                if (firstIsOutput)
                {
                    outputs[firstIndex] = bots[twoEntrybot].Item1;
                }
                else
                {
                    bots[firstIndex].Insert(bots[twoEntrybot].Item1!.Value);
                }
                if (SecondIsOutput)
                {
                    outputs[secondIndex] = bots[twoEntrybot].Item2;
                }
                else
                {
                    bots[secondIndex].Insert(bots[twoEntrybot].Item2!.Value);
                }
                bots[twoEntrybot] = (null, null);
                twoEntrybot = FindTwoEntryBot(bots);
            }

            static int FindTwoEntryBot((int?, int?)[] curBots)
            {
                for (var i = 0; i < curBots.Length; i++)
                {
                    if (curBots[i].Item1.HasValue && curBots[i].Item2.HasValue)
                    {
                        return i;
                    }
                }
                return -1;
            }
            return (-1, outputs);
        }
    }
}
