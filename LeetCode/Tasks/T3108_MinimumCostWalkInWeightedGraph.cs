using System.IO.Enumeration;

namespace LeetCode.Tasks;

public class T3108_MinimumCostWalkInWeightedGraph
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        var union = new int[n];
        var rank = new int[n];
        var coasts = new int[n];

        for (var i = 0; i < n; i++)
        {
            union[i] = i;
            coasts[i] = int.MaxValue;
        }
        
        foreach (var edge in edges)
            Union(coasts, rank, union, edge[0], edge[1],  edge[2]);
        
        var result = new List<int>(query.Length);
        foreach (var (from, to)  in query.Select(x => (x[0], x[1])))
        {
            var fromRoot = Find(union, from);
            var toRoot = Find(union, to);
            if (fromRoot == toRoot)
                result.Add(coasts[fromRoot]);
            else
                result.Add(-1);
        }
        
        return result.ToArray();
    }
    
    private void Union(int[] coasts, int[] rank, int[] union, int from, int to, int cost)
    {
        var fromRoot =  Find(union, from);
        var toRoot =  Find(union, to);


        if (fromRoot == toRoot)
        {
            coasts[fromRoot] &= cost;
            return;
        }

        if (rank[fromRoot] < rank[toRoot])
        {
            coasts[toRoot] &= coasts[fromRoot] & cost;
            union[fromRoot] = toRoot;
        }
        else if (rank[toRoot] < rank[fromRoot])
        {
            coasts[fromRoot] &= coasts[toRoot] & cost;
            union[toRoot] = fromRoot;
        }
        else
        {
            coasts[toRoot] &= coasts[fromRoot] & cost;
            union[fromRoot] = toRoot;
            rank[toRoot] += 1;
        }
    }

    private int Find(int[] union, int node)
    {
        while (union[node] != node)
            node = union[node];
        
        return node;
    }
}


// [[0, 1, 7], [1, 3, 7], [1, 2, 1]];
// 0 1 2 3 4
// 1 3 1 3 4