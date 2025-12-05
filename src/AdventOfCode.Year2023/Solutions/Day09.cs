namespace AdventOfCode.Year2023.Solutions;

public static class Day09
{
    public static int[][] Convert(string[] data)
    {
        return data.Select(x => x.Split(" ").Select(int.Parse).ToArray()).ToArray();
    }

    public static long FirstProblem(int[][] data)
    {
        var sum = 0;
        foreach (var item in data)
        {
            var derivatives = CalculateDerivationHistory(item);

            var totalIncrease = derivatives.Sum(x => x[^1]);
            sum += item[^1] + totalIncrease;
        }
        return sum;
    }

    public static long SecondProblem(int[][] data)
    {
        var sum = 0;
        foreach (var item in data)
        {
            var derivatives = CalculateDerivationHistory(item);

            var lastSlope = 0;
            foreach (var derivative in derivatives)
            {
                lastSlope = derivative[0] - lastSlope;
            }
            sum += item[0] - lastSlope;
        }
        return sum;
    }

    private static Stack<int[]> CalculateDerivationHistory(int[] data)
    {
        var derivatives = new Stack<int[]>();
        var currentDerivative = CalculateDerivatives(data);
        while (currentDerivative.Any(x => x != 0))
        {
            derivatives.Push(currentDerivative);
            currentDerivative = CalculateDerivatives(currentDerivative);
        }
        return derivatives;
    }

    private static int[] CalculateDerivatives(int[] data)
    {
        var derivatives = new int[data.Length - 1];
        for (int i = 0; i < derivatives.Length; i++)
        {
            derivatives[i] = data[i + 1] - data[i];
        }
        return derivatives;
    }
}
