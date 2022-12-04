using AdventOfCode.Year2022.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2022.Tests.Solutions
{
    [TestClass]
    public class Day03Tests
    {

        [TestMethod]
        public void VerifyFirstProblem()
        {
            var numbers = new string[]
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw",
            };

            Assert.AreEqual(157, Day03.FirstProblem(numbers));
        }

        [TestMethod]
        public void VerifySecondProblem()
        {
            var numbers = new string[]
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw",
            };

            Assert.AreEqual(70, Day03.SecondProblem(numbers));
        }
    }
}
