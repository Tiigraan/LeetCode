namespace LeetCode.Tasks;

public class T2551_PutMarblesInBags
{
    public long PutMarbles(int[] weights, int k)
    {
        var n = weights.Length;
        var pairWeights = new int[n - 1];

        for (var i = 0; i < n - 1; i++)
            pairWeights[i] = weights[i] + weights[i + 1];

        Array.Sort(pairWeights);

        var answer = 0L;
        for (var i = 0; i < k - 1; i++)
            answer += pairWeights[n - 2 - i] - pairWeights[i];

        return answer;
    }
}