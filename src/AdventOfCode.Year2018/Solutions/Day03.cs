using AdventOfCode.Common;
using AdventOfCode.Year2018.Model;

namespace AdventOfCode.Year2018.Solutions;

public static class Day03
{
    public static Rectangle[] Convert(string[] data)
    {
        //Data  
        //#1 @ 236,827: 24x17
        var rects = new Rectangle[data.Length];
        for (var i = 0; i < data.Length; i++)
        {
            var modified = data[i].Split('@')[1];
            modified = modified.Replace(':', ',');
            modified = modified.Replace('x', ',');

            var values = modified.Split(',').ToIntArray();
            rects[i] = new Rectangle(values[0], values[1], values[2], values[3], data[i]);
        }

        return rects;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "<Pending>")]
    private static int[,] GenerateField(Rectangle[] data)
    {
        var values = new int[1000, 1000];
        for (var index = 0; index < data.Length; index++)
        {
            var current = data[index];
            for (var i = current.X; i < current.X + current.Width; i++)
            {
                for (var j = current.Y; j < current.Y + current.Height; j++)
                {
                    if (values[i, j] != 0)
                    {
                        values[i, j] = -1;
                    }
                    else
                    {
                        values[i, j] = 1;
                    }
                }
            }
        }

        return values;
    }

    public static int FirstProblem(Rectangle[] data)
    {
        var field = GenerateField(data);

        var sum = 0;
        for (var i = 0; i < 1000; i++)
        {
            for (var j = 00; j < 1000; j++)
            {
                if (field[i, j] == -1)
                {
                    sum++;
                }
            }
        }
        return sum;
    }

    public static int SecondProblem(Rectangle[] data)
    {
        var field = GenerateField(data);

        //Finding rect that was not modified
        var intact = new Rectangle(0, 0, 0, 0, "Null");
        for (var index = 0; index < data.Length; index++)
        {
            var current = data[index];
            var damaged = false;
            for (var i = current.X; i < current.X + current.Width; i++)
            {
                for (var j = current.Y; j < current.Y + current.Height; j++)
                {
                    if (field[i, j] == -1)
                    {
                        damaged = true;
                        ;
                    }
                }
            }
            if (!damaged)
            {
                intact = data[index];
            }
        }
        var resultString = intact.RootData.Split("@")[0];
        var result = int.Parse(resultString[1..]);
        return result;
    }

}
