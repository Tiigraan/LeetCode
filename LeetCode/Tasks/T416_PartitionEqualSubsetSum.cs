namespace LeetCode.Tasks;

public class T416_PartitionEqualSubsetSum
{
    public bool CanPartition(int[] nums) {
        var numsSum = nums.Sum();
        if (numsSum % 2 != 0)
            return false;

        var target = numsSum / 2;
        var dp = new bool[target + 1];
        dp[0] = true;

        foreach (var num in nums) {
            for (var j = target; j >= num; j--) {
                dp[j] |= dp[j - num];
            }
        }

        return dp[target];
    }
}