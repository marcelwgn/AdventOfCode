using System;

namespace AdventOfCode.Solutions {
  internal class Day12 {

    public const int offset = 100;

    public static Tuple<bool[], PatternMatcher[]> convert(string[] data)
    {
      bool[] flowers = new bool[300];
      for (int i = 0; i < flowers.Length; i++)
      {
        flowers[i] = new bool();
      }

      string line = data[0].Substring(14);
      for (int i = 0; i < line.Length; i++)
      {
        if (line[i] == '#')
        {
          flowers[i + offset] = true;
        }
      }

      PatternMatcher[] patterns = new PatternMatcher[data.Length - 2];

      for (int i = 0; i < data.Length - 2; i++)
      {
        patterns[i] = new PatternMatcher(data[i + 2]);
      }

      return new Tuple<bool[], PatternMatcher[]>(flowers, patterns);
    }

    public static bool[] getNewFlowerArray(bool[] flowers, PatternMatcher[] patterns)
    {
      bool[] newArray = new bool[flowers.Length];
      for (int i = 0; i < newArray.Length; i++)
      {
        newArray[i] = false;
      }


      for (int i = 2; i < flowers.Length - 2; i++)
      {
        bool first = flowers[i - 2];
        bool second = flowers[i - 1];
        bool third = flowers[i];
        bool fourth = flowers[i + 1];
        bool fifth = flowers[i + 2];

        bool result = false;
        for (int j = 0; j < patterns.Length; j++)
        {
          if (patterns[j].matches(first, second, third, fourth, fifth))
          {
            result = patterns[j].result;
          }
        }
        newArray[i] = result;
      }
      
      return newArray;
    }


    public static int firstProblem(Tuple<bool[], PatternMatcher[]> data)
    {
      bool[] flowers = data.Item1;
      PatternMatcher[] patterns = data.Item2;
      print(flowers, 90, 300);
      for (int repititions = 0; repititions < 20; repititions++)
      {
        flowers = getNewFlowerArray(flowers,patterns);
        print(flowers, 90, 300);
      }

      int sum = 0;
      for (int i = 0; i < flowers.Length; i++)
      {
        int value = 0;
        if (flowers[i])
        {
          value = i - offset - 1;
          sum += value;
        }
      }

      return sum;
    }


    public static int secondProblem(Tuple<bool[], PatternMatcher[]> data)
    {
      bool[] flowers = new bool[2147483580];

      int offsetIntern = 250000000;

      for(int i=0;i<data.Item1.Length;i++){
        flowers[i + offsetIntern] = data.Item1[i];
      }

      PatternMatcher[] patterns = data.Item2;
      for (long repititions = 0; repititions < 5000000000; repititions++)
      {
        flowers = getNewFlowerArray(flowers, patterns);
      }

      int sum = 0;
      for (int i = 0; i < flowers.Length; i++)
      {
        int value = 0;
        if (flowers[i])
        {
          value = i - offset - 1;
          sum += value;
        }
      }

      return sum;
    }





    public static void print(bool[] flowers, int offset, int max)
    {
      Console.WriteLine();
      for (int i = offset; i < max; i++)
      {
        if (flowers[i])
        {
          Console.Write("#");
        }
        else
        {
          Console.Write(".");
        }
      }
      Console.WriteLine();
    }
  }



  public class PatternMatcher {
    private readonly bool[] values = new bool[5];
    public readonly bool result = false;

    public PatternMatcher(string label)
    {
      for (int i = 0; i < this.values.Length; i++)
      {
        if (label[i] == '#')
        {
          this.values[i] = true;
        }
      }

      if (label[9] == '#')
      {
        this.result = true;
      }

    }

    public bool matches(bool first, bool second, bool third, bool fourth, bool fifth)
    {
      if (first == this.values[0] && second == this.values[1] && third == this.values[2] && fourth == this.values[3] && fifth == this.values[4])
      {
        return true;
      }
      return false;
    }

    public void updatePositions(bool[] flowers)
    {
      for (int i = 2; i < flowers.Length - 2; i++)
      {
        bool matches = this.matches(flowers[i - 2],
        flowers[i - 1], flowers[i]
        , flowers[i + 1], flowers[i + 2]);
        if (matches)
        {
          flowers[i] = this.result;
        }

      }
    }

  }
}
