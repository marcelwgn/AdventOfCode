﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Solutions
{
	public class Stacks
	{
		private readonly List<LinkedList<char>> stacks = [];

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
			for (var i = 0; i < count; i++)
			{
				tempStack.AddLast(fromStack.Last());
				fromStack.RemoveLast();
			}
			for (var i = 0; i < count; i++)
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

	public static class Day05
    {
        public static Stacks CreateStack(string[] rows)
        {
            var stacks = new Stacks();

            for (var i = 0; i < rows.Length; i++)
            {
                if (!rows[i].Contains('['))
                {
                    return stacks;
                }

                var column = 0;
                for (var j = 0; j < rows[i].Length; j += 4)
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
            var moveSetEntry = Array.FindIndex(items, string.IsNullOrEmpty);

            for (var i = moveSetEntry + 1; i < items.Length; i++)
            {
                var commands = items[i].Split(' ');
                var count = int.Parse(commands[1]);
                var fromStack = int.Parse(commands[3]);
                var toStack = int.Parse(commands[5]);
                stacks.Move(fromStack - 1, toStack - 1, count, moveKeepOrder);
            }

            var answer = "";
            for (var i = 0; i < stacks.Count; i++)
            {
                answer += stacks[i];
            }
            return answer;
        }
    }
}
