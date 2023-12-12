using AdventOfCode.Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Common.Tests.DataStructures
{
	[TestClass]
	public class CoordinateTests
	{
		[TestMethod]
		public void VerifyEquality()
		{
			var coordinateOne = new Coordinate(0, 1);
			var coordinateTwo = new Coordinate(0, 1);

			Assert.IsTrue(coordinateOne == coordinateTwo);
			Assert.AreEqual(coordinateOne, coordinateTwo);
		}

		[TestMethod]
		public void VerifyIsInGrid2DArrayWhenInGrid()
		{
			int[][] array = [
				[1, 2, 3],
				[4, 5, 6]
			];

			Assert.IsTrue(new Coordinate(0, 1).IsInGrid(array));
			Assert.IsTrue(new Coordinate(1, 0).IsInGrid(array));
			Assert.IsTrue(new Coordinate(2, 1).IsInGrid(array));
		}

		[TestMethod]
		public void VerifyIsNotInGrid2DArrayWhenNotInGrid()
		{
			int[][] array = [
				[1],
				[4, 5, 6]
			];

			Assert.IsFalse(new Coordinate(0, 2).IsInGrid(array));
			Assert.IsFalse(new Coordinate(-1, 2).IsInGrid(array));
			Assert.IsFalse(new Coordinate(10, 2).IsInGrid(array));
			Assert.IsFalse(new Coordinate(0, -1).IsInGrid(array));
			Assert.IsFalse(new Coordinate(0, 10).IsInGrid(array));
			Assert.IsFalse(new Coordinate(3, 17).IsInGrid(array));
		}

		[TestMethod]
		public void VerifyIsInStringArrayWhenInGrid()
		{
			string[] array = [
				"1,2,3",
				"4,5,6"
			];

			Assert.IsTrue(new Coordinate(0, 1).IsInGrid(array));
			Assert.IsTrue(new Coordinate(1, 0).IsInGrid(array));
			Assert.IsTrue(new Coordinate(2, 1).IsInGrid(array));
		}

		[TestMethod]
		public void VerifyIsNotInStringArrayWhenNotInGrid()
		{
			string[] array = [
				"1",
				"4,5,6"
			];

			Assert.IsFalse(new Coordinate(0, 2).IsInGrid(array));
			Assert.IsFalse(new Coordinate(-1, 2).IsInGrid(array));
			Assert.IsFalse(new Coordinate(10, 2).IsInGrid(array));
			Assert.IsFalse(new Coordinate(0, -1).IsInGrid(array));
			Assert.IsFalse(new Coordinate(0, 10).IsInGrid(array));
			Assert.IsFalse(new Coordinate(3, 17).IsInGrid(array));
		}
	}
}
