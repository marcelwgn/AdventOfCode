using System.IO;
using System.Linq;

namespace AdventOfCode.Common
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
    }
}
