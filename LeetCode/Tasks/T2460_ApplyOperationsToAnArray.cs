namespace LeetCode.Tasks;

public class T2460_ApplyOperationsToAnArray
{
    public int[] ApplyOperations(int[] nums)
    {
        var result = new int[nums.Length];
        var j = 0;
        
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == 0)
                continue;

            if (nums[i] == nums[i + 1])
            {
                result[j] = nums[i] * 2;
                nums[i + 1] = 0;
            }
            else 
            {
                result[j] = nums[i]; 
            }

            j++;
        }

        if (nums.Last() != 0)
            result[j] = nums.Last();

        return result;
    }
}