namespace LeetCode.Tasks;

public class T2570_MergeTwo2DArraysBySummingValues
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        var (firstIndex, secondIndex) = (0, 0);
        var (n, m) = (nums1.Length, nums2.Length);
        var result = new List<int[]>(n + m);

        while (firstIndex < n && secondIndex < m)
        {
            var (first, second) = (nums1[firstIndex], nums2[secondIndex]);
            if (first[0] == second[0])
            {
                result.Add([first[0], first[1] + second[1]]);
                firstIndex++;
                secondIndex++;
            }
            else if (first[0] < second[0])
            {
                result.Add(first);
                firstIndex++;
            }
            else
            {
                result.Add(second);
                secondIndex++;
            }
        }

        if (firstIndex != n)
            result.AddRange(nums1.Skip(firstIndex));

        if (secondIndex != m)
            result.AddRange(nums2.Skip(secondIndex));

        return result.ToArray();
    }
}