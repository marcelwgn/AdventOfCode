using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022.Solutions
{
    public static class Day05
    {
        public class Stacks
        {
            private List<LinkedList<char>> stacks = new();

            public void Insert(int stack, char value)
            {
                while (stacks.Count <= stack)
                {
                    stacks.Add(new LinkedList<char>());
                }
                stacks[stack].AddFirst(value);
            }

            public char this[int i]
            {
                get
                {
                    return stacks[i].Last();
                }
            }

            public int Count => stacks.Count;

            public void Move(int from, int to, int count, bool keepOrder)
            {
                var fromStack = stacks[from];
                var toStack = stacks[to];
                var tempStack = new LinkedList<char>();
                for (int i = 0; i < count; i++)
                {
                    tempStack.AddLast(fromStack.Last());
                    fromStack.RemoveLast();
                }
                for (int i = 0; i < count; i++)
                {
                    if (keepOrder)
                    {
                        var nextItem = tempStack.Last!;
                        tempStack.RemoveLast();
                        toStack.AddLast(nextItem);
                    }
                    else
                    {
                        var nextItem = tempStack.First!;
                        tempStack.RemoveFirst();
                        toStack.AddLast(nextItem);
                    }
                }

            }
        }

        public static Stacks CreateStack(string[] rows)
        {
            var stacks = new Stacks();

            for (int i = 0; i < rows.Length; i++)
            {
                if (!rows[i].Contains('['))
                {
                    return stacks;
                }

                var column = 0;
                for (int j = 0; j < rows[i].Length; j += 4)
                {
                    if (rows[i][j] == '[')
                    {
                        stacks.Insert(column, rows[i][j + 1]);
                    }
                    column++;
                }
            }
            return stacks;
        }

        public static string FirstProblem(string[] items)
        {
            return CoreAlgorithm(items, false);
        }
        
        public static string SecondProblem(string[] items)
        {
            return CoreAlgorithm(items, true);
        }

        private static string CoreAlgorithm(string[] items, bool moveKeepOrder)
        {
            var stacks = CreateStack(items);
            var moveSetEntry = Array.FindIndex(items, x => string.IsNullOrEmpty(x));

            for (int i = moveSetEntry + 1; i < items.Length; i++)
            {
                var commands = items[i].Split(' ');
                var count = int.Parse(commands[1]);
                var fromStack = int.Parse(commands[3]);
                var toStack = int.Parse(commands[5]);
                stacks.Move(fromStack - 1, toStack - 1, count, moveKeepOrder);
            }

            var answer = "";
            for (int i = 0; i < stacks.Count; i++)
            {
                answer += stacks[i];
            }
            return answer;
        }
    }
}
