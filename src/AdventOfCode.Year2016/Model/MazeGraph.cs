using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2016.Model;

public class MazeGraph
{

    public Dictionary<Coordinate, HashSet<Coordinate>> Neighbors { get; private set; } = [];
    public HashSet<Coordinate> Vertices { get; private set; }

    public MazeGraph(char[][] grid, char wallCharacter = '#')
    {
        Vertices = [];
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                var currentCell = grid[i][j];

                if (currentCell != wallCharacter)
                {
                    Vertices.Add(new(i, j));
                    if (i > 0)
                    {
                        var leftNode = grid[i - 1][j];
                        if (leftNode != wallCharacter)
                        {
                            AddNeighborhood(new(i, j), new(i - 1, j));
                        }
                    }

                    if (j > 0)
                    {
                        var topNode = grid[i][j - 1];

                        if (topNode != wallCharacter)
                        {
                            AddNeighborhood(new(i, j), new(i, j - 1));
                        }
                    }
                }
            }
        }

        void AddNeighborhood(Coordinate firstPos, Coordinate secondPos)
        {
            if (Neighbors.TryGetValue(firstPos, out var valueSecondPos))
            {
                valueSecondPos.Add(secondPos);
            }
            else
            {
                Neighbors.Add(firstPos, [secondPos]);
            }

            if (Neighbors.TryGetValue(secondPos, out var valueFirstPos))
            {
                valueFirstPos.Add(firstPos);
            }
            else
            {
                Neighbors.Add(secondPos, [firstPos]);
            }
        }

    }

    public int CalculateDistance(Coordinate p1, Coordinate p2)
    {
        var remainingVertices = new HashSet<Coordinate>();

        foreach (var vertex in Vertices)
        {
            remainingVertices.Add(vertex);
        }

        var distDictionary = new Dictionary<Coordinate, int>()
        {
            {p1, 0 }
        };

        var prevVertices = new Dictionary<Coordinate, Coordinate>();

        while (remainingVertices.Count > 0)
        {
            var next = remainingVertices.Select(v => (Vertex: v, Distance: GetDist(v))).OrderBy(x => x.Distance).First().Vertex;
            remainingVertices.Remove(next);

            if (Neighbors.TryGetValue(next, out var neighbors))
            {
                foreach (var neighbor in neighbors)
                {
                    var altDist = GetDist(next) + 1;
                    if (altDist < GetDist(neighbor))
                    {
                        distDictionary[neighbor] = altDist;
                        prevVertices[neighbor] = next;
                    }
                    if (neighbor == p2)
                    {
                        return distDictionary[neighbor];
                    }
                }
            }
        }

        return -1;

        int GetDist(Coordinate vertex)
        {
            if (distDictionary.TryGetValue(vertex, out var distance))
            {
                return distance;
            }
            return int.MaxValue;
        }
    }
}
