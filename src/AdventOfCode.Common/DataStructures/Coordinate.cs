namespace AdventOfCode.Common.DataStructures;

public record Coordinate(long X, long Y)
{
    public readonly static Coordinate North = new(0, -1);
    public readonly static Coordinate East = new(1, 0);
    public readonly static Coordinate South = new(0, 1);
    public readonly static Coordinate West = new(-1, 0);

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

    public static Coordinate operator *(Coordinate first, int scalar)
    {
        return new Coordinate(first.X * scalar, first.Y * scalar);
    }

    public static Coordinate Add(Coordinate left, Coordinate right)
    {
        return left + right;
    }

    public static Coordinate Multiply(Coordinate left, int scalar)
    {
        return left * scalar;
    }
}
