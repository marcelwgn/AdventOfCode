using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Solutions
{
    public static class Day03
    {
        private static int GetPriority(char item)
        {
            if (char.IsLower(item))
            {
                return item - 96;
            }
            else
            {
                return item - 64 + 26;
            }
        }

        public static long FirstProblem(string[] items)
        {
            long score = 0;
            foreach (var item in items)
            {
                var sameCharacter = GetSameCharacters(item).First();
                score += GetPriority(sameCharacter);
            }
            return score;
        }
        public static long SecondProblem(string[] items)
        {
            long score = 0;
            for (var i = 0; i < items.Length; i += 3)
            {
                var firstItems = items[i];
                var secondItems = items[i + 1];
                var thirdItems = items[i + 2];
                var sharedCharacter = firstItems.Intersect(secondItems).Intersect(thirdItems).First();
                score += GetPriority(sharedCharacter);
            }
            return score;
        }

        private static IEnumerable<char> GetSameCharacters(string item)
        {
            var firstPart = item[0..(item.Length / 2)];
            var secondPart = item[(item.Length / 2)..];
            var sameCharacter = firstPart.Intersect(secondPart);
            return sameCharacter;
        }
    }
}
