using System;
using System.Linq;

namespace AdventOfCode.SharedUtils
{
    public static class ConverterUtils
    {
        public static int[] ToIntArray(this string[] data)
        {
            int[] numbers = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    numbers[i] = Convert.ToInt32(data[i]);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (FormatException)
                {
                    numbers[i] = 0;
                }
#pragma warning restore CA1031 // Do not catch general exception types
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