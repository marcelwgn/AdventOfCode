namespace AdventOfCode.Year2020.Solutions
{
    public static class Day13
    {

        public static int FirstProblem(int minutes, string busLines)
        {
            var bestMinutes = int.MaxValue;
            var score = 0;
            foreach (var item in busLines.Split(","))
            {
                if (int.TryParse(item, out var line))
                {
                    var waitingTime = (minutes / line * line - minutes + line) % line;
                    if (waitingTime < bestMinutes)
                    {
                        bestMinutes = waitingTime;
                        score = (waitingTime % line) * line;
                    }
                }
            }

            return score;
        }

        public static long SecondProblem(string busLines)
        {
            // Conveniently, numbers are coprimes so we can use https://en.wikipedia.org/wiki/Chinese_remainder_theorem

            var split = busLines.Split(",");
            var busNumbers = new long[split.Length];
            for (var i = 0; i < split.Length; i++)
            {
                if (int.TryParse(split[i], out var parsed))
                {
                    busNumbers[i] = parsed;
                }
            }

            var nProd = busNumbers[0]; // 'N' defined as product of all 'n_i' aka bus numbers
            for (var i = 1; i < busNumbers.Length; i++)
            {
                if (busNumbers[i] != 0)
                {
                    nProd *= busNumbers[i];
                }
            }

            var nProds = new long[busNumbers.Length]; // 'N_i' defined as 'N / n_i'
            for (var i = 0; i < busNumbers.Length; i++)
            {
                if (busNumbers[i] != 0)
                {
                    nProds[i] = nProd / busNumbers[i];
                }
            }

            var remainders = new long[busNumbers.Length]; // 'b_i' defined as offset to start aka wanted remainder
            for (var i = 0; i < busNumbers.Length; i++)
            {
                if (busNumbers[i] != 0)
                {
                    remainders[i] = busNumbers[i] - i;
                }
            }

            var xVals = new int[busNumbers.Length]; // 'x_i' defined as smallest number such that 'N_i * x_i % b_i == 1'
            for (var i = 0; i < busNumbers.Length; i++)
            {
                if (busNumbers[i] != 0)
                {
                    var j = 1;
                    while (true)
                    {
                        if (nProds[i] * j % busNumbers[i] == 1)
                        {
                            break;
                        }
                        j++;
                    }
                    xVals[i] = j;
                }
            }

            long total = 0;
            // Solution is sum of 'b_i * N_i * x_i % N'
            for (var i = 0; i < busNumbers.Length; i++)
            {
                if (busNumbers[i] != 0)
                {
                    total += remainders[i] * nProds[i] * xVals[i];
                }
            }
            return total % nProd;
        }
    }
}
