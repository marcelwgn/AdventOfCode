using System;
using System.Linq;

namespace AdventOfCode.Common
{
    public static class StringUtils
    {
        public static bool ContainsLetterExactlyTwice(this string str)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);

            char c = chars[0];
            int curCount = 1;

            bool exactlyTwice = false;
            for (int i = 1; i < chars.Length; i++)
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
            char[] chars = str.ToCharArray();
            Array.Sort(chars);

            char c = chars[0];
            int curCount = 1;

            bool exactlyThrice = false;
            for (int i = 1; i < chars.Length; i++)
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
            int count = 0;
            for (int i = 0; i < str.Length && i < input.Length; i++)
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
            string result = "";
            for (int i = 0; i < str.Length && i < input.Length; i++)
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
