namespace AdventOfCode.Year2022.Solutions
{
    public static class Day02
    {
        public static long FirstProblem(string[] runs)
        {
            // 0 = Rock, 1 = Paper, 2 = Scissors
            // First position: Opponent's move
            // Second position: My move
            var WinArray = new int[,]{
                { 3, 6, 0 },
                { 0, 3, 6 },
                { 6, 0, 3 }
            };

            var score = 0;

            foreach (var entry in runs)
            {
                score += entry[2] switch
                {
                    'X' => 1,
                    'Y' => 2,
                    'Z' => 3,
                    _ => 0
                };
                var opponentMove = entry[0] switch
                {
                    'A' => 0,
                    'B' => 1,
                    'C' => 2,
                    _ => 0
                };
                var ownMove = entry[2] switch
                {
                    'X' => 0,
                    'Y' => 1,
                    'Z' => 2,
                    _ => 0
                };

                score += WinArray[opponentMove, ownMove];
            }
            return score;
        }
        public static long SecondProblem(string[] runs)
        {
            // First entry: Opponents choosing (e.g. paper)
            // Second entry: Wether to lose (0), draw (1) or win (2)
            var moves = new int[,]{
                {3,1,2},
                {1,2,3},
                {2,3,1},
            };

            var score = 0;

            foreach (var entry in runs)
            {
                score += entry[2] switch
                {
                    'X' => 0,
                    'Y' => 3,
                    'Z' => 6,
                    _ => 0
                };
                var opponentMove = entry[0] switch
                {
                    'A' => 0,
                    'B' => 1,
                    'C' => 2,
                    _ => 0
                };
                var ownMove = entry[2] switch
                {
                    'X' => 0,
                    'Y' => 1,
                    'Z' => 2,
                    _ => 0
                };

                score += moves[opponentMove, ownMove];
            }
            return score;
        }
    }
}
