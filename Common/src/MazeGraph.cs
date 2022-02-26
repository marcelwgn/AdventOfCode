using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Common
{
    public class MazeGraph
    {

        public Dictionary<(int X, int Y), HashSet<(int X, int Y)>> Neighbors { get; private set; } = new();
        public HashSet<(int X, int Y)> Vertices { get; private set; }

        public MazeGraph(char[][] grid, char wallCharacter = '#')
        {
            Vertices = new HashSet<(int X, int Y)>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var currentCell = grid[i][j];

                    if (currentCell != wallCharacter)
                    {
                        Vertices.Add((i, j));
                        try
                        {
                            var leftNode = grid[i - 1][j];
                            if (leftNode != wallCharacter)
                            {
                                AddNeighborhood((i, j), (i - 1, j));
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            var topNode = grid[i][j - 1];


                            if (topNode != wallCharacter)
                            {
                                AddNeighborhood((i, j), (i, j - 1));
                            }
                        }
                        catch (Exception) { }
                    }
                }
            }

            void AddNeighborhood((int X, int Y) firstPos, (int X, int Y) secondPos)
            {
                if (Neighbors.ContainsKey(firstPos))
                {
                    Neighbors[firstPos].Add(secondPos);
                }
                else
                {
                    Neighbors.Add(firstPos, new HashSet<(int X, int Y)> { secondPos });
                }

                if (Neighbors.ContainsKey(secondPos))
                {
                    Neighbors[secondPos].Add(firstPos);
                }
                else
                {
                    Neighbors.Add(secondPos, new HashSet<(int X, int Y)> { firstPos });
                }
            }

        }

        public int CalculateDistance((int firstX, int firstY) p1, (int secX, int secY) p2)
        {
            var remainingVertices = new HashSet<(int, int)>();

            foreach (var vertex in Vertices)
            {
                remainingVertices.Add(vertex);
            }

            var distDictionary = new Dictionary<(int, int), int>()
            {
                {p1, 0 }
            };

            var prevVertices = new Dictionary<(int, int), (int, int)>();

            while(remainingVertices.Count > 0)
            {
                var next = remainingVertices.Select(v => (Vertex: v, Distance : GetDist(v))).OrderBy(x => x.Distance).First().Vertex;
                remainingVertices.Remove(next);

                if (Neighbors.ContainsKey(next))
                {
                    foreach (var neighbor in Neighbors[next])
                    {
                        var altDist = GetDist(next) + 1;
                        if(altDist < GetDist(neighbor))
                        {
                            distDictionary[neighbor] = altDist;
                            prevVertices[neighbor] = next;
                        }
                        if(neighbor == p2)
                        {
                            return distDictionary[neighbor];
                        }
                    }
                }
            }

            return -1;

            int GetDist((int,int) vertex)
            {
                if (distDictionary.ContainsKey(vertex))
                {
                    return distDictionary[vertex];
                }
                return int.MaxValue;
            }
        }
    }
}
