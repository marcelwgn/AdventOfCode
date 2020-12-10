using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections;

namespace AdventOfCode.SharedUtils
{
    public static class ReadUtils
    {
        public static string[] ReadDataFromFile(string fileName)
        {
            FileStream fileToRead = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            var data = File.ReadLines(fileName).ToArray();
            fileToRead.Close();

            return data;
        }

        public static long[] ReadLongDataFromFile(string fileName)
        {
            FileStream fileToRead = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            var data = File.ReadLines(fileName).Select(line => long.Parse(line)).ToArray();
            fileToRead.Close();

            return data;
        }

        public static int[] ReadIntDataFromFile(string fileName)
        {
            FileStream fileToRead = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            var data = File.ReadLines(fileName).Select(line => int.Parse(line)).ToArray();
            fileToRead.Close();

            return data;
        }
    }
}
