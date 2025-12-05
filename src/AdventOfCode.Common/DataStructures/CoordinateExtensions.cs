namespace AdventOfCode.Common.DataStructures;

public static class CoordinateExtensions
{
    public static T Get<T>(this T[][] data, Coordinate coordinate)
    {
        return data[coordinate.Y][coordinate.X];
    }

    public static T? GetSafe<T>(this T[][] data, Coordinate coordinate)
    {
        if (coordinate.Y < 0 || coordinate.Y >= data.Length || coordinate.X < 0 || coordinate.X >= data[coordinate.Y].Length)
        {
            return default;
        }
        return data[coordinate.Y][coordinate.X];
    }

    public static void Set<T>(this T[][] data, Coordinate coordinate, T value)
    {
        data[coordinate.Y][coordinate.X] = value;
    }

    public static char Get(this string[] data, Coordinate coordinate)
    {
        return data[coordinate.Y][(int)coordinate.X];
    }
}
