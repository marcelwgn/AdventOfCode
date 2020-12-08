using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day05
    {
        public static int FirstProblem(string[] data)
        {
            return data.Max(pass => GetBoardingPassID(pass));
        }

        public static int SecondProblem(string[] data)
        {
            var seatIDs = data.Select(item => GetBoardingPassID(item)).ToList();
            seatIDs.Sort();
            for (int i = 0; i < seatIDs.Count - 1; i++)
            {
                if(seatIDs[i] == seatIDs[i + 1] - 2)
                {
                    return seatIDs[i] + 1;
                }
            }
            return 0;
        }

        public static int GetBoardingPassID(string data)
        {
            int row = 0;
            int rowModifier = 64;

            for (int i = 0; i < 7; i++)
            {
                if (data[i] == 'B')
                {
                    row += rowModifier;
                }
                rowModifier /= 2;
            }

            int column = 0;
            int columnModifier = 4;
            for (int i = 7; i < 10; i++)
            {
                if (data[i] == 'R')
                {
                    column += columnModifier;
                }
                columnModifier /= 2;
            }

            return row * 8 + column;
        }
    }
}
