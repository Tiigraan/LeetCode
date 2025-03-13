namespace LeetCode.Tasks;

public class T3356_ZeroArrayTransformationII
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        var counts = new int[nums.Length + 1];
        var k = 0;
        var sum = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            while (sum + counts[i] < num)
            {
                if (k == queries.Length)
                    return -1;
                
                var (left, right, value) = (queries[k][0], queries[k][1], queries[k][2]);
                k++;

                if (right < i) 
                    continue;
                
                counts[Math.Max(left, i)] += value;
                counts[right + 1] -= value;
            }
            
            sum += counts[i];
        }

        return k;
    }
}