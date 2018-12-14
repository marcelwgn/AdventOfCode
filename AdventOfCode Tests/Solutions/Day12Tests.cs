using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {

  [TestClass()]
  public class Day12Tests {

    [TestMethod()]
    public void converTest()
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

      var converted = Day12.convert(data);


      bool[] correctFlowers = new bool[] { true, false, false, true, false, true, false, false, true, true, false, false, false, false, false, false, true, true, true, false, false, false, true, true, true };
      //Not good but good enough
      for(int i=100;i<correctFlowers.Length;i++){
        Assert.AreEqual(correctFlowers[i - 100], converted.Item1[i]);
      }


      bool[] firstPatternCorrect = new bool[] { false, false, false, true, true };

      CollectionAssert.AreEqual(firstPatternCorrect, converted.Item2[0].values);
      Assert.AreEqual(true, converted.Item2[0].result);
    }

    [TestMethod()]
    public void firstProblemTest(){
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

      var converted = Day12.convert(data);
      int result = Day12.firstProblem(converted);


      Assert.AreEqual(325, result);

    }


  }
}
