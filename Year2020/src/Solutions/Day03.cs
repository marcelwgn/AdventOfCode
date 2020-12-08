using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day03
    {
        public static long FirstProblem(string[] lines)
        {
            return Algorithm(lines, 3, 1);
        }

        public static long SecondProblem(string[] lines)
        {
            return Algorithm(lines,1,1) 
                * Algorithm(lines,3,1)
                * Algorithm(lines,5,1)
                * Algorithm(lines,7,1)
                * Algorithm(lines,1,2);
        }

        public static long Algorithm(string[] lines, int moveRight, int moveDown)
        {
            int rowWidth = lines[0].Length;
            long treeCount = 0;
            int xPos = 0;

            for (int i = 0; i < lines.Length; i+=moveDown)
            {
                if (lines[i][xPos] == '#')
                {
                    treeCount++;
                }
                xPos = (xPos + moveRight) % rowWidth;
            }
            return treeCount;
        }
    }
}
