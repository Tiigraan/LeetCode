namespace LeetCode.Tasks;

public class T2401_LongestNiceSubarray
{
    public int LongestNiceSubarray(int[] nums)
    {
        var maxSubStringLength = 1;
        var startIndex = 0;
        var state = nums[0];
        
        for (var i = 1; i < nums.Length; i++)
        {
            if ((nums[i] & state) == 0)
            {
                var currentSubStringLength = i - startIndex + 1;
                maxSubStringLength = maxSubStringLength < currentSubStringLength
                    ? currentSubStringLength
                    : maxSubStringLength;
                state += nums[i];
                continue;
            }

            while ((nums[i] & state) != 0)
            {
                state -= nums[startIndex];
                startIndex++;
            }

            state += nums[i];
        }

        return maxSubStringLength;
    }
}