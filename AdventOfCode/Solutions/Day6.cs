using System;
using System.Collections.Generic;
using AdventOfCode.Utils;

namespace AdventOfCode.Solutions {
  public class Day6 {

    public static Tuple<Point[], String[,]> convert(String[] data) {
      Point[] points = new Point[data.Length];
      for (int i = 0; i < data.Length; i++) {
        String[] split = data[i].Split(",");
        int first = int.Parse(split[0]);
        int second = int.Parse(split[1]);
        points[i] = new Point(first, second, i.ToString());

      }

      int fieldSize = 400;
      String[,] field = new string[fieldSize, fieldSize];

      for (int i = 0; i < fieldSize; i++) {
        for (int j = 0; j < fieldSize; j++) {
          int bestDistance = int.MaxValue;
          int pointsBest = 0;
          bool isUndecided = false;
          for (int pointsIndex = 0; pointsIndex < data.Length; pointsIndex++) {
            Point current = points[pointsIndex];
            int distance = current.getDistance(j, i);
            if (bestDistance == distance) {
              pointsBest = pointsIndex;
              isUndecided = true;
            }
            if (bestDistance > distance) {
              isUndecided = false;
              pointsBest = pointsIndex;
              bestDistance = distance;
            }
          }


          if (isUndecided) {
            field[i, j] = "";

          }
          else {
            field[i, j] = points[pointsBest].name;
          }
        }
      }

      return new Tuple<Point[], string[,]>(points, field);
    }


    public static int firstProblem(Tuple<Point[], string[,]> data) {
      Point[] points = data.Item1;
      String[,] field = data.Item2;

      int fieldSize = (int)Math.Sqrt(field.Length);

      //Getting list of points that have a area not limited by array bounds, so to speak are finite
      List<String> finiteSets = new List<string>();
      for (int label = 0; label < points.Length; label++) {
        finiteSets.Add(label.ToString());
      }
      for (int i = 0; i < fieldSize; i++) {
        string leftBorder = field[i, 0];
        string rightBorder = field[i, fieldSize - 1];

        string upperBorder = field[0, i];
        string lowerBorder = field[fieldSize - 1, i];

        finiteSets.Remove(leftBorder);
        finiteSets.Remove(rightBorder);
        finiteSets.Remove(upperBorder);
        finiteSets.Remove(lowerBorder);

      }
      int bestCount = 0;
      foreach (String label in finiteSets) {
        int count = 0;
        for (int i = 0; i < fieldSize; i++) {
          for (int j = 0; j < fieldSize; j++) {
            if (field[i, j] == label) {
              count++;
            }
          }
        }
        if (count > bestCount) {
          bestCount = count;
        }
      }
      return bestCount;
    }

    public static int secondProblem(Tuple<Point[], String[,]> data) {
      Point[] points = data.Item1;
      String[,] field = data.Item2;

      int fieldSize = (int)Math.Sqrt(field.Length);

      int suitableLocationsCount = 0;

      int maxDistance = 10000;

      for (int i = 0; i < fieldSize; i++) {
        for (int j = 0; j < fieldSize; j++) {
          int count = 0;
          for (int pointIndex = 0; pointIndex < points.Length; pointIndex++) {
            count += points[pointIndex].getDistance(j, i);
          }

          if (maxDistance > count) {
            suitableLocationsCount++;
          }
        }
      }
      return suitableLocationsCount;

    }
  }
}