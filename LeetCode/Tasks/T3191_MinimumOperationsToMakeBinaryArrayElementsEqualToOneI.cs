namespace LeetCode.Tasks;

public class T3191_MinimumOperationsToMakeBinaryArrayElementsEqualToOneI
{
    public int MinOperations(int[] nums)
    {
        var changeCount = 0;
        for (var i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] != 0) continue;

            nums[i] = 1;
            nums[i + 1] = nums[i + 1] == 0 ? 1 : 0;
            nums[i + 2] = nums[i + 2] == 0 ? 1 : 0;
            changeCount++;
        }

        return nums[^1] == 1 && nums[^2] == 1
            ? changeCount
            : -1;
    }
}