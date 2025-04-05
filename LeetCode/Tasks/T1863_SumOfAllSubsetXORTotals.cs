namespace LeetCode.Tasks;

public class T1863_SumOfAllSubsetXORTotals
{
    public int SubsetXORSum(int[] nums)
    {
        return SubsetXORSum(nums, 0).Sum();
    }

    private IEnumerable<int> SubsetXORSum(int[] nums, int index)
    {
        if (index > nums.Length - 1)
        {
            yield return 0;
            yield break;
        }

        var num = nums[index];
        foreach (var sum in SubsetXORSum(nums, index + 1))
        {
            yield return (sum | num) - (sum & num);
            yield return sum;
        }
    }
}