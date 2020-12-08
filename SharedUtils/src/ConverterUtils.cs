using System;

namespace AdventOfCode.SharedUtils
{
    public static class ConverterUtils
    {
        public static int[] GetNumbers(string[] data)
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

        public static int[] GetNumbers(string data)
        {
            return GetNumbers(data, " ");
        }

        public static int[] GetNumbers(string data, string delimeter)
        {
            return GetNumbers(data.Split(new string[] { delimeter }, StringSplitOptions.None));
        }
    }

}