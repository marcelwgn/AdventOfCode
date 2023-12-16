namespace AdventOfCode.Common.DataStructures
{
	public record Coordinate(long X, long Y)
	{
		public bool IsInGrid<T>(T[][] data)
		{
			return Y >= 0 && Y < data.Length && X >= 0 && X < data[0].Length;
		}

		public bool IsInGrid(string[] data)
		{
			return X >= 0 && X < data[0].Length && Y >= 0 && Y < data.Length;
		}

		public static Coordinate operator +(Coordinate first, Coordinate second)
		{
			return new Coordinate(first.X + second.X, first.Y + second.Y);
		}

		public static Coordinate Add(Coordinate left, Coordinate right)
		{
			return left + right;
		}
	}
}
