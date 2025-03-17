namespace LeetCode.Tasks;

public class T2206_DivideArrayIntoEqualPairs
{
    public bool DivideArray(int[] nums) {
        var counts = new int[500];
        foreach (var num in nums)
            counts[num - 1]++;

        return counts.All(count => count % 2 == 0);
    }
}