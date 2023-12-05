using System;
using System.Text;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day05
    {
        public static string FirstProblem(string[] data)
        {
            var result = "";
            var md5 = System.Security.Cryptography.MD5.Create();

            long index = 0;
            while (result.Length < 8)
            {
                var inputBytes = Encoding.ASCII.GetBytes(data[0] + index);
                var hashBytes = md5.ComputeHash(inputBytes);

                if (hashBytes[0] == 0 && hashBytes[1] == 0)
                {
                    // Convert the byte array to hexadecimal string
                    var sb = new StringBuilder();
                    for (var j = 0; j < hashBytes.Length; j++)
                    {
                        sb.Append(hashBytes[j].ToString("X2"));
                    }
                    if (sb.ToString().StartsWith("00000"))
                    {
                        result += sb.ToString()[5];
                    }
                }
                index++;
            }

            return result.ToLower();
        }

        public static string SecondProblem(string[] data)
        {
            var md5 = System.Security.Cryptography.MD5.Create();

            long index = 0;
            var password = new char?[] { null, null, null, null, null, null, null, null };
            short fillCount = 0;
            while (fillCount < 8)
            {
                var inputBytes = Encoding.ASCII.GetBytes(data[0] + index);
                var hashBytes = md5.ComputeHash(inputBytes);

                if (hashBytes[0] == 0 && hashBytes[1] == 0)
                {
                    // Convert the byte array to hexadecimal string
                    var sb = new StringBuilder();
                    for (var j = 0; j < hashBytes.Length; j++)
                    {
                        sb.Append(hashBytes[j].ToString("X2"));
                    }
                    if (sb.ToString().StartsWith("00000"))
                    {
                        try
                        {
                            var insertIndex = int.Parse(sb.ToString()[5].ToString());
                            if (insertIndex < 8 && password[insertIndex] == null)
                            {
                                fillCount++;
                                password[insertIndex] = sb.ToString()[6];
                            }
                        }
                        catch (Exception) { }
                    }
                }
                index++;
            }
            var result = "";
            foreach (var character in password)
            {
                result += character;
            }
            return result.ToLower();
        }
    }
}
