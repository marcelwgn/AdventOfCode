namespace AdventOfCode.Year2023.Solutions;

public class CamelHand
{
    public string Hand { get; set; }
    public long Bid { get; set; }
    public short ScoreNormal { get; set; }
    public short ScoreJokerRules { get; set; }

    public CamelHand(string hand, long bid)
    {
        Bid = bid;
        Hand = hand;

        var cardCount = GetCharacterCounts(false).OrderDescending().ToArray();
        ScoreNormal = CalculateScore(cardCount);

        var cardCountWithoutJokers = GetCharacterCounts(true).OrderDescending().ToArray();
        var jokerCount = Hand.Count(c => c == 'J');
        if (cardCountWithoutJokers.Length == 0)
        {
            cardCountWithoutJokers = [jokerCount];
        }
        else
        {
            cardCountWithoutJokers[0] += jokerCount;
        }
        ScoreJokerRules = CalculateScore(cardCountWithoutJokers);

        IEnumerable<int> GetCharacterCounts(bool ignoreJokers)
        {
            foreach (var card in Hand.Distinct().ToArray())
            {
                if (ignoreJokers && card == 'J') continue;

                yield return Hand.Count(c => c == card);
            }
        }
    }

    private static short CalculateScore(int[] cardCount)
    {
        if (cardCount is [5])
        {
            return 10;
        }
        else if (cardCount is [4, 1])
        {
            return 9;
        }
        else if (cardCount is [3, 2])
        {
            return 8;
        }
        else if (cardCount is [3, 1, 1])
        {
            return 7;
        }
        else if (cardCount is [2, 2, 1])
        {
            return 6;
        }
        else if (cardCount is [2, 1, 1, 1])
        {
            return 5;
        }
        else
        {
            return 4;
        }
    }
}

public class CamelHandNormalRulesComperator : IComparer<CamelHand>
{
    private static readonly char[] CardOrder = ['A',
        'K',
        'Q',
        'J',
        'T',
        '9',
        '8',
        '7',
        '6',
        '5',
        '4',
        '3',
        '2'
    ];

    public int Compare(CamelHand? x, CamelHand? y)
    {
        if (x is null || y is null) return 0;

        var scoreDiff = x.ScoreNormal - y.ScoreNormal;
        // Use score diff if they don't have the same score
        if (scoreDiff != 0) return scoreDiff;

        // Use highest card to determine better hand
        for (int i = 0; i < 5; i++)
        {
            var charDiff = Array.IndexOf(CardOrder, y.Hand[i])
                - Array.IndexOf(CardOrder, x.Hand[i]);
            if (charDiff != 0)
            {
                return charDiff;
            }
        }
        return 0;
    }
}

public class CamelHandJokerRulesComperator : IComparer<CamelHand>
{
    private static readonly char[] CardOrder = ['A',
        'K',
        'Q',
        'T',
        '9',
        '8',
        '7',
        '6',
        '5',
        '4',
        '3',
        '2',
        'J',
    ];

    public int Compare(CamelHand? x, CamelHand? y)
    {
        if (x is null || y is null) return 0;

        var scoreDiff = x.ScoreJokerRules - y.ScoreJokerRules;
        // Use score diff if they don't have the same score
        if (scoreDiff != 0) return scoreDiff;

        // Use highest card to determine better hand
        for (int i = 0; i < 5; i++)
        {
            var charDiff = Array.IndexOf(CardOrder, y.Hand[i])
                - Array.IndexOf(CardOrder, x.Hand[i]);
            if (charDiff != 0)
            {
                return charDiff;
            }
        }
        return 0;
    }
}

public static class Day07
{
    public static IEnumerable<CamelHand> Convert(string[] data)
    {
        return data.Select(x => new CamelHand(x.Split(" ")[0], long.Parse(x.Split(" ")[1])));
    }

    public static long FirstProblem(IEnumerable<CamelHand> hands)
    {
        return CalculateUsingRules(hands, new CamelHandNormalRulesComperator());
    }

    public static long SecondProblem(IEnumerable<CamelHand> hands)
    {
        return CalculateUsingRules(hands, new CamelHandJokerRulesComperator());
    }

    private static long CalculateUsingRules(IEnumerable<CamelHand> hands, IComparer<CamelHand> handComperator)
    {
        var count = 1L;
        return hands.Order(handComperator).Select(x => x.Bid * count++).Sum();
    }
}
