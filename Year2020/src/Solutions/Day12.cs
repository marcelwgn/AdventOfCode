using System;
using System.Drawing;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day12
    {
        const double ToRadians = Math.PI / 180;
        const double ToDegree = 1 / ToRadians;

        public static int FirstProblem(string[] data)
        {
            var xPos = 0d;
            var yPos = 0d;

            var angle = 0d;

            foreach (var item in data)
            {
                var value = int.Parse(item[1..].ToString());
                switch (item[0])
                {
                    case 'N':
                        yPos += value;
                        break;
                    case 'E':
                        xPos += value;
                        break;
                    case 'S':
                        yPos -= value;
                        break;
                    case 'W':
                        xPos -= value;
                        break;
                    case 'F':
                        xPos += Math.Cos(ToRadians * angle) * value;
                        yPos += Math.Sin(ToRadians * angle) * value;
                        break;
                    case 'L':
                        angle = (angle + value) % 360;
                        break;
                    case 'R':
                        angle = (angle - value + 360) % 360;
                        break;
                }
            }

            // Double operations might be a bit imprecise, round
            return (int)Math.Round(Math.Abs(xPos) + Math.Abs(yPos));
        }

        public static int SecondProblem(string[] data)
        {
            var xPos = 0;
            var yPos = 0;

            var wayPoint = new Point(10, 1);
            foreach (var item in data)
            {
                var value = int.Parse(item[1..].ToString());
                switch (item[0])
                {
                    case 'N':
                        wayPoint.Y += value;
                        break;
                    case 'E':
                        wayPoint.X += value;
                        break;
                    case 'S':
                        wayPoint.Y -= value;
                        break;
                    case 'W':
                        wayPoint.X -= value;
                        break;
                    case 'F':
                        xPos += wayPoint.X * value;
                        yPos += wayPoint.Y * value;
                        break;
                    case 'L':
                        wayPoint = RotateCoordinates((-value + 360) % 360, wayPoint);
                        break;
                    case 'R':
                        wayPoint = RotateCoordinates(value, wayPoint);
                        break;
                }
            }

            return Math.Abs(xPos) + Math.Abs(yPos);
        }

        private static Point RotateCoordinates(int degrees, Point pt)
        {
            // Using this way of rotating a point since the angles will become more and more imprecise due
            // to doubles limited precision which sooner or later will result in faulty values.
            var oldX = pt.X;
            if (degrees == 90)
            {
                pt.X = pt.Y;
                pt.Y = -oldX;
            }
            else if (degrees == 180)
            {
                pt.X = -oldX;
                pt.Y = -pt.Y;
            }
            else if (degrees == 270)
            {
                pt.X = -pt.Y;
                pt.Y = oldX;
            }
            return pt;
        }
    }
}
