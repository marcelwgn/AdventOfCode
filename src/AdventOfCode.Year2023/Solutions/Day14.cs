using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2023.Solutions
{
	public static class Day14
	{
		public static long FirstProblem(string[] data)
		{
			var field = ToCharField(data);
			ShiftRocks(field, false, false);
			return CalculateLoad(field);
		}

		public static long SecondProblem(string[] data)
		{
			Dictionary<string, long>? cache = new();

			var field = ToCharField(data);
			var buffer = CreateBuffer(data);
			long i = 0;
			long maxValue = 1_000_000_000L * 4;
			for (; i < maxValue; i++)
			{
				switch (i % 4)
				{
					case 0:
						ShiftRocks(field, false, false); // North
						break;
					case 1:
						ShiftRocks(field, true, false); // West
						break;
					case 2:
						ShiftRocks(field, false, true); // South
						break;
					case 3:
						ShiftRocks(field, true, true); // East
						break;
				}
				SkipLoopIfPossible();
			}

			void SkipLoopIfPossible()
			{
				var toString = string.Join("", field.Select(x => string.Join("", x))) + i % 4;
				if (cache == null) return;
				if (cache.TryGetValue(toString, out var repeatingIndex))
				{
					var loopSize = i - repeatingIndex;
					while (i + loopSize < maxValue) i += loopSize;
					cache = null;
				}
				else
				{
					cache.Add(toString, i);
				}
			}

			return CalculateLoad(field);
		}

		public static char[][] CreateBuffer(string[] data)
		{
			var maxLength = Math.Max(data.Length, data[0].Length);
			var buffer = new char[maxLength][];
			for (int i = 0; i < maxLength; i++)
			{
				buffer[i] = new char[maxLength];
			}
			return buffer;
		}

		public static char[][] ToCharField(string[] data)
		{
			var field = new char[data.Length][];
			for (int i = 0; i < data.Length; i++)
			{
				field[i] = data[i].ToCharArray();
			}
			return field;
		}

		public static void ShiftRocks(char[][] field, bool tiltOnX, bool tiltFromZero)
		{
			var rowLength = tiltOnX ? field[0].Length : field.Length;
			var buffer = new char[rowLength];
			for (int i = 0; i < rowLength; i++)
			{
				TiltRowOrColumn(i);
			}

			void TiltRowOrColumn(int index)
			{
				// Copy respective row or column into buffer
				for (int i = 0; i < rowLength; i++)
				{
					buffer[i] = tiltOnX ? field[index][i] : field[i][index];
				}

				// Order sub arrays to simulate tilting
				int[] indicesToSplit = [-1, ..Enumerable.Range(0, rowLength).Where(x => buffer[x] == '#')];
				for (int i = 0; i < indicesToSplit.Length - 1; i++)
				{
					OrderSubArray(indicesToSplit[i] + 1, indicesToSplit[i+1]);
				}
				OrderSubArray(indicesToSplit[^1] + 1);

				// Write back to buffer
				for (int i = 0; i < buffer.Length; i++)
				{
					if (tiltOnX)
					{
						field[index][i] = buffer[i];
					}
					else
					{
						field[i][index] = buffer[i];
					}
				}

				void OrderSubArray(int index, int? end = null)
				{
					var supBuffer = end.HasValue ? buffer[index..end.Value] : buffer[index..];
					var ordered = tiltFromZero ? supBuffer.Order() : supBuffer.OrderDescending();
					ordered.ToArray().CopyTo(buffer, index);
				}
			}
		}

		private static long CalculateLoad(char[][] data)
		{
			var sum = 0;
			for (int i = 0; i < data.Length; i++)
			{
				sum += data[i].Count(x => x == 'O') * (data.Length - i);
			}
			return sum;
		}
	}
}
