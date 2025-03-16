namespace LeetCode.Tasks;

public class T2560_HouseRobberIV
{
    public int MinCapability(int[] nums, int k)
    {
        var left = int.MaxValue;
        var right = int.MinValue;
        
        foreach (var num in nums)
        {
            if (num < left)
                left = num;
            
            if (num > right)
                right = num;
        }

        while (left < right)
        {
            var middle = (left + right) / 2;
            if (HasSubSequence(nums, k, middle))
                right = middle;
            else
                left = middle + 1;
        }

        return right;
    }

    private bool HasSubSequence(int[] nums, int k, int maxElement)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > maxElement)
                continue;
            
            k--;
            i++;
        }
        
        return k <= 0;
    }
}