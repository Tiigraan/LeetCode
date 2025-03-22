namespace LeetCode.Tasks;

public class T2685_CountTheNumberOfCompleteComponents
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        var union = new int[n];
        var edgesCount = new int[n];
        var rank = new int[n];
        for  (var i = 0; i < n; i++)
            union[i] = i;

        foreach (var edge in edges)
        {
            Union(union, rank, edge[0], edge[1]);
            edgesCount[edge[0]] += 1;
            edgesCount[edge[1]] += 1;
        }

        var componentsCount = new Dictionary<int, int>();
        for (var i = 0; i < n; i++)
        {
            var componentNumber = Find(union, union[i]);
            union[i] = Find(union, i);
            
            if (!componentsCount.TryAdd(componentNumber, 1))
                componentsCount[componentNumber] += 1;
        }

        var completedComponents = componentsCount
            .ToDictionary(x => x.Key, _ => true);
        
        for (var i = 0; i < n; i++)
        {
            if (edgesCount[i] + 1 != componentsCount[union[i]])
                completedComponents[union[i]] = false;
        }


        return completedComponents.Count(x => x.Value);
    }

    private void Union(int[] union, int[] rank, int from, int to)
    {
        var fromRoot = Find(union, from);
        var toRoot = Find(union, to);

        if (rank[fromRoot] < rank[toRoot])
        {
            union[fromRoot] = toRoot;
        }
        else if (rank[fromRoot] > rank[toRoot])
        {
            union[toRoot] = fromRoot;
        }
        else
        {
            union[fromRoot] = toRoot;
            rank[fromRoot] += 1;
        }
    }

    private int Find(int[] union, int node)
    {
        while (union[node] != node)
            node = union[node];
        
        return node;
    }
}