using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018.Solutions;

namespace AdventOfCode2018Tests.SolutionsTests
{

    [TestClass()]
    public class Day12Tests
    {

        [TestMethod()]
        public void ConverTest()
        {
            string[] data = {
          "initial state: #..#.#..##......###...###",
          "",
          "...## => #",
          "..#.. => #",
          ".#... => #",
          ".#.#. => #",
          ".#.## => #",
          ".##.. => #",
          ".#### => #",
          "#.#.# => #",
          "#.### => #",
          "##.#. => #",
          "##.## => #",
          "###.. => #",
          "###.# => #",
          "####. => #"
        };

            System.Tuple<bool[], PatternMatcher[]> converted = Day12.Convert(data);


            bool[] correctFlowers = new bool[] { true, false, false, true, false, true, false, false, true, true, false, false, false, false, false, false, true, true, true, false, false, false, true, true, true };
            //Not good but good enough
            for (int i = 100; i < correctFlowers.Length; i++)
            {
                Assert.AreEqual(correctFlowers[i - 100], converted.Item1[i]);
            }


            bool[] firstPatternCorrect = new bool[] { false, false, false, true, true };

            CollectionAssert.AreEqual(firstPatternCorrect, converted.Item2[0].values);
            Assert.AreEqual(true, converted.Item2[0].result);
        }

        [TestMethod()]
        public void FirstProblemTest()
        {
            string[] data = {
          "initial state: #..#.#..##......###...###",
          "",
          "...## => #",
          "..#.. => #",
          ".#... => #",
          ".#.#. => #",
          ".#.## => #",
          ".##.. => #",
          ".#### => #",
          "#.#.# => #",
          "#.### => #",
          "##.#. => #",
          "##.## => #",
          "###.. => #",
          "###.# => #",
          "####. => #"
      };

            System.Tuple<bool[], PatternMatcher[]> converted = Day12.Convert(data);
            int result = Day12.FirstProblem(converted);


            Assert.AreEqual(325, result);

        }


    }
}
