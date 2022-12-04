using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day14
    {
        public static long FirstProblem(string[] data)
        {
            var mask = data[0].Split(" ")[2].ToCharArray();
            var result = new Dictionary<int, long>();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("mask"))
                {
                    // Update mask
                    mask = data[i].Split(" ")[2].ToCharArray();
                }
                else
                {
                    var num = int.Parse(data[i].Split(" ")[2]);
                    var address = int.Parse(data[i].Split("]")[0][4..].ToString());

                    // Calculate number mask
                    var numBin = Convert.ToString(num, 2).PadLeft(36, '0').ToCharArray();
                    for (int j = 0; j < mask.Length; j++)
                    {
                        if (mask[j] != 'X')
                        {
                            numBin[j] = mask[j];
                        }
                    }

                    long numSum = ConvertToLong(numBin);

                    if (!result.ContainsKey(address))
                    {
                        result.Add(address, numSum);
                    }
                    else
                    {
                        result[address] = numSum;
                    }
                }
            }

            var sum = 0L;
            foreach (var item in result.Values)
            {
                sum += item;
            }
            return sum;
        }

        public static long SecondProblem(string[] data)
        {
            var mask = data[0].Split(" ")[2].ToCharArray();
            var result = new Dictionary<long, long>();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("mask"))
                {
                    // Update mask
                    mask = data[i].Split(" ")[2].ToCharArray();
                }
                else
                {
                    var num = int.Parse(data[i].Split(" ")[2]);
                    var address = int.Parse(data[i].Split("]")[0][4..].ToString());

                    // Get address mask
                    var addressBin = Convert.ToString(address, 2).PadLeft(36, '0').ToCharArray();
                    for (int j = 0; j < mask.Length; j++)
                    {
                        if (mask[j] != '0')
                        {
                            addressBin[j] = mask[j];
                        }
                    }

                    // Get all possible addresses
                    var addresses = new List<string>() { new string(addressBin) };
                    for (int bitIndex = 0; bitIndex < 36; bitIndex++)
                    {
                        var currentCount = addresses.Count;
                        for (int addressIndex = 0; addressIndex < currentCount; addressIndex++)
                        {
                            if (addresses[addressIndex][bitIndex] == 'X')
                            {
                                var saved = addresses[addressIndex];
                                addresses.RemoveAt(addressIndex);
                                addresses.Add(saved[0..bitIndex] + '0' + saved[(bitIndex + 1)..]);
                                addresses.Add(saved[0..bitIndex] + '1' + saved[(bitIndex + 1)..]);
                                // Move back so we don't skip a number as all items beyond "saved" have moved one forward
                                addressIndex--;
                            }
                        }
                    }

                    foreach (var item in addresses)
                    {
                        var addressInt = ConvertToLong(item.ToCharArray());
                        if (!result.ContainsKey(addressInt))
                        {
                            result.Add(addressInt, num);
                        }
                        else
                        {
                            result[addressInt] = num;
                        }
                    }
                }
            }

            var sum = 0L;
            foreach (var item in result.Values)
            {
                sum += item;
            }
            return sum;
        }

        private static long ConvertToLong(char[] numBin)
        {
            long numSum = 0;
            long multipleOfTwo = 1;
            for (int j = numBin.Length - 1; j >= 0; j--)
            {
                if (numBin[j] == '1')
                {
                    numSum += multipleOfTwo;
                }
                multipleOfTwo *= 2;
            }

            return numSum;
        }
    }
}
