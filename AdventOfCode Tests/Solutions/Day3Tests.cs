using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utils;

namespace AdventOfCode.Solutions.Tests {
  [TestClass()]
  public class Day3Tests {
    [TestMethod()]
    public void convertTest() {
      //#1 @ 236,827: 24x17
      string[] data = { "#1 @ 236,827: 24x17" };

      Rectangle[] rects = Day3.convert(data);

      Assert.AreEqual(rects[0].x, 236);
      Assert.AreEqual(rects[0].y, 827);
      Assert.AreEqual(rects[0].width, 24);
      Assert.AreEqual(rects[0].height, 17);
      Assert.AreEqual(rects[0].rootData, data[0]);
      }
  }
}