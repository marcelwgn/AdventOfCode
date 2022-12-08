using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;

namespace AdventOfCode.Year2020.Solutions
{
    public class Tile{
        public long Id { get; set; }
        public string[] Borders { get; set; }

        public string[] BordersFlipped { get; set; }

        public Tile(long id, string leftBorder, string topBorder, string rightBorder, string bottomBorder)
        {
            Id = id;
            Borders = new string[]
            {
                leftBorder,
                topBorder,
                rightBorder,
                bottomBorder
            };
            BordersFlipped = new string[]
            {
                Reverse(leftBorder),
                Reverse(topBorder),
                Reverse(rightBorder),
                Reverse(bottomBorder)
            };

            static string Reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }

        public override bool Equals(object? obj)
        {
            if(obj is null)
            {
                return false;
            }
            var bordersEqual = true;
            for (int i = 0; i < Borders.Length; i++)
            {
                if((obj as Tile)!.Borders[i] != Borders[i])
                {
                    bordersEqual = false;
                }
            }
            return obj is Tile tile &&
                Id == tile.Id &&
                bordersEqual;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Borders.GetHashCode();
        }
    }

    public static class Day20
    {
        public static IList<Tile> GetTiles(string[] data)
        {
            var tiles = new List<Tile>(data.Length / 10);

            long id = long.Parse(data[0].Split(' ')[1].Replace(':', ' '));
            int lastIndex = 0;
            for (int i = 1; i < data.Length; i++)
            {
                var split = data[i].Split(' ');
                if(split.Length == 2)
                {
                    id = long.Parse(split[1].Replace(':', ' '));
                    lastIndex = i;
                }
                else if(string.IsNullOrEmpty(data[i]))
                {
                    var top = data[lastIndex + 1];
                    var bottom = data[i - 1];
                    var left = string.Join("",data[(lastIndex + 1)..i].Select(x => x[0]));
                    var right = string.Join("", data[(lastIndex + 1)..i].Select(x => x[^1]));
                    tiles.Add(new Tile(id, left, top, right, bottom));
                }
            }
            var topEnd = data[lastIndex + 1];
            var bottomEnd = data[^1];
            var leftEnd = string.Join("", data[(lastIndex + 1)..data.Length].Select(x => x[0]));
            var rightEnd = string.Join("", data[(lastIndex + 1)..data.Length].Select(x => x[^1]));
            tiles.Add(new Tile(id, leftEnd, topEnd, rightEnd, bottomEnd));
            return tiles;
        }

        public static long FirstProblem(string[] data)
        {
            var tiles = GetTiles(data);
            var corners = GetCorners(tiles);

            if (corners.Count == 4)
            {
                return corners[0].Id * corners[1].Id * corners[2].Id * corners[3].Id;
            }

            return 0;
        }

        private static List<Tile> GetCorners(IList<Tile> tiles)
        {
            var corners = new List<Tile>();
            foreach (var item in tiles)
            {
                if (GetNeighbors(item, tiles).Count() == 2)
                {
                    corners.Add(item);
                }
            }

            return corners;
        }

        public static IEnumerable<Tile> GetNeighbors(Tile tile, IList<Tile> tiles)
        {
            var neighbors = new List<Tile>();

            foreach (var candidate in tiles)
            {
                if(candidate != tile)
                {
                    bool added = false;
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (candidate.Borders[i] == tile.Borders[j]
                                || candidate.Borders[i] == tile.BordersFlipped[j])
                            {
                                neighbors.Add(candidate);
                                added = true;
                                break;
                            }
                            if(added)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return neighbors;
        }
    }
}
