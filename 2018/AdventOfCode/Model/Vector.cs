using System;

namespace AdventOfCode2018.Model
{
    public class Vector
    {
        public int x, y;

        public string name;

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
            return Math.Abs(x - xTest) + Math.Abs(y - yTest);
        }
    }
}
