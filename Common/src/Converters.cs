using System;
using System.Linq;

namespace AdventOfCode.Common
{
    public static class Converters
    {
        public static int[] ToIntArray(this string[] data)
        {
            var numbers = new int[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                try
                {
                    numbers[i] = int.Parse(data[i]);
                }
                catch (FormatException)
                {
                    numbers[i] = 0;
                }
            }
            return numbers;
        }

        public static long[] ToLongArray(this string[] data)
        {
            var numbers = new long[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                try
                {
                    numbers[i] = long.Parse(data[i]);
                }
                catch (FormatException)
                {
                    numbers[i] = 0;
                }
            }
            return numbers;
        }

        public static char[][] ToCharArray(this string[] data)
        {
            return data.Select(item => item.ToArray()).ToArray();
        }

        public static int[] GetNumbers(string data)
        {
            return GetNumbers(data, " ");
        }

        public static int[] GetNumbers(string data, string delimeter)
        {
            return data.Split(new string[] { delimeter }, StringSplitOptions.None).ToIntArray();
        }
    }

}