using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2018.SharedUtils
{
    public static class ReadUtils
    {

        /// <summary>
        /// New split function for string class
        /// </summary>
        /// <param name="toSplit">The initial string</param>
        /// <param name="splitOn">The charsequence used for splitting</param>
        /// <returns></returns>
        public static string[] Split(this string toSplit, string splitOn)
        {
            return toSplit.Split(new string[] { splitOn }, StringSplitOptions.None);
        }


        public static string[] ReadDataFromFile(string fileName)
        {
            List<string> data = new List<string>();

            FileStream fileToRead = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            foreach (string s in File.ReadLines(fileName))
            {
                data.Add(s);
            }
            fileToRead.Close();

            return data.ToArray();

        }


        public static string[] ReadDataFromFile(string fileName, string split)
        {
            string input = "";

            FileStream fileToRead = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            foreach (string s in File.ReadLines(fileName))
            {
                input += s;
            }
            fileToRead.Close();

            string[] splitArray = input.Split(split);
            return splitArray;
        }
    }
}
