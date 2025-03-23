namespace LeetCode.Tasks;

public class T1976_NumberOfWaysToArriveAtDestination
{
    public int CountPaths(int n, int[][] roads)
    {
        if (n == 1)
            return 1;

        var graph = new Dictionary<int, List<(int to, int coast)>>();
        
        foreach (var road in roads)
        {
            var (from, to, coast) = (road[0], road[1],  road[2]);
            
            if (!graph.ContainsKey(from))
                graph[from] = [];
            
            graph[from].Add((to, coast));
            
            if (!graph.ContainsKey(to))
                graph[to] = [];
            
            graph[to].Add((from, coast));
        }

        var tag = new long[n];
        for (var i = 1; i < n; i++)
            tag[i] = long.MaxValue;


        var queue = new PriorityQueue<int, long>();
        queue.Enqueue(0, 0);

        var pathsCounts = new int[n];
        pathsCounts[0] = 1;
        const int mod = 1_000_000_007;

        while (queue.TryDequeue(out var node, out var sourceCoast))
        {
            if (sourceCoast > tag[node])
                continue;
            
            foreach (var (toNode, coast) in graph[node])
                switch (tag[toNode].CompareTo(sourceCoast + coast))
                {
                    case 0:
                        pathsCounts[toNode] = (pathsCounts[toNode] + pathsCounts[node]) % mod;
                        break;
                    case > 0:
                        tag[toNode] = sourceCoast + coast;
                        pathsCounts[toNode] = pathsCounts[node];
                        queue.Enqueue(toNode, sourceCoast + coast);
                        break;
                }
        }
        
        return pathsCounts[n - 1];
    }
}