namespace LeetCode.Tasks;

public class T3396_MinimumNumberOfOperationsToMakeElementsInArrayDistinct
{
    public int MinimumOperations(int[] nums) {
        var set = new HashSet<int>();

        for (var i = nums.Length; i > 0; i--)
        {
            if (set.Add(nums[i - 1]))
                continue;

            return i % 3 == 0
                ? i / 3
                : i / 3 + 1;
        }

        return 0;
    }
}