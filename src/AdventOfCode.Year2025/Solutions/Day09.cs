using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing;
namespace AdventOfCode.Year2025.Solutions;

public static class Day09
{
    private record struct V2Long(long x, long y)
    {
    }

    private record struct LineLong(V2Long v2Start, V2Long v2End)
    {
        public long XMin => Math.Min(v2Start.x, v2End.x);
        public long XMax => Math.Max(v2Start.x, v2End.x);
        public long YMin => Math.Min(v2Start.y, v2End.y);
        public long YMax => Math.Max(v2Start.y, v2End.y);
    }

    public static string FirstProblem(string[] input)
    {
        V2Long[] listv2 = new V2Long[input.Length];
        for (int iInput = 0; iInput < listv2.Length; iInput++)
        {
            string[] rgstCoord = input[iInput].Split(",");
            listv2[iInput] = new V2Long(
                long.Parse(rgstCoord[0]),
                long.Parse(rgstCoord[1])
            );
        }

        long uAreaMax = 0;

        for (int iVectorStart = 0; iVectorStart < listv2.Length; iVectorStart++)
        {
            for (int iVectorEnd = iVectorStart + 1; iVectorEnd < listv2.Length; iVectorEnd++)
            {
                V2Long v2Start = listv2[iVectorStart];
                V2Long v2End = listv2[iVectorEnd];

                var dx = v2Start.x - v2End.x + 1;
                var dy = v2Start.y - v2End.y + 1;
                uAreaMax = Math.Max(uAreaMax, dx * dy);
            }
        }

        return uAreaMax.ToString();
    }

    public static string SecondProblem(string[] input)
    {
        V2Long[] listv2 = new V2Long[input.Length];
        for (int iInput = 0; iInput < listv2.Length; iInput++)
        {
            string[] rgstCoord = input[iInput].Split(",");
            listv2[iInput] = new V2Long(
                long.Parse(rgstCoord[0]),
                long.Parse(rgstCoord[1])
            );
        }

        List<LineLong> listBorders = new();
        for (int iv2 = 0; iv2 < listv2.Length; iv2++)
        {
            listBorders.Add(new(
                listv2[iv2],
                listv2[iv2 + 1 < listv2.Length ? iv2 + 1 : 0]
            ));
        }

        long uAreaMax = 0;
        for (int iv2Start = 0; iv2Start < listv2.Length; iv2Start++)
        {
            for (int iv2End = iv2Start + 1; iv2End < listv2.Length; iv2End++)
            {
                V2Long v2Start = listv2[iv2Start];
                V2Long v2End = listv2[iv2End];

                V2Long v2TopLeft = new V2Long(Math.Min(v2Start.x, v2End.x), Math.Min(v2Start.y, v2End.y));
                V2Long v2BottomRight = new V2Long(Math.Max(v2Start.x, v2End.x), Math.Max(v2Start.y, v2End.y));

                var dx = Math.Abs(v2Start.x - v2End.x) + 1;
                var dy = Math.Abs(v2Start.y - v2End.y) + 1;

                if (uAreaMax >= dx * dy)
                {
                    continue; // If its smaller, skip
                }

                var fIntersects = listBorders.Any(line => FLineTouchesInnerArea(line, v2TopLeft, v2BottomRight));

                if (!fIntersects)
                {
                    uAreaMax = Math.Max(uAreaMax, dx * dy);
                }
            }
        }

        return uAreaMax.ToString();
    }

    private static bool FLineTouchesInnerArea(LineLong lineA, V2Long v2TopLeft, V2Long v2BottomRight)
    {
        return lineA.XMax > v2TopLeft.x && lineA.XMin < v2BottomRight.x && lineA.YMax > v2TopLeft.y && lineA.YMin < v2BottomRight.y;
    }
}
