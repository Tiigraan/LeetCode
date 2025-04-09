namespace LeetCode.Tasks;

public class T3375_MinimumOperationsToMakeArrayValuesEqualToK
{
    public int MinOperations(int[] nums, int k)
    {
        var numLessK = new HashSet<int>();

        foreach (var num in nums)
        {
            if (num > k)
                numLessK.Add(num);
            else if (num < k)
                return -1;
        }
        
        return numLessK.Count;
    }
}