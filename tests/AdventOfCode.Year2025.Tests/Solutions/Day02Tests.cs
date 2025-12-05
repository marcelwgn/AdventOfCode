namespace AdventOfCode.Year2025.Tests.Solutions;

[TestClass]
public class Day02Tests
{
    [TestMethod]
    public void FirstProblemFull()
    {
        var stInput = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

        var result = Year2025.Solutions.Day02.FirstProblem(Year2025.Solutions.Day02.Convert(new string[] { stInput }));
        Assert.AreEqual("1227775554", result);
    }

    [TestMethod]
    public void SecondProblemFull()
    {
        var stInput = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

        var result = Year2025.Solutions.Day02.SecondProblem(Year2025.Solutions.Day02.Convert(new string[] { stInput }));
        Assert.AreEqual("4174379265", result);
    }

    [TestMethod]
    [DataRow("11-22", "33")]
    [DataRow("95-115", "99")]
    [DataRow("998-1012", "1010")]
    [DataRow("1188511880-1188511890", "1188511885")]
    [DataRow("222220-222224", "222222")]
    [DataRow("1698522-1698528", "0")]
    [DataRow("446443-446449", "446446")]
    [DataRow("38593856-38593862", "38593859")]
    public void VerifyFirstProblem(string stInput, string stExpected)
    {
        var result = Year2025.Solutions.Day02.FirstProblem(Year2025.Solutions.Day02.Convert(new string[] { stInput }));

        Assert.AreEqual(stExpected, result);
    }

    [TestMethod]
    [DataRow("11-22", "33")]
    [DataRow("95-115", "210")]
    [DataRow("998-1012", "2009")]
    [DataRow("1188511880-1188511890", "1188511885")]
    [DataRow("222220-222224", "222222")]
    [DataRow("1698522-1698528", "0")]
    [DataRow("446443-446449", "446446")]
    [DataRow("38593856-38593862", "38593859")]
    public void VerifySecondProblem(string stInput, string stExpected)
    {
        var result = Year2025.Solutions.Day02.SecondProblem(Year2025.Solutions.Day02.Convert(new string[] { stInput }));

        Assert.AreEqual(stExpected, result);
    }
}
