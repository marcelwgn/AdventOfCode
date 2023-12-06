using System;
using System.Text;

namespace AdventOfCode.Year2016.Solutions
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA5351:Do Not Use Broken Cryptographic Algorithms", Justification = "Thats just part of the advent of code problem")]
	public static class Day05
	{
		public static string FirstProblem(string[] data)
		{
			var result = "";

			long index = 0;
			while (result.Length < 8)
			{
				var inputBytes = Encoding.ASCII.GetBytes(data[0] + index);
				var hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);

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
			long index = 0;
			var password = new char?[] { null, null, null, null, null, null, null, null };
			short fillCount = 0;
			while (fillCount < 8)
			{
				var inputBytes = Encoding.ASCII.GetBytes(data[0] + index);
				var hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);

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
						var asString = sb.ToString();
						if (char.IsNumber(asString[5]))
						{

							var insertIndex = asString[5] - 48; // ASCII Numbers start at 48, subtracting this is the fastest way to get a number here
							if (insertIndex < 8 && password[insertIndex] == null)
							{
								fillCount++;
								password[insertIndex] = asString[6];
							}
						}
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
