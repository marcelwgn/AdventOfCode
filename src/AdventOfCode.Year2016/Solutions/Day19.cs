namespace AdventOfCode.Year2016.Solutions;

public static class Day19
{
    /// <summary>
    /// This is the Josephus problem, we are using the algorithm for it.
    /// </summary>
    public static int FirstProblem(string[] data)
    {
        var num = int.Parse(data[0]);
        var maxPowerOf2 = (int)Math.Log2(num);
        var remainder = num - (int)Math.Pow(2, maxPowerOf2);
        return 2 * remainder + 1;
    }

    public static int SecondProblem(string[] data)
    {
        var num = int.Parse(data[0]);
        var currentIndex = 2;
        var currentNumber = 5;

        // The problem: We have n people, 1 starts and kills the person opposite to itsself
        // (in case of tie, pick the left person, i.e. the lower indexed person).
        // Then 2 continues killing the opposite person.
        // This process repeats until only one person is left, the index at the start is the number we want to calculate.
        // The idea behind the algorithm:
        // Calculating the problem for n can be transformed into the problem for calculating the n-1 solution.
        // Our approach is to move from n-1 to n.
        // If the current solution 'x' is larger than the half of n-1, the n solution is 'x+2', otherwise it is 'x+1'.
        // "Proof:"
        // * The n solution is the n-1 solution except we removed n/2 and we start at two meaning, our 2 is the 1 of the previous solution.
        //   That means we shift one forward from n to n-1 index wise.
        // * If the previous solution was about half, we skip the number we removed shifting the index by one more.
        // If the 'x+1' or 'x+2' is actually higher than 'n', we went around the entire circle and we start back at one.
        // Our algorithm starts with n=5 and x=2 and then moves forward using the rules above until
        // we reach n and modified 'x' correctly which will then be the solution for the problem of 'n'.
        while (currentNumber < num)
        {
            currentNumber++;
            if (currentIndex >= currentNumber / 2)
            {
                currentIndex += 2;
            }
            else
            {
                currentIndex++;
            }

            if (currentIndex > currentNumber)
            {
                currentIndex = 1;
            }
        }
        return currentIndex;
    }
}
