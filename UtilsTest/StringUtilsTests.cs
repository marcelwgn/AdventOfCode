using AdventOfCode2018.SharedUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UtilsTests
{
    [TestClass()]
    public class StringUtilsTests
    {
        [TestMethod()]
        public void LetterIsInTwiceTest_ContainsALetterTwice()
        {
            string test = "bababc";

            bool result = test.ContainsLetterExactlyTwice();

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void LetterIsInTwiceTest_ContainsNoLetterTwice()
        {
            string test = "abcdef";

            bool result = test.ContainsLetterExactlyTwice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInTwiceTest_ContainsALetterThrice()
        {
            string test = "aaabcdef";

            bool result = test.ContainsLetterExactlyTwice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInThriceTest_ContainsALetterTwice()
        {
            string test = "abcefhiklmnnopqqrstuvwxyzz";

            bool result = test.ContainsLetterExactlyThrice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInThriceTest_ContainsNoLetterTwice()
        {
            string test = "abcdef";

            bool result = test.ContainsLetterExactlyThrice();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LetterIsInThriceTest_ContainsALetterThrice()
        {
            string test = "aaabcdef";

            bool result = test.ContainsLetterExactlyThrice();

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NumberOfLettersDifferentTest_TwoLettersDifferent()
        {
            string first = "abcde";
            string second = "axcye";

            int result = first.NumberOfLettersDifferent(second);

            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void NumberOfLettersDifferentTest_OneLetterDifferent()
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