namespace LeetCode.Tasks;

public class T2161_PartitionArrayAccordingToGivenPivot
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        var result = new int[nums.Length];
        var lessIndex = 0;
        var greaterIndex = nums.Length - 1;

        for (int i = 0, j = nums.Length - 1; i < nums.Length; i++, j--)
        {
            if (nums[i] < pivot)
            {
                result[lessIndex] = nums[i];
                lessIndex++;
            }

            if (nums[j] > pivot)
            {
                result[greaterIndex] = nums[j];
                greaterIndex--;
            }
        }

        for (var i = lessIndex; i <= greaterIndex; i++)
            result[i] = pivot;
        
        return result;
    }
}