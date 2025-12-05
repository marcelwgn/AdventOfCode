namespace AdventOfCode.Year2025.Solutions;

public struct Range
{
    public long IMin { get; set; }
    public long IMax { get; set; }

    public bool Overlaps(Range range)
    {
        return (range.IMin <= this.IMax && range.IMin >= this.IMin) || (range.IMax <= this.IMax && range.IMax >= this.IMin);
    }

    public Range Merged(Range range)
    {
        return new Range()
        {
            IMin = Math.Min(IMin, range.IMin),
            IMax = Math.Max(IMax, range.IMax)
        };
    }
}

public static class Day05
{
    public static string FirstProblem(string[] input)
    {
        List<long> rgnIngredients = new();
        HashSet<long> hsValidIngredients = new();
        int iSeparator = input.IndexOf("");
        for (int iIngredients = iSeparator + 1; iIngredients < input.Length; iIngredients++)
        {
            rgnIngredients.Add(long.Parse(input[iIngredients]));
        }

        rgnIngredients.Sort();


        for (int iRange = 0; iRange < iSeparator; iRange++)
        {
            string[] rgstRangeParams = input[iRange].Split('-');
            long iRangeMin = long.Parse(rgstRangeParams[0]);
            long iRangeMax = long.Parse(rgstRangeParams[1]);

            foreach (long nIngredient in rgnIngredients)
            {
                if (nIngredient >= iRangeMin && nIngredient <= iRangeMax)
                {
                    hsValidIngredients.Add(nIngredient);
                }
            }
        }

        return hsValidIngredients.Count.ToString();
    }

    public static string SecondProblem(string[] input)
    {
        List<Range> rgrangeIngredients = new();
        foreach (string stRow in input)
        {
            if (string.IsNullOrWhiteSpace(stRow))
            {
                break;
            }
            string[] rgstRangeParams = stRow.Split('-');
            long iRangeMin = long.Parse(rgstRangeParams[0]);
            long iRangeMax = long.Parse(rgstRangeParams[1]);
            rgrangeIngredients.Add(new Range() { IMin = iRangeMin, IMax = iRangeMax });
        }

        rgrangeIngredients.Sort((a, b) => a.IMin.CompareTo(b.IMin));

        List<Range> rgrangeMergedRanges = new();
        Range currentRange = rgrangeIngredients[0];

        for (int iRange = 1; iRange < rgrangeIngredients.Count; iRange++)
        {
            if (currentRange.Overlaps(rgrangeIngredients[iRange]) || currentRange.IMax + 1 == rgrangeIngredients[iRange].IMin)
            {
                currentRange = currentRange.Merged(rgrangeIngredients[iRange]);
            }
            else
            {
                rgrangeMergedRanges.Add(currentRange);
                currentRange = rgrangeIngredients[iRange];
            }
        }
        rgrangeMergedRanges.Add(currentRange);


        return rgrangeMergedRanges.Select(range => range.IMax - range.IMin + 1).Sum().ToString();
    }
}
