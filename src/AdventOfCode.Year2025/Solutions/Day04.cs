using AdventOfCode.Common;
using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2025.Solutions;

public static class Day04
{
    public static char[][] Convert(string[] input)
    {
        return input.ToCharArray();
    }

    private static readonly Coordinate[] RgCoordinateSurrounding = [
        new Coordinate(-1, -1),
        new Coordinate(0, -1),
        new Coordinate(1, -1),
        new Coordinate(-1, 0),
        new Coordinate(1, 0),
        new Coordinate(-1, 1),
        new Coordinate(0, 1),
        new Coordinate(1, 1),
    ];

    public static string FirstProblem(char[][] chMap)
    {
        var chmapRemoved = ChmapCreateRemoved(chMap, out _);

        return chmapRemoved.SelectMany(rgc => rgc).Count(c => c == '#').ToString();
    }


    public static string SecondProblem(char[][] chMap)
    {
        bool fRunLoop = true;
        while (fRunLoop)
        {
            chMap = ChmapCreateRemoved(chMap, out fRunLoop);
        }

        return chMap.SelectMany(rgc => rgc).Count(c => c == '#').ToString();
    }

    private static char[][] ChmapCreateRemoved(char[][] chmap, out bool fChanged)
    {
        fChanged = false;
        var chMapNew = new char[chmap.Length][];
        for (int i = 0; i < chmap.Length; i++)
        {
            chMapNew[i] = new char[chmap[i].Length];
            Array.Copy(chmap[i], chMapNew[i], chmap[i].Length);
        }

        for (int x = 0; x < chmap.Length; x++)
        {
            for (int y = 0; y < chmap[x].Length; y++)
            {
                Coordinate cCur = new Coordinate(x, y);

                if (chmap.Get(cCur) != '@') continue;

                int cRollsSurrounding = RgCoordinateSurrounding.Select(coord => coord + cCur)
                    .Count(coord => chmap.GetSafe(coord) == '@');

                if (cRollsSurrounding < 4)
                {
                    chMapNew.Set(cCur, '#');
                    fChanged = true;
                }
            }
        }

        return chMapNew;
    }
}
