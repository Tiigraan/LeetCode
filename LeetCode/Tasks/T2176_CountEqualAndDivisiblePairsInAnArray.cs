namespace LeetCode.Tasks;

public class T2176_CountEqualAndDivisiblePairsInAnArray
{
    public int CountPairs(int[] nums, int k) {
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        for (var j = i + 1; j < nums.Length; j++)
            if (nums[i] == nums[j] && (i * j) % k == 0)
                count++;
            
        return count;
    }
}