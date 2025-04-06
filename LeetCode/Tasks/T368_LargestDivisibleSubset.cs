namespace LeetCode.Tasks;

public class T368_LargestDivisibleSubset
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);
        var maxCounts = new int[nums.Length];
        var path = Enumerable.Range(0, nums.Length).ToArray();
        var maxSubsetCount = 0;
        var startMaxSubsetCount = 0;
        
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var maxNum = nums[i];
            var maxCount = 0;
            var maxCountIndex = 0;
            for (var j = i; j < nums.Length; j++)
            {
                if (nums[j] % maxNum != 0 || maxCount >= maxCounts[j] + 1)
                    continue;
                
                maxCount = maxCounts[j] + 1;
                maxCountIndex = j;
            }
            
            maxCounts[i] = maxCount;
            path[i] = maxCountIndex;
            
            if (maxCount > maxSubsetCount)
            {
                maxSubsetCount = maxCount;
                startMaxSubsetCount = i;
            }
        }

        var result = new List<int>(maxCounts[startMaxSubsetCount]) { nums[startMaxSubsetCount] };
        while (path[startMaxSubsetCount] != startMaxSubsetCount)
        {
            startMaxSubsetCount = path[startMaxSubsetCount];
            result.Add(nums[startMaxSubsetCount]);
        }
        
        return result;
    }
}