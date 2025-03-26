namespace LeetCode.Tasks;

public class T2033_MinimumOperationsToMakeAUni_ValueGrid
{
    public int MinOperations(int[][] grid, int x)
    {
        var (n, m) = (grid.Length, grid[0].Length);
        var nums = new int[n * m];
        
        for (var i = 0;  i < n; i++)
        for (var j = 0; j < m; j++)
            nums[i * m + j] = grid[i][j];
        
        Array.Sort(nums, (a, b) => a.CompareTo(b));
        
        var middle = nums[nums.Length / 2];
        var operationsCount = 0;

        foreach (var num in nums)
        {
            if ((num - middle) % x != 0)
                return -1;

            operationsCount += Math.Abs(num - middle) / x;
        }

        return operationsCount;
    }
}