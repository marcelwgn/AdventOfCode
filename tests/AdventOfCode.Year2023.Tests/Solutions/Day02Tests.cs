using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2023.Tests.Solutions
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void VerifyConvertCaseOne()
        {
            string[] data = ["Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"];

			var cubeGameState = Day02.Convert(data)[0];

            Assert.AreEqual(1, cubeGameState.Id);
			Assert.AreEqual(4, cubeGameState.Samples[0].Red);
			Assert.AreEqual(0, cubeGameState.Samples[0].Green);
			Assert.AreEqual(3, cubeGameState.Samples[0].Blue);

			Assert.AreEqual(1, cubeGameState.Samples[1].Red);
			Assert.AreEqual(2, cubeGameState.Samples[1].Green);
			Assert.AreEqual(6, cubeGameState.Samples[1].Blue);

			Assert.AreEqual(0, cubeGameState.Samples[2].Red);
			Assert.AreEqual(2, cubeGameState.Samples[2].Green);
			Assert.AreEqual(0, cubeGameState.Samples[2].Blue);
		}

        [TestMethod]
        public void VerifyFirstProblem()
        {
            var data = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green".Split("\r\n");

			var cubeGameStates = Day02.Convert(data);

			Assert.AreEqual(8, Day02.FirstProblem(cubeGameStates));
		}

		[TestMethod]
		public void VerifySecondProblem()
		{
			var data = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green".Split("\r\n");

			var cubeGameStates = Day02.Convert(data);

			Assert.AreEqual(2286, Day02.SecondProblem(cubeGameStates));
		}
	}
}
