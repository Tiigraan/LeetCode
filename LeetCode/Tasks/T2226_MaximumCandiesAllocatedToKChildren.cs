namespace LeetCode.Tasks;

public class T2226_MaximumCandiesAllocatedToKChildren
{
    public int MaximumCandies(int[] candies, long k)
    {
        var result = 0;        
        
        var left = 1;
        var right = candies.Max();
        
        var middle = (left + right) / 2;
        
        while (left <= right)
        {
            if (CanDivide(candies, k, middle))
            {
                result = middle;
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }

            middle = (left + right) / 2;
        }

        return result;
    }

    private bool CanDivide(int[] candies, long k, int count)
    {
        for (var i = candies.Length - 1; i >= 0; i--)
        {
            k -= candies[i] / count;
            if (k <= 0)
                return true;
        }
        
        return false;
    }
}