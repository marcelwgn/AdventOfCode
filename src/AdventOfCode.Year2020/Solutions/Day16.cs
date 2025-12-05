using AdventOfCode.Common;

namespace AdventOfCode.Year2020.Solutions;

public static class Day16
{
    public static int FirstProblem(string[] data)
    {
        // Get data bounds
        var endOfRules = Array.IndexOf(data, "your ticket:") - 1;
        var endOfPersonalTicket = Array.IndexOf(data, "nearby tickets:") + 1;

        var validNumbers = GetValidNumbers(data[0..endOfRules]);
        var invalidSum = 0;

        for (var i = endOfPersonalTicket; i < data.Length; i++)
        {
            var numbers = data[i].Split(',').ToIntArray();
            foreach (var item in numbers)
            {
                if (!validNumbers.Contains(item))
                {
                    invalidSum += item;
                }
            }
        }

        return invalidSum;
    }

    public static long SecondProblem(string[] data)
    {
        var map = GetCategoryMap(data);
        var numbers = data[Array.IndexOf(data, "your ticket:") + 1].Split(',').ToIntArray();
        var result = 1L;

        for (var i = 0; i < numbers.Length; i++)
        {
            if (map[i].Contains("departure"))
            {
                result *= numbers[i];
            }
        }

        return result;
    }

    public static string[] GetCategoryMap(string[] data)
    {
        // Get data bounds
        var propertyCount = Array.IndexOf(data, "your ticket:") - 1;
        var endOfPersonalTicket = Array.IndexOf(data, "nearby tickets:") + 1;

        // Calculate categories
        var categories = new Dictionary<string, HashSet<int>>();
        for (var i = 0; i < propertyCount; i++)
        {
            var label = data[i].Split(':')[0];
            categories.Add(label, GetValidNumbers([data[i]]));
        }

        // Get valid tickets
        var validTickets = new List<string>();
        for (var i = endOfPersonalTicket; i < data.Length; i++)
        {
            var numbers = data[i].Split(',').ToIntArray();
            if (numbers.All(num => categories.Values.Any(dict => dict.Contains(num))))
            {
                validTickets.Add(data[i]);
            }
        }

        // Determine categories for each property
        var categoryMap = new HashSet<string>[propertyCount];
        for (var i = 0; i < categoryMap.Length; i++)
        {
            categoryMap[i] = [.. categories.Keys];
        }

        // Remove entires that are not valid
        for (var i = 0; i < validTickets.Count; i++)
        {
            var numbers = validTickets[i].Split(',').ToIntArray();
            for (var numberIndex = 0; numberIndex < numbers.Length; numberIndex++)
            {
                foreach (var label in categories.Keys)
                {
                    if (!categories[label].Contains(numbers[numberIndex]))
                    {
                        categoryMap[numberIndex].Remove(label);
                    }
                }
            }
        }

        // Get categories distinct
        var categoryList = new string[propertyCount];
        var usedItems = new HashSet<string>();
        for (var i = 0; i < categoryList.Length; i++)
        {
            if (categoryMap[i].Count == 1)
            {
                categoryList[i] = categoryMap[i].First();
                usedItems.Add(categoryList[i]);
            }
        }

        // Remove entries that have already been used and assign values to fields where only one valid value is left
        while (Array.IndexOf(categoryList, null) != -1)
        {
            foreach (var set in categoryMap)
            {
                foreach (var item in usedItems)
                {
                    set.Remove(item);
                }
            }
            for (var i = 0; i < categoryList.Length; i++)
            {
                if (categoryMap[i].Count == 1)
                {
                    categoryList[i] = categoryMap[i].First();
                    usedItems.Add(categoryList[i]);
                }
            }
        }

        return categoryList;
    }

    public static HashSet<int> GetValidNumbers(string[] data)
    {
        var valids = new HashSet<int>(1000);
        foreach (var item in data)
        {
            var actual = item.Split(':')[1].Split("or");
            var firstRange = actual[0].Split('-');
            var firstLower = int.Parse(firstRange[0]);
            var firstUpper = int.Parse(firstRange[1]);
            for (var i = firstLower; i <= firstUpper; i++)
            {
                valids.Add(i);
            }

            var secondRange = actual[1].Split('-');
            var secondLower = int.Parse(secondRange[0]);
            var secondUpper = int.Parse(secondRange[1]);
            for (var i = secondLower; i <= secondUpper; i++)
            {
                valids.Add(i);
            }
        }
        return valids;
    }
}
