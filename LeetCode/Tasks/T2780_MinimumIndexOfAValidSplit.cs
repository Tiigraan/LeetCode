namespace LeetCode.Tasks;

public class T2780_MinimumIndexOfAValidSplit
{
    public int MinimumIndex(IList<int> nums)
    {
        var numCounts = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!numCounts.TryAdd(num, 1))
                numCounts[num] += 1;
        }
        
        var (maxNum, count) = numCounts.MaxBy(x => x.Value);
        var countToIndex = new List<int>(count) { 0 };
        for (var i = 0; i < nums.Count; i++)
        {
            if (nums[i] == maxNum)
                countToIndex.Add(i);
        }

        for (var i = 1; i < countToIndex.Count; i++)
        {
            if (countToIndex[i] + 1 < 2 * i &&
                nums.Count - countToIndex[i] - 1 < 2 * (count - i))
                return countToIndex[i];
        }
        
        return -1;
    }
}
// 1 2 2 2
//   |