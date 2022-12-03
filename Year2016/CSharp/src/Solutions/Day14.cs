using AdventOfCode.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day14
    {
        public static MD5 md5Hash = MD5.Create();

        public static long FirstProblem(string[] data)
        {
            return Algorithm(data[0]);
        }

        public static long SecondProblem(string[] data)
        {
            return Algorithm(data[0], 2017);
        }

        private static long Algorithm(string data, int hashIterations = 1)
        {
            var tripletDictionary = new List<(char, long)>();
            long index = 0;
            long remainingRuns = 1100;

            var foundKeys = new List<long>();

            while (remainingRuns > 0)
            {
                var hashedInput = HashedInput(data + index, hashIterations);
                var tripletChar = hashedInput.FindNFoldChar(3);
                var fiveFoldChar = hashedInput.FindNFoldChar(5);
                if (fiveFoldChar.HasValue)
                {
                    foreach (var item in tripletDictionary.Where(x => x.Item1 == fiveFoldChar.Value).OrderBy(x => x.Item2))
                    {
                        if (item.Item2 + 1000 >= index)
                        {
                            Debug.WriteLine(item.Item2);
                            foundKeys.Add(item.Item2);
                        }
                    }
                }
                if (tripletChar.HasValue)
                {
                    tripletDictionary.Add((tripletChar.Value, index));
                }
                index++;
                if(foundKeys.Count >= 64)
                {
                    remainingRuns--;
                }
            }

            foundKeys.Sort();
            return foundKeys[63];
        }

        private static string HashedInput(string data, int iterations = 1)
        {
            var currentInput = data;
            while (iterations > 0)
            {
                iterations--;
                byte[] inputBytes = Encoding.ASCII.GetBytes(currentInput);
                byte[] hashBytes = md5Hash.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < hashBytes.Length; j++)
                {
                    sb.Append(hashBytes[j].ToString("X2"));
                }
                currentInput = sb.ToString().ToLower();
            }
            return currentInput;
        }

        private static char? FindNFoldChar(this string value, int consecutiveOccurence)
        {
            for (int i = 0; i < value.Length - consecutiveOccurence + 1; i++)
            {
                var curChar = value[i];
                bool valid = true;
                for (int j = 0; j < consecutiveOccurence; j++)
                {
                    if (curChar != value[i + j])
                    {
                        valid = false;
                    }
                }
                if (valid)
                {
                    return curChar;
                }
            }
            return null;
        }
    }
}
