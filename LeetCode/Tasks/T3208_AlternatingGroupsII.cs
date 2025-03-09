namespace LeetCode.Tasks;

public class T3208_AlternatingGroupsII
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        var result = 0;
        var count = 1;

        for (var i = 1; i < colors.Length + k - 1; i++)
        {
            if (colors[i % colors.Length] != colors[(i - 1)  % colors.Length])
            {
                count++;
            }
            else
            {
                count = 1;
            }
            
            if (count >= k)
                result++;
        }
        
        return result;
    }
}