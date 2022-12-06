using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022.Solutions
{
	public static class Day06
	{
		public static int FirstProblem(string[] items)
		{
            return CoreAlgorithm(items[0],4);
		}

		public static int SecondProblem(string[] items)
		{
            return CoreAlgorithm(items[0],14);
		}

		public static int CoreAlgorithm(string data, int markerLength)
		{
			for (int i = 0; i < data.Length; i++)
			{
				var span = data[i..(i + markerLength)];
				if (span.Distinct().Count() == markerLength)
				{
					return i + markerLength;
				}
			}
			return -1;
		}
	}
}
