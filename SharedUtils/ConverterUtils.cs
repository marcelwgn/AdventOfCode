using System;

namespace AdventOfCode2018.SharedUtils
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
                catch (FormatException)
                {
                    numbers[i] = 0;
                }
            }
            return numbers;
        }

        public static int[] GetNumbers(string data)
        {
            return GetNumbers(data, " ");
        }

        public static int[] GetNumbers(string data, string delimeter)
        {
            return GetNumbers(data.Split(delimeter));
        }
    }

}