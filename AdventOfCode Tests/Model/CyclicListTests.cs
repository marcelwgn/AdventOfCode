using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Model {
  [TestClass()]
  public class CyclicListTests {
  
    [TestMethod()]
    public void insertAfterTest_Simple(){
      CyclicList<int> list = new CyclicList<int>();
      list.insertAfter(0, 0);
      list.insertAfter(1, 0);

      list.insertAfter(2, 1);


      Assert.AreEqual(1, list[1]);
    }
  
  }
}
