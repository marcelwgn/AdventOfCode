using AdventOfCode.Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Common.Tests.Extensions
{
	[TestClass]
	public class CoordinateExtensionTests
	{

		[TestMethod]
		public void Verify2DArrayGet()
		{
			var intArray = new int[4][];
			for (int i = 0; i < intArray.Length; i++)
			{
				intArray[i] = [1 * i, 2 * i, 3 * i, 4 * i];
			}

			var coordinate = new Coordinate(1, 1);

			Assert.AreEqual(2, intArray.Get(coordinate));
		}

		[TestMethod]
		public void Verify2DArraySet()
		{
			var intArray = new int[4][];
			for (int i = 0; i < intArray.Length; i++)
			{
				intArray[i] = [1 * i, 2 * i, 3 * i, 4 * i];
			}
			var coordinate = new Coordinate(1, 1);

			intArray.Set(coordinate, 10);

			Assert.AreEqual(10, intArray.Get(coordinate));
		}

		[TestMethod]
		public void VerifyStringArrayGet()
		{
			var data = new string[]
			{
				"1234",
				"5678",
				"90AB",
				"CDEF"
			};

			var coordinate = new Coordinate(1, 1);

			Assert.AreEqual('6', data.Get(coordinate));
		}
	}
}
