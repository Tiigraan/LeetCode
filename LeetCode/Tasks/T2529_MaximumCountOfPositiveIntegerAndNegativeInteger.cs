namespace LeetCode.Tasks;

public class T2529_MaximumCountOfPositiveIntegerAndNegativeInteger
{
    public int MaximumCount(int[] nums)
    {
        var lastNegative = GetBorderIndex(nums, 0);
        var firstPositive = GetBorderIndex(nums, 1);
        
        return Math.Max(lastNegative, nums.Length - firstPositive);
    }

    private int GetBorderIndex(int[] nums, int border)
    {
        if (nums[0] > border)
            return 0;

        if (nums[^1] < border)
            return nums.Length;
        
        var left = 0;
        var right = nums.Length - 1;
        var middle = (left + right) / 2;
        
        while (left < right)
        {
            if (nums[middle] < border)
                left = middle + 1;
            else
                right = middle;
            
            middle =  (left + right) / 2;
        }
        
        return middle;
    }
}