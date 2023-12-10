using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023.Tests.Solutions
{
	[TestClass]
	public class Day10Tests
	{
		private readonly string[] simpleLoop = [
			".....",
			".S-7.",
			".|.|.",
			".L-J.",
			".....",
		];

		private readonly string[] disconnectedElements = [
			"-L|F7",
			"7S-7|",
			"L|7||",
			"-L-J|",
			"L|-JF",
		];

		private readonly string[] moreComplexLoop = [
			"..F7.",
			".FJ|.",
			"SJ.L7",
			"|F--J",
			"LJ..."];

		private readonly string[] moreComplexLoopWithDisconnectedElements = [
			"7-F7-",
			".FJ|7",
			"SJLL7",
			"|F--J",
			"LJ.LJ"
		];

		private readonly string[] missleadingLoop = [
			"F--7.",
			"L--J.",
			"...S7",
			"...LJ"
			];

		private readonly string[] uShapedLoop = [
			"...........",
			".S-------7.",
			".|F-----7|.",
			".||.....||.",
			".||.....||.",
			".|L-7.F-J|.",
			".|..|.|..|.",
			".L--J.L--J.",
			"..........."
			];

		private readonly string[] uShapedClosed = [
			"..........",
			".S------7.",
			".|F----7|.",
			".||....||.",
			".||....||.",
			".|L-7F-J|.",
			".|..||..|.",
			".L--JL--J.",
			".........."
			];

		[TestMethod]
		public void VerifyFirstProblemSimpleLoop()
		{
			var result = Day10.FirstProblem(simpleLoop);
			Assert.AreEqual(4, result);
		}

		[TestMethod]
		public void VerifyFirstProblemDisconnectedElements()
		{
			var result = Day10.FirstProblem(disconnectedElements);
			Assert.AreEqual(4, result);
		}

		[TestMethod]
		public void VerifyFirstProblemMoreComplexLoop()
		{
			var result = Day10.FirstProblem(moreComplexLoop);
			Assert.AreEqual(8, result);
		}

		[TestMethod]
		public void VerifyFirstProblemMoreComplexLoopWithDisconnectedElements()
		{
			var result = Day10.FirstProblem(moreComplexLoopWithDisconnectedElements);
			Assert.AreEqual(8, result);
		}

		[TestMethod]
		public void VerifyFIrstProblemMissleadingLoop()
		{
			var result = Day10.FirstProblem(missleadingLoop);
			Assert.AreEqual(2, result);
		}

		[TestMethod]
		public void VerifySecondProblemUsingUShapedLoop()
		{
			var result = Day10.SecondProblem(uShapedLoop);
			Assert.AreEqual(4, result);
		}

		[TestMethod]
		public void VerifySecondProblemUsingUShapedClosed()
		{
			var result = Day10.SecondProblem(uShapedClosed);
			Assert.AreEqual(4, result);
		}
	}
}
