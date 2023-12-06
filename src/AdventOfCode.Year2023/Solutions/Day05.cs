﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdventOfCode.Year2023.Solutions
{
	public static class Day05
	{
		public record Interval(long Start, long End, long Offset);

		public class Mapper
		{
			public Interval[] Intervals { get; set; }
			public long GetMapped(long input)
			{
				foreach (var interval in Intervals)
				{
					if (interval.Start <= input && input <= interval.End)
					{
						return input - interval.Start + interval.Offset;
					}
				}
				return input;
			}
		}

		public record ParsedInput(long[] Seeds, Mapper[] Mappers);

		public static ParsedInput Convert(string[] data)
		{
			var seeds = data[0][7..].Split(" ").Select(long.Parse).ToArray();
			var mappers = new List<Mapper>();
			var currentMapper = new Mapper();
			var currentIntervals = new List<Interval>();

			for (int i = 3; i < data.Length; i++)
			{
				var curRow = data[i];

				if (curRow.Length == 0) continue;

				if (char.IsLetter(curRow[0]))
				{
					AddMapper();
					continue;
				}

				var numbers = data[i].Split(" ").Select(long.Parse).ToArray();
				currentIntervals.Add(new Interval(numbers[1], numbers[1] + numbers[2] - 1, numbers[0]));
			}
			AddMapper();

			return new ParsedInput(seeds, [.. mappers]);

			void AddMapper()
			{
				currentMapper!.Intervals = currentIntervals!.ToArray();
				mappers!.Add(currentMapper);

				currentMapper = new Mapper();
				currentIntervals.Clear();
			}
		}

		public static long FirstProblem(ParsedInput parsedInput)
		{
			return parsedInput.Seeds.Select(x => Map(x, parsedInput.Mappers)).Min();
		}

		public static long SecondProblem(ParsedInput parsedInput)
		{
			// Idea: split into smaller chunks by determining how much parallelization you can get on the current machine
			var lowestValues = new ConcurrentBag<long>();

			var totalNumberOfEntriesToCheck = 0L;
			for (int i = 0; i < parsedInput.Seeds.Length / 2; i++)
			{
				totalNumberOfEntriesToCheck += parsedInput.Seeds[i * 2 + 1];
			}

			var idealIntervalSize = totalNumberOfEntriesToCheck / Environment.ProcessorCount;

			var intervals = new List<(long Start, long Length)>();
			for (int i = 0; i < parsedInput.Seeds.Length / 2; i++)
			{
				var maxEntry = parsedInput.Seeds[i * 2] + parsedInput.Seeds[i * 2 + 1];
				var currentIndex = parsedInput.Seeds[i * 2];
				while (currentIndex < maxEntry)
				{
					var curIntervalLength = Math.Min(maxEntry - currentIndex, idealIntervalSize);

					intervals.Add(new(currentIndex, curIntervalLength));
					currentIndex += curIntervalLength;
				}
			}

			Parallel.ForEach(intervals, ((long Start, long Length) interval) =>
			{
				var lowest = Map(interval.Start, parsedInput.Mappers);
				for (long i = 0; i < interval.Length; i++)
				{
					lowest = Math.Min(lowest, Map(i + interval.Start, parsedInput.Mappers));
				}
				lowestValues.Add(lowest);
			});

			return lowestValues.Min();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static long Map(long input, Mapper[] mappers)
		{
			var curValue = input;

			foreach (var mapper in mappers)
			{
				curValue = mapper.GetMapped(curValue);
			}

			return curValue;
		}
	}
}
