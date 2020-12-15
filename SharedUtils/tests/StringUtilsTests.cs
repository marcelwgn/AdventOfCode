using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.SharedUtils.Tests
{
    [TestClass()]
    public class StringUtilsTests
    {
        [TestMethod()]
        public void LetterIsInTwiceTestContainsALetterTwice()
        {
            string test = "bababc";

            bool result = test.ContainsLetterExactlyTwice();

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void LetterIsInTwiceTestContainsNoLetterTwice()
        {
            string test = "abcdef";

            bool result = test.ContainsLetterExactlyTwice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInTwiceTestContainsALetterThrice()
        {
            string test = "aaabcdef";

            bool result = test.ContainsLetterExactlyTwice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInThriceTestContainsALetterTwice()
        {
            string test = "abcefhiklmnnopqqrstuvwxyzz";

            bool result = test.ContainsLetterExactlyThrice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInThriceTestContainsNoLetterTwice()
        {
            string test = "abcdef";

            bool result = test.ContainsLetterExactlyThrice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInThriceTestContainsALetterThrice()
        {
            string test = "aaabcdef";

            bool result = test.ContainsLetterExactlyThrice();

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NumberOfLettersDifferentTestTwoLettersDifferent()
        {
            string first = "abcde";
            string second = "axcye";

            int result = first.NumberOfLettersDifferent(second);

            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void NumberOfLettersDifferentTestOneLetterDifferent()
        {
            string first = "fghij";
            string second = "fguij";

            int result = first.NumberOfLettersDifferent(second);

            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void GetCommonLettersTest()
        {
            string first = "fghij";
            string second = "fguij";

            string result = first.GetCommonLetters(second);

            Assert.AreEqual("fgij", result);
        }
    }
}