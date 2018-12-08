using System;

namespace AdventOfCode.Model {
  public class Point {
    public int x, y;

    public String name;

    public Point(int x, int y, string name)
    {
      this.x = x;
      this.y = y;
      this.name = name;
    }

    public int getDistance(int xTest, int yTest)
    {
      return Math.Abs(this.x - xTest) + Math.Abs(this.y - yTest);
    }
  }
}
