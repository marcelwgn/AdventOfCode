using System;

namespace AdventOfCode.Utils {

  public class Point {
    public int x, y;

    public String name;

    public Point(int x, int y, string name) {
      this.x = x;
      this.y = y;
      this.name = name;
    }

    public int getDistance(int xTest, int yTest) {
      return Math.Abs(x-xTest)+Math.Abs(y-yTest);
    }
  }

  public class Rectangle {
    public int x, y, width, height;
    public String rootData;
    public Rectangle(int x, int y, int width, int height, string rootData) {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
      this.rootData = rootData;
    }
  }

}
