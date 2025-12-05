namespace AdventOfCode.Year2023.Solutions;

public record Races(long[] Times, long[] Distances);

public static class Day06
{

    public static Races Convert(string[] data)
    {
        var times = GetEntries(data[0]);
        var distances = GetEntries(data[1]);

        return new Races(times, distances);

        static long[] GetEntries(string input)
        {
            return input[10..].Split(" ").Where(x => x.Length > 0).Select(long.Parse).ToArray();
        }
    }

    public static long FirstProblem(Races races)
    {
        var product = 1L;
        for (int i = 0; i < races.Times.Length; i++)
        {
            var (FirstRoot, SecondRoot) = CalculateRoots(races.Times[i], races.Distances[i]);
            product *= SecondRoot - FirstRoot + 1;
        }
        return product;
    }

    public static long SecondProblem(Races races)
    {
        var time = long.Parse(string.Join("", races.Times));
        var distance = long.Parse(string.Join("", races.Distances));

        var (FirstRoot, SecondRoot) = CalculateRoots(time, distance);
        return SecondRoot - FirstRoot + 1;
    }

    private static (long FirstRoot, long SecondRoot) CalculateRoots(long time, long minDistance)
    {
        // Idea: let f(x)=distance travelled where x is the time the boat is being charged
        // velocity(x) = x
        // distance(x) = velocity(x) * (time - x) = time*x - x*x
        // Relative to winner
        // distance(x) = -x^2 + time*x - minDistance
        //
        // ****** Roots of a polynomial of degree 2 *******
        // f(x) = ax^2 + bx +c
        // x_1 = (-b + sqrt(b^2 - 4ac)) / (2a)
        // x_2 = (-b - sqrt(b^2 - 4ac)) / (2a)
        //
        // In our case a = -1, b = time, c = -mindistance giving us:
        // x_1 = (-time + sqrt(time^2 - 4*minDistance) / -2 
        // x_2 = (-time - sqrt(time^2 - 4*minDistance) / -2 

        var firstRoot = (-time + Math.Sqrt(time * time - 4 * minDistance)) / -2;
        var secondRoot = (-time - Math.Sqrt(time * time - 4 * minDistance)) / -2;

        // Now we need to clamp those entries in way that makes sense in our scenario:
        // If a root is an integer, we need to move it to the next value such that f(x)>0

        // First root moves to the center of the polynomial so to the right
        if (Math.Abs(firstRoot - Math.Floor(firstRoot)) < double.Epsilon) firstRoot += 1;

        // Second root moves to the center of the polynomial so the the left
        if (Math.Abs(secondRoot - Math.Ceiling(secondRoot)) < double.Epsilon) secondRoot -= 1;

        return ((long)Math.Ceiling(firstRoot), (long)Math.Floor(secondRoot));
    }
}
