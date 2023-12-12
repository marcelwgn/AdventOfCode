namespace AdventOfCode.Common.DataStructures
{
	public record Coordinate(int X, int Y)
	{
		public bool IsInGrid<T>(T[][] data)
		{
			return Y >= 0 && Y < data.Length && X >= 0 && X < data[0].Length;
		}

		public bool IsInGrid(string[] data)
		{
			return X >= 0 && X < data[0].Length && Y >= 0 && Y < data.Length;
		}
	}

	
}
