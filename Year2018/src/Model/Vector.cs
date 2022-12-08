using System;

namespace AdventOfCode.Year2018.Model
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; } = "";

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }


        public int GetDistance(int xTest, int yTest)
        {
            return Math.Abs(X - xTest) + Math.Abs(Y - yTest);
        }
    }
}
