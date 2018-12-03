using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utils {
  class DataHolder {
  }

  public class Rectangle {
    public int x, y, width, height;
    public String rootData;
    public Rectangle(int x, int y, int width, int height,string rootData) {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
      this.rootData = rootData;
    }
  }

}
