using System;
using System.Linq;

namespace AdventOfCode.Common.Extensions
{
    public static class StringUtils
    {
        public static bool ContainsLetterExactlyTwice(this string str)
        {
            var chars = str.ToCharArray();
            Array.Sort(chars);

            var c = chars[0];
            var curCount = 1;

            var exactlyTwice = false;
            for (var i = 1; i < chars.Length; i++)
            {
                if (c == chars[i])
                {
                    curCount++;
                }
                else
                {
                    if (curCount == 2)
                    {
                        exactlyTwice = true;
                    }
                    curCount = 1;

                }
                c = chars[i];
            }
            if (curCount == 2)
            {
                exactlyTwice = true;
            }
            return exactlyTwice;
        }

        public static bool ContainsLetterExactlyThrice(this string str)
        {
            var chars = str.ToCharArray();
            Array.Sort(chars);

            var c = chars[0];
            var curCount = 1;

            var exactlyThrice = false;
            for (var i = 1; i < chars.Length; i++)
            {
                if (c == chars[i])
                {
                    curCount++;
                }
                else
                {
                    if (curCount == 3)
                    {
                        exactlyThrice = true;
                    }
                    curCount = 1;

                }
                c = chars[i];
            }
            if (curCount == 3)
            {
                exactlyThrice = true;
            }
            return exactlyThrice;
        }

        public static int NumberOfLettersDifferent(this string str, string input)
        {
            var count = 0;
            for (var i = 0; i < str.Length && i < input.Length; i++)
            {
                if (str[i] != input[i])
                {
                    count++;
                }
            }
            return count;
        }

        public static string GetCommonLetters(this string str, string input)
        {
            var result = "";
            for (var i = 0; i < str.Length && i < input.Length; i++)
            {
                if (str[i] == input[i])
                {
                    result += str[i];
                }
            }
            return result;
        }

        public static char[] GetColumn(this string[] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.Length)
                    .Select(x => matrix[x][columnNumber])
                    .ToArray();
        }
    }
}
