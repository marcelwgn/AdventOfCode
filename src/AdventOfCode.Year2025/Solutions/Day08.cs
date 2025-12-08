using System.Numerics;

namespace AdventOfCode.Year2025.Solutions;

public static class Day08
{
    public static int cConnections { get; set; } = 1000;

    private static List<(Vector3, Vector3, float)> RgDistancesParse(string[] input)
    {
        List<Vector3> rgv3Points = new();

        foreach (var line in input)
        {
            var parts = line.Split(',');
            var v3Point = new Vector3(
                int.Parse(parts[0]),
                int.Parse(parts[1]),
                int.Parse(parts[2])
            );
            rgv3Points.Add(v3Point);
        }


        List<(Vector3, Vector3, float)> rgDistances = new();
        for (int i = 0; i < rgv3Points.Count; i++)
        {
            for (int j = i + 1; j < rgv3Points.Count; j++)
            {
                var dist = Vector3.Distance(rgv3Points[i], rgv3Points[j]);
                rgDistances.Add((rgv3Points[i], rgv3Points[j], dist));
            }
        }

        return rgDistances.OrderBy(t => t.Item3).ToList();
    }

    public static string FirstProblem(string[] input)
    {
        var rgDistances = RgDistancesParse(input).Take(cConnections);

        List<HashSet<Vector3>> rgclusters = new();
        foreach (var pair in rgDistances)
        {
            AddToClusters(rgclusters, pair.Item1, pair.Item2);
        }

        // Return product of sizes of clusters
        long product = 1;
        foreach (var cluster in rgclusters.OrderByDescending(cluster => cluster.Count).Take(3))
        {
            product *= cluster.Count;
        }
        return product.ToString();
    }

    public static string SecondProblem(string[] input)
    {
        var rgDistances = RgDistancesParse(input);

        List<HashSet<Vector3>> rgclusters = new();
        foreach (var pair in rgDistances)
        {
            AddToClusters(rgclusters, pair.Item1, pair.Item2);

            if (rgclusters.Count == 1 && rgclusters[0].Count == input.Length)
            {
                return ((long)pair.Item1.X * (long)pair.Item2.X).ToString();
            }
        }

        return "-1";
    }

    private static void AddToClusters(List<HashSet<Vector3>> rgclusters, Vector3 v1, Vector3 v2)
    {
        List<HashSet<Vector3>> rgclusterMatched = new();
        foreach (var cluster in rgclusters)
        {
            if (cluster.Contains(v1) || cluster.Contains(v2))
            {
                rgclusterMatched.Add(cluster);
            }
        }

        if (rgclusterMatched.Count > 1)
        {
            // Merge them
            var mergedCluster = new HashSet<Vector3>();
            foreach (var cluster in rgclusterMatched)
            {
                foreach (var v in cluster)
                {
                    mergedCluster.Add(v);
                }
                rgclusters.Remove(cluster);
            }
            mergedCluster.Add(v1);
            mergedCluster.Add(v2);
            rgclusters.Add(mergedCluster);
        }
        else if (rgclusterMatched.Count == 1)
        {
            var cluster = rgclusterMatched[0];
            cluster.Add(v1);
            cluster.Add(v2);
        }
        else
        {
            rgclusters.Add(new HashSet<Vector3>() { v1, v2 });
        }
    }
}
