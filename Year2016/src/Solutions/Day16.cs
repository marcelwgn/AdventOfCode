using System;
using System.Linq;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day16
    {
        public static byte[] Convert(string[] data) => data[0].Select(x => x == '0' ? (byte)0 : (byte)1).ToArray();

        public static string FirstProblem(byte[] data)
        {
            var pattern = FillWithDragonCurve(data, 272);
            while (pattern.Length % 2 == 0)
            {
                pattern = CalculatePattern(pattern);
            }
            return string.Join("", pattern);
        }

        public static string SecondProblem(byte[] data)
        {
            var pattern = FillWithDragonCurve(data, 35651584);
            while (pattern.Length % 2 == 0)
            {
                pattern = CalculatePattern(pattern);
            }
            return string.Join("", pattern);
        }

        public static byte[] CalculatePattern(byte[] input)
        {
            for (var i = 0; i < input.Length; i += 2)
            {
                input[i / 2] = input[i] != input[i + 1] ? (byte)0 : (byte)1;
            }
            return input[0..(input.Length / 2)];
        }

        public static byte[] FillWithDragonCurve(byte[] input, int desiredLength)
        {
            if (input.Length == desiredLength)
            {
                return input;
            }
            var currentLastIndex = input.Length;
            var target = new byte[desiredLength];
            Array.Copy(input, target, input.Length);
            while (currentLastIndex < desiredLength - 1)
            {
                target[currentLastIndex + 1] = 0;
                for (var i = 0; i < Math.Min(currentLastIndex, desiredLength - currentLastIndex - 1); i++)
                {
                    target[i + currentLastIndex + 1] = target[currentLastIndex - i - 1] == 0 ? (byte)1 : (byte)0;
                }
                currentLastIndex = currentLastIndex * 2 + 1;
            }
            return target;
        }
    }
}
