using AdventOfCode.SharedUtils;
using AdventOfCode.Year2018.Model;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day03
    {
        public static Rectangle[] Convert(string[] data)
        {
            //Data  
            //#1 @ 236,827: 24x17
            Rectangle[] rects = new Rectangle[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                string modified = data[i].Split('@')[1];
                modified = modified.Replace(':', ',');
                modified = modified.Replace('x', ',');

                int[] values = modified.Split(',').ToIntArray();
                rects[i] = new Rectangle(values[0], values[1], values[2], values[3], data[i]);
            }

            return rects;
        }

        private static int[,] GenerateField(Rectangle[] data)
        {
            int[,] values = new int[1000, 1000];
            for (int index = 0; index < data.Length; index++)
            {
                Rectangle current = data[index];
                for (int i = current.X; i < current.X + current.Width; i++)
                {
                    for (int j = current.Y; j < current.Y + current.Height; j++)
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
            int[,] field = GenerateField(data);


            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 00; j < 1000; j++)
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
            int[,] field = GenerateField(data);

            //Finding rect that was not modified
            Rectangle intact = new Rectangle(0, 0, 0, 0, "Null");
            for (int index = 0; index < data.Length; index++)
            {
                Rectangle current = data[index];
                bool damaged = false;
                for (int i = current.X; i < current.X + current.Width; i++)
                {
                    for (int j = current.Y; j < current.Y + current.Height; j++)
                    {
                        if (field[i, j] == -1)
                        {
                            damaged = true; ;
                        }
                    }
                }
                if (!damaged)
                {
                    intact = data[index];
                }
            }
            string resultString = intact.RootData.Split("@")[0];
            int result = int.Parse(resultString[1..]);
            return result;
        }

    }
}
