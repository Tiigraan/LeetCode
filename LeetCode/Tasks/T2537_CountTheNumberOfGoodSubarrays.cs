namespace LeetCode.Tasks;

public class T2537_CountTheNumberOfGoodSubarrays
{
    public long CountGood(int[] nums, int k)
    {
        var n = nums.Length;
        var currentPairCount = 0; 
        var right = -1;
        var numCounts = new Dictionary<int, int>();
        long goodSubarraysCount = 0;
        
        for (var left = 0; left < n; ++left) {
            while (currentPairCount < k && right + 1 < n) {
                right++;
                numCounts.TryGetValue(nums[right], out var currentNumCount);
                currentPairCount += currentNumCount;
                numCounts[nums[right]] = currentNumCount + 1;
            }
            if (currentPairCount >= k) {
                goodSubarraysCount += n - right;
            }
            numCounts[nums[left]] -= 1;
            currentPairCount -= numCounts[nums[left]];
        }
        return goodSubarraysCount;
    }
}