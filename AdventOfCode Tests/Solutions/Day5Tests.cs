using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day5Tests {
    [TestMethod()]
    public void convertTest() {
      string[] data = { "a", "b", "c" };

      String converted = Day5.convert(data);

      Assert.AreEqual("a", converted);
    }


    [TestMethod()]
    public void polymerTest_aA() {
      string data = "aA";
      string changed = Day5.polymer(data).Item1;
      Assert.AreEqual("", changed);
    }
    [TestMethod()]
    public void polymerTest_Zz() {
      string data = "Zz";
      string changed = Day5.polymer(data).Item1;
      Assert.AreEqual("", changed);
    }
    [TestMethod()]
    public void polymerTest_abBA() {
      string data = "abBA";
      string changed = Day5.polymer(data).Item1;
      Assert.AreEqual("aA", changed);
    }
    [TestMethod()]
    public void polymerTest_abAB() {
      string data = "abAB";
      string changed = Day5.polymer(data).Item1;
      Assert.AreEqual("abAB", changed);
    }
    [TestMethod()]
    public void polymerTest_aabAAB() {
      string data = "aabAAB";
      string changed = Day5.polymer(data).Item1;
      Assert.AreEqual("aabAAB", changed);
    }


    [TestMethod()]
    public void firstProblemTest_Simple(){
      string data = "dabAcCaCBAcCcaDA";
      int changed = Day5.firstProblem(data);
      Assert.AreEqual(10,changed);
    }   
    
    
    [TestMethod()]
    public void firstProblemTest_Simple2(){
      string data = "dbcCCBcCcD";
      int changed = Day5.firstProblem(data);
      Assert.AreEqual(6,changed);
    }   
    
    
    [TestMethod()]
    public void firstProblemTest_Simple3(){
      string data = "dabAaBAaDA";
      int changed = Day5.firstProblem(data);
      Assert.AreEqual(4,changed);
    }   
    
    
    
    [TestMethod()]
    public void secondProblemTest_Simple(){
      string data = "dabAcCaCBAcCcaDA";
      int changed = Day5.secondProblem(data);
      Assert.AreEqual(4,changed);
    }
  }
}