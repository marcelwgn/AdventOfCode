using System;

namespace AdventOfCode.Model {
  public class Vector {
    public int x, y;

    public String name;

    public Vector(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    public Vector(int x, int y, string name)
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
