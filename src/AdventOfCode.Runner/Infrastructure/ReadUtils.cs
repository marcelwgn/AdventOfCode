namespace AdventOfCode.Runner.Infrastructure
{
    public static class ReadUtils
    {
        public static string[] ReadDataFromFile(string fileName)
        {
            var fileToRead = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            var data = File.ReadLines(fileName).ToArray();
            fileToRead.Close();

            return data;
        }
    }
}
